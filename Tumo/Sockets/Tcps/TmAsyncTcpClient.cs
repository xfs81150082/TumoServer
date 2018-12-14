using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Sockets;
using System.Text;

namespace Tumo
{
    public abstract class TmAsyncTcpClient
    {
        #region Properties
        private string ipString { get; set; }            //监听的IP地址  
        private int port { get; set; }                   //监听的端口  
        private bool isRunning { get; set; }             //服务器是否正在运行
        private IPAddress address { get; set; }          //连接的IP地址  
        private Socket clientSocket { get; set; }
        #endregion

        #region Constructor      
        public TmAsyncTcpClient()   {  }
        public void Init(string ipString, int port)
        {
            this.ipString = ipString;
            this.port = port;
            address = IPAddress.Parse(ipString);
            clientSocket = new Socket(address.AddressFamily, SocketType.Stream, ProtocolType.Tcp);
        }
        #endregion

        #region Methods
        public void StartConnect()
        {
            try
            {
                //开始连接
                clientSocket.BeginConnect(new IPEndPoint(address, port), new AsyncCallback(this.ConnectCallback), clientSocket);
                isRunning = true;
            }
            catch (Exception ex)
            {
                clientSocket.Close();
                isRunning = false;
                Console.WriteLine(ex.ToString());
            }
        }
        #endregion

        #region Callbacks
        private void ConnectCallback(IAsyncResult ar)
        {
            //创建一个Socket接收传递过来的TmSocket
            Socket tcpSocket = (Socket)ar.AsyncState;
            try
            {
                //得到成功的连接
                tcpSocket.EndConnect(ar);
                ///触发事件///创建一个方法接收peerSocket (在方法里创建一个peer来处理读取数据//开始接受来自该客户端的数据)
                TmReceiveSocket(tcpSocket);
                Console.WriteLine("连接服务器成功{0}", tcpSocket.RemoteEndPoint.ToString());
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }
        }
        #endregion
        public abstract void TmReceiveSocket(Socket socket);




    }
}
