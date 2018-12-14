﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading;
using Tumo.Models;

namespace Tumo
{
    public abstract class TmAsyncTcpSession
    {
        #region Properties
        //客户端Socket 
        private Socket Socket { get; set; }                //创建一个套接字，用于储藏代理服务端套接字，与客户端通信
        private bool IsRunning { get; set; }
        private bool noClose { get; set; } = false;
        #endregion

        #region byte[] Bytes        //接收缓冲区   
        private byte[] Buffer { get; set; }
        private int BufferSize { get; set; }
        private int RecvLength { get; set; }
        private List<byte> RecvBuffList { get; set; } = new List<byte>();
        private List<byte> SendBuffList { get; set; } = new List<byte>();
        private int surHL { get; set; }
        private int surBL { get; set; }
        private bool isHead { get; set; }
        private bool isBody { get; set; }
        #endregion

        #region Constructor
        public TmAsyncTcpSession() { }
        #endregion

        #region ReceiveMsg
        public void BeginReceiveMessage(object obj)
        {
            Socket = obj as Socket;
            OnConnect(Socket);
            Console.WriteLine(GetCurrentTime() + " (46)BeginReceiveMsg Id/IP: " + Thread.CurrentThread.ManagedThreadId + " / " + Socket.RemoteEndPoint.ToString());
            BufferSize = 1024;
            Buffer = new byte[BufferSize];
            isHead = true;
            isBody = false;
            surHL = 4;
            surBL = 0;
            IsRunning = true;
            Socket.BeginReceive(Buffer, 0, BufferSize, SocketFlags.None, new AsyncCallback(this.ReceiveCallback), this);
        }
        private void ReceiveCallback(IAsyncResult ar)
        {
            if (IsRunning)
            {
                Console.WriteLine(GetCurrentTime() + " (56)ReceiveCallback Id/IP: " + Thread.CurrentThread.ManagedThreadId + " / " + Socket.RemoteEndPoint.ToString());
                try
                {
                    RecvLength = Socket.EndReceive(ar);
                    if (RecvLength == 0)
                    {
                        //发送端关闭
                        Console.WriteLine("发送端{0}连接关闭", Socket.RemoteEndPoint);
                        IsRunning = false;
                        OnDisconnect(Socket);
                        return;
                    }
                    else
                    {
                        AddRange(RecvBuffList, Buffer, RecvLength);
                    }
                    //触发事件 解析缓存池RecvBuffList<byte> 读取数据字节
                    ParsingBytes();

                    //继续接收来自来客户端的数据  
                    Socket.BeginReceive(Buffer, 0, BufferSize, SocketFlags.None, new AsyncCallback(this.ReceiveCallback), this);
                }
                catch (Exception ex)
                {
                    Console.WriteLine(GetCurrentTime() + ex.ToString());
                    IsRunning = false;
                    OnDisconnect(Socket);
                }
            }
        }
        private void ParsingBytes()
        {
            Console.WriteLine(GetCurrentTime() + " (90), ReceiveMsg Id/IP: " + Thread.CurrentThread.ManagedThreadId + " / " + Socket.RemoteEndPoint.ToString());
            ///将本次要接收的消息头字节数置0
            int iBytesHead = 0;
            //将本次要剪切的字节数置0
            int iBytesBody = 0;
            try
            {
                if (isHead)
                {
                    //如果当前需要接收的字节数小于缓存池RecvBuffList，进行下一步操作
                    if (surHL <= RecvBuffList.Count)
                    {
                        iBytesHead = surHL;
                        surHL = 0;
                    }
                    if (surHL == 0)
                    {
                        isHead = false;
                        isBody = true;
                        //接收消息体（消息体的长度存储在消息头的0至4索引位置的字节里）
                        byte[] HeadBytes = new byte[iBytesHead];
                        ///将接收到的字节数的消息头保存到HeadBytes，//减去已经接收到的字节数
                        CutTo(RecvBuffList, HeadBytes, 0, iBytesHead);
                        int msgLength = IPAddress.NetworkToHostOrder(BitConverter.ToInt32(HeadBytes, 0));
                        surBL = msgLength;
                    }
                }
                if (isBody)
                {
                    //如果当前需要接收的字节数大于0，则循环接收
                    if (surBL <= RecvBuffList.Count)
                    {
                        iBytesBody = surBL;
                        surBL = 0;                    ///归零进入下一步操作
                    }
                    if (surBL == 0)
                    {
                        isBody = false;
                        isHead = true;
                        surHL = 4;
                        //一个消息包接收完毕，解析消息包
                        byte[] BodyBytes = new byte[iBytesBody];
                        CutTo(RecvBuffList, BodyBytes, 0, iBytesBody);
                        //一个消息包接收完毕，解析消息包
                        string mvcString = Encoding.UTF8.GetString(BodyBytes, 0, BodyBytes.Length);
                        ///这个方法用来处理参数Mvc，并让结果给客户端响应（当客户端发起请求时调用）
                        OnTransferParameter(mvcString, Socket);
                        /////将字符串string,用json反序列化转换成MvcParameter参数
                        //MvcParameter mvc = MvcTool.ToObject<MvcParameter>(mvcString);
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(GetCurrentTime() + ex.ToString());
                OnDisconnect(Socket);
            }
        }
        #endregion

        #region AddRange
        /// 提取数据
        void CutTo(List<byte> BuffList, byte[] bytes, int bytesoffset, int size)
        {
            BuffList.CopyTo(0, bytes, bytesoffset, size);
            BuffList.RemoveRange(0, size);
        }
        /// 队列数据
        void AddRange(List<byte> BuffList, byte[] buffer, int length)
        {
            byte[] temByte = new byte[length];
            Array.Copy(buffer, 0, temByte, 0, length);
            BuffList.AddRange(temByte);
        }
        #endregion

        #region SendMsg
        ///发送信息给客户端
        public void SendString(string mvcString)
        {
            Console.WriteLine(GetCurrentTime() + " (170) Send Thread Id:" + Thread.CurrentThread.ManagedThreadId);
            ////用Json将参数（MvcParameter）,序列化转换成字符串（string）
            //string mvcJsons = MvcTool.ToString<MvcParameter>(mvc);
            if (null == Socket.Handle || !Socket.Connected)
            {
                Console.WriteLine("连接已中断！！！");
                return;
            }
            //将字符串(string)转换成字节(byte)
            byte[] jsonsByte = Encoding.UTF8.GetBytes(mvcString);
            //消息包长度
            int sendLength = 4 + jsonsByte.Length;
            //定义数据包（消息长度4字节 + 消息体长度）
            byte[] MsgsByte = new byte[sendLength];
            //先存入消息长度数值4个字节
            BitConverter.GetBytes(IPAddress.HostToNetworkOrder(jsonsByte.Length)).CopyTo(MsgsByte, 0);
            //然后存入信息体字节
            jsonsByte.CopyTo(MsgsByte, 4);
            AddRange(SendBuffList, MsgsByte, MsgsByte.Length);
            while (sendLength > 0)
            {
                try
                {
                    if (sendLength <= BufferSize)
                    {
                        byte[] temBytes = new byte[sendLength];
                        CutTo(SendBuffList, temBytes, 0, sendLength);
                        Socket.BeginSend(temBytes, 0, temBytes.Length, 0, new AsyncCallback(this.SendCallback), Socket);
                        sendLength = 0;
                    }
                    else
                    {
                        byte[] temBytes = new byte[BufferSize];
                        CutTo(SendBuffList, temBytes, 0, BufferSize);
                        sendLength -= BufferSize;
                        Socket.BeginSend(temBytes, 0, temBytes.Length, 0, new AsyncCallback(this.SendCallback), Socket);
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine(GetCurrentTime() + ex.ToString());
                    OnDisconnect(Socket);
                }
            }

        }
        private void SendCallback(IAsyncResult ar)
        {
            try
            {
                Socket client = (Socket)ar.AsyncState;
                int bytesSent = client.EndSend(ar);
                Console.WriteLine(GetCurrentTime() + " Sent {0} bytes to clinet.", bytesSent);
            }
            catch (Exception ex)
            {
                Console.WriteLine(GetCurrentTime() + ex.ToString());
            }
        }
        #endregion

        #region
        ///获得服务器当前时间
        private string GetCurrentTime()
        {
            string cuurentTime = "";
            cuurentTime = DateTime.Now.ToString("yyyy/MM/dd HH:mm:ss.fffff");
            return cuurentTime;
        }
        /// 抽象方法 接口
        public void OnDisconnect()
        {
            if (noClose == false)
            {
                noClose = true;
                IsRunning = false;
                OnDisconnect(Socket);
            }
        }
        public abstract void OnConnect(Socket socket);
        public abstract void OnDisconnect(Socket socket);
        public abstract void OnTransferParameter(string mvcString, Socket socket);
        #endregion

    }
}
