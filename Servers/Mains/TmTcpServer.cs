using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using Tumo;

namespace Servers
{
    class TmTcpServer : TmAsyncTcpServer
    {
        private string IpString = "172.17.16.15";
        private int Port = 8115;
        private int MaxListenCount = 10;
        public TmTcpServer()
        {
            Init(IpString, Port, MaxListenCount);
        }      

        public override void TmReceiveSocket(Socket socket)
        {
            ///限制监听数量
            if (TmServerHelper.Instance.TcpPeers.Count >= MaxListenCount)
            {
                ///触发事件///在线排队等待
                TmServerHelper.Instance.LineUpWait.Add(socket);
            }
            else
            {
                ///创建一个TcpPeer接收socket
                new TPeer().BeginReceiveMessage(socket);
            }
        }


    }
}
