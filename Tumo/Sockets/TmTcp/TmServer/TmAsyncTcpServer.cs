using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;

namespace Tumo
{
    public abstract class TmAsyncTcpServer
    {
        #region Properties
        private string ipString { get; set; }                      //监听的IP地址  
        private int port { get; set; }                             //监听的端口  
        private int maxListenCount { get; set; }                   //服务器程序允许的最大客户端连接数  
        private bool isRunning { get; set; }                       //服务器是否正在运行
        private IPAddress address { get; set; }                   //监听的IP地址  
        private Socket serverSocket { get; set; }                 //服务器使用的异步socket   
        #endregion



        #region Constructor
        public TmAsyncTcpServer()  { }
        public void Init(string ipString, int port, int maxListenCount)
        {
            this.ipString = ipString;
            this.port = port;
            this.maxListenCount = maxListenCount;
            address = IPAddress.Parse(ipString);
            serverSocket = new Socket(address.AddressFamily, SocketType.Stream, ProtocolType.Tcp);
        }
        #endregion

        #region Methods Callbacks //启动服务       
        public void StartListen()
        {
            if (!isRunning)
            {
                serverSocket.Bind(new IPEndPoint(this.address, this.port));
                serverSocket.Listen(maxListenCount);
                serverSocket.BeginAccept(new AsyncCallback(this.AcceptCallback), serverSocket);
                Console.WriteLine("服务启动，监听{0}成功", serverSocket.LocalEndPoint);
                isRunning = true;
            }
        }
        private void AcceptCallback(IAsyncResult ar)
        {
            if (isRunning)
            {
                Socket server = (Socket)ar.AsyncState;
                Socket peerSocket = server.EndAccept(ar);
                ///触发事件///创建一个方法接收peerSocket (在方法里创建一个peer来处理读取数据//开始接受来自该客户端的数据)
                TmReceiveSocket(peerSocket);
                ///接受下一个请求  
                server.BeginAccept(new AsyncCallback(this.AcceptCallback), server);
            }
        }
        #endregion 
        public abstract void TmReceiveSocket(Socket socket);



    }
}
