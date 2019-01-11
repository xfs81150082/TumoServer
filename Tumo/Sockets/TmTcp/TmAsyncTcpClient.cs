using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Timers;

namespace Tumo
{
    public class TmAsyncTcpClient
    {
        #region 静态单列模式
        private static TmAsyncTcpClient _instance;
        public static TmAsyncTcpClient Instance { get => _instance; }
        #endregion

        #region Properties
        public string IpString { get; set; }            //监听的IP地址  
        public int Port { get; set; }                   //监听的端口  
        private bool isRunning { get; set; }             //服务器是否正在运行
        private IPAddress address { get; set; }          //连接的IP地址  
        private Socket clientSocket { get; set; }
        public TClient TClient { get; set; }
        public CoolDownItem CDItem { get; set; }
        public Queue<MvcParameter> RecvParameters { get; set; } = new Queue<MvcParameter>();
        private Queue<MvcParameter> SendParameters { get; set; } = new Queue<MvcParameter>();
        #endregion

        #region Constructor      
        public TmAsyncTcpClient()
        {
            _instance = this;
        }

        public TmAsyncTcpClient(string ipString, int port)
        {
            _instance = this;
            this.IpString = ipString;
            this.Port = port;
        }

        public void Init()
        {
            address = IPAddress.Parse(IpString);
            clientSocket = new Socket(address.AddressFamily, SocketType.Stream, ProtocolType.Tcp);
        }

        public void Init(string ipString, int port)
        {
            this.IpString = ipString;
            this.Port = port;
            address = IPAddress.Parse(IpString);
            clientSocket = new Socket(address.AddressFamily, SocketType.Stream, ProtocolType.Tcp);
        }
        #endregion

        #region Methods Callbacks ///接收参数消息
        public void StartConnect()
        {
            try
            {
                //开始连接
                clientSocket.BeginConnect(new IPEndPoint(address, Port), new AsyncCallback(this.ConnectCallback), clientSocket);
                isRunning = true;
            }
            catch (Exception ex)
            {
                clientSocket.Close();
                isRunning = false;
                Console.WriteLine(ex.ToString());
            }
        }
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
                Console.WriteLine("{0} 连接服务器成功{1}", TimerTool.GetCurrentTime(), tcpSocket.RemoteEndPoint.ToString());
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }
        }
        public void TmReceiveSocket(Socket socket)
        {
            ///创建一个TcpPeer接收socket
            if (TClient != null)
            {
                TClient.OnDisconnect();
                TClient = null;
            }
            TClient = new TClient();
            TClient.BeginReceiveMessage(socket);
        }
        #endregion

        #region ///发送参数消息
        public void SendMvc(MvcParameter mvc)
        {
            SendParameters.Enqueue(mvc);
            SendMvcParameters();
        }

        private void SendMvcParameters()
        {
            while (SendParameters.Count>0)
            {
                MvcParameter mvc = SendParameters.Dequeue();
                ///用Json将参数（MvcParameter）,序列化转换成字符串（string）
                string mvcJsons = MvcTool.ToString<MvcParameter>(mvc);
                TClient.SendString(mvcJsons);
            }
        }
        #endregion

    }
}
