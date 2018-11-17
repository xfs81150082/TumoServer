using CommonBase;
using CommonBase.Models;
using CommonBase.Mvc;
using CommonBase.Tools;
using System;
using System.Net;
using System.Net.Sockets;
using System.Text;
using CommonBase.Eunms;
using Servers.Gates;
using Servers.Sences.Rolers.Mysqlers;
using Servers.Sences.Rolers.Models;

namespace Servers.Peers
{
    public class Peer
    {
        public Socket Socket = null;                   //创建一个套接字，用于储藏代理服务端套接字，与客户端通信
        public User User { get; set; }                 //登录用户
        public Player Player { get; set; }             //当前角色SoulItem

        private bool IsClosed = false;                 //socket有没有close过
        public Peer() { }                //构造函数
        //接收客户端发来的信息，和发送给客户端信息，客户端套接字对象 
        public void ReceiveMsg(object obj)
        {
            //获得并储藏代理服务端套接字
            Socket = obj as Socket;          
            //添加客户端peer信息//显示peers字典中的客户端数量
            OnConnected();
            while (true)
            {
                //创建一个内存缓冲区，其大小为1024*1024字节  即1M 
                byte[] serverRecMsg = new byte[1024 * 1024];
                try
                {
                    //将接收到的信息(字节数组byte[])存入到内存缓冲区，并返回其字节数组的长度
                    int length = Socket.Receive(serverRecMsg);
                    //将服务器端接受到的字节数组byte[]，转换为人可以读懂的字符串(string)
                    string strSRecMsg = Encoding.UTF8.GetString(serverRecMsg, 0, length);
                    //将字符串string,用json反序列化转换成MvcParameter参数
                    MvcParameter mvc = MvcTool.ToObject<MvcParameter>(strSRecMsg);
                    //储存Username、RolerId、SoulItem和Socket到Peer和Mvc,便于识别和调用Peer和mvc；使从本Peer出去mvc都打上印记
                    mvc.Endpoint = Socket.RemoteEndPoint.ToString();
                    if (User != null) { mvc.Username = User.Username; }
                    if (Player != null) { mvc.RolerId = Player.SoulItem.Id.ToString(); }
                    Log.WriteLine("mvc.Endpoint: " + mvc.Endpoint + " mvc.Username: " + mvc.Username + " mvc.RolerId: " + mvc.RolerId);                    
                    //这个方法用来处理参数Mvc，并让结果给客户端响应（当客户端发起请求时调用）//这个方法用来处理参数Mvc，并让结果给客户端响应。
                    TumoGate.Instance.OnTransferParameter(mvc);
                }
                catch (Exception ex)
                {
                    //发生异常时调用//与服务器断开时调用
                    OnDisconnect();
                    break;
                }
            }
        }            
        //发送信息给客户端
        public void SendMsg(object obj)
        {
            MvcParameter mvc = obj as MvcParameter;            
            //用Json将参数（MvcParameter）,序列化转换成字符串（string）
            string jsons = MvcTool.ToString<MvcParameter>(mvc);
            //将字符串(string)转换成字节(byte)，并发送给客户端
            Socket.Send(Encoding.UTF8.GetBytes(jsons));
        }
        //添加客户端代理peer时调用
        void OnConnected()
        {
            PeerHelper.Instance.OnConnected(this);
        }
        //异常后调用
        public void OnDisconnect()
        {
            if (IsClosed == false)
            {
                IsClosed = true;
                PeerHelper.Instance.OnDisconnect(this);
            }
        }


    }
}