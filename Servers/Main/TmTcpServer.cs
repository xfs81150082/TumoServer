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
        private string ipString = "127.0.0.1";
        private int port = 8115;
        private int maxListenCount = 10;
        public TmTcpServer()
        {
            Init(ipString, port, maxListenCount);
        }      

        public override void TmReceiveSocket(Socket socket)
        {
            ///限制监听数量
            if (TmServerHelper.Instance.TcpPeers.Count >= maxListenCount) 
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
