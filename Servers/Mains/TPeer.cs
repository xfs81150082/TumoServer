using Tumo.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using Tumo;
using Servers.Gates;

namespace Servers
{
    public class TPeer : TmAsyncTcpSession
    {
        public User User { get; set; }                                    //登录用户
        public Roler Player { get; set; }                                 //当前角色
        private bool isClose { get; set; } = false;

        public TPeer() { }       
        public void SendMsg(MvcParameter mvc)
        {
            //用Json将参数（MvcParameter）,序列化转换成字符串（string）
            string mvcJsons = MvcTool.ToString<MvcParameter>(mvc);
            SendString(mvcJsons);
        }
        public override void OnTransferParameter(string mvcString, Socket socket)
        {
            /////将字符串string,用json反序列化转换成MvcParameter参数
            MvcParameter mvc = MvcTool.ToObject<MvcParameter>(mvcString);
            mvc.Endpoint = socket.RemoteEndPoint.ToString();
            TumoGate.Instance.OnTransferParameter(mvc);
        }
        public override void OnConnect(Socket socket)
        {
            //显示与客户端连接
            Console.WriteLine("客户端{0}连接成功", socket.RemoteEndPoint);//客户端连接 
            TPeer peer = null;
            bool yes1 = TmServerHelper.Instance.TcpPeers.TryGetValue(socket.RemoteEndPoint.ToString(), out peer);
            if (yes1 != true)
            {
                //peers已经加入字典
                TmServerHelper.Instance.TcpPeers.Add(socket.RemoteEndPoint.ToString(), this);
                Console.WriteLine(TmServerHelper.Instance.GetCurrentTime() + ":" + "Session:" + socket.RemoteEndPoint + "...已经加入字典");
            }
            ////显示客户端群中的客户端数量
            Console.WriteLine(TmServerHelper.Instance.GetCurrentTime() + ". TcpPeers Count:" + TmServerHelper.Instance.TcpPeers.Count);
        }
        public override void OnDisconnect(Socket socket)
        {
            if (TmServerHelper.Instance.TcpPeers.Count > 0)
            {
                TPeer temSession = null;
                bool yes1 = TmServerHelper.Instance.TcpPeers.TryGetValue(socket.RemoteEndPoint.ToString(), out temSession);
                if (yes1)
                {
                    //从peers字典中删除
                    TmServerHelper.Instance.TcpPeers.Remove(socket.RemoteEndPoint.ToString());
                }
                Console.WriteLine(TmServerHelper.Instance.GetCurrentTime() + ":" + "一个客户端:已经中断连接");
            }
            //显示客户端群中的客户端数量
            Console.WriteLine(TmServerHelper.Instance.GetCurrentTime() + " TcpPeers Count:" + TmServerHelper.Instance.TcpPeers.Count);
            if (isClose == false)
            {
                isClose = true;
                //关闭之前先Shutdown
                socket.Shutdown(SocketShutdown.Both);
                socket.Close();
                socket = null;
            }
            //关闭PeerCD
            MvcParameter mvc = MvcTool.ToParameter(EightCode.Node, NineCode.Handler, TenCode.Engineer, ElevenCode.RemoveHeartBeat);
            TumoGate.Instance.OnTransferParameter(mvc);
        }

        private void TryCloseSocket(Socket socket)
        {
            try
            {
                while (true)
                {
                    //Thread.Sleep(1500);
                    //socket.Send(HttpServer.BYTES_CRLF); //发送自定义的字节，如果客户端关闭出现SocketException，然后关闭服务端Socket
                    if (socket == null)
                        break;
                }
            }
            catch (SocketException)
            {
                CloseSocket(socket);
            }
        }
               
        private void CloseSocket(Socket socket)
        {
            if (socket != null)
            {
                socket.Shutdown(SocketShutdown.Both);
                socket.Close();
                socket = null;
                //if (socket.TraceInConsole)
                //{
                //    Console.WriteLine("Close socket.");
                //}
            }
        }


    }
}
