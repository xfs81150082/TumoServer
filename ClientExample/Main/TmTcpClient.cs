using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using Tumo;

namespace ClientExample
{
    public class TmTcpClient : TmAsyncTcpClient
    {
        //private string ipString = "172.17.16.15";
        private string ipString = "127.0.0.1";
        private int port = 8115;
        public TClient TClient { get; set; }
        public TmTcpClient()
        {
            Init(ipString, port);
        }     

        public override void TmReceiveSocket(Socket socket)
        {
            ///创建一个TcpPeer接收socket
            TClient = new TClient();
            TClient.BeginReceiveMessage(socket);
        }
    }

}
