using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Timers;

namespace Tumo
{
    public class TmAsyncTcpServer
    {
        #region /// 静态单列模式        
        private static TmAsyncTcpServer _instance;
        public static TmAsyncTcpServer Instance { get => _instance; }
        #endregion

        #region Properties
        public string IpString { get; set; }                      //监听的IP地址  
        public int Port { get; set; }                             //监听的端口  
        public int MaxListenCount { get; set; }                   //服务器程序允许的最大客户端连接数  
        private bool isRunning { get; set; }                       //服务器是否正在运行
        private IPAddress address { get; set; }                   //监听的IP地址  
        private Socket serverSocket { get; set; }                 //服务器使用的异步socket   
        public Queue<Socket> WaitingSockets = new Queue<Socket>();  
        public Dictionary<string, TPeer> TPeers { get; set; } = new Dictionary<string, TPeer>();
        public Queue<MvcParameter> RecvParameters { get; set; } = new Queue<MvcParameter>();
        private Queue<MvcParameter> SendParameters { get; set; } = new Queue<MvcParameter>();
<<<<<<< HEAD
=======
        private int ValTime = 20;
        private Timer TmTimer;
>>>>>>> 07a544ffdca5ce83fc000e9205c588c3cc349ae8
        #endregion

        #region Constructor ///构造函数 ///初始化方法
        public TmAsyncTcpServer()
        {
            _instance = this;
<<<<<<< HEAD
=======
            TumoTimer(ValTime);
>>>>>>> 07a544ffdca5ce83fc000e9205c588c3cc349ae8
        }
        
        public void Init()
        {
            address = IPAddress.Parse(IpString);
            serverSocket = new Socket(address.AddressFamily, SocketType.Stream, ProtocolType.Tcp);
        }

        public void Init(string ipString, int port, int maxListenCount)
        {
            this.IpString = ipString;
            this.Port = port;
            this.MaxListenCount = maxListenCount;
            address = IPAddress.Parse(ipString);
            serverSocket = new Socket(address.AddressFamily, SocketType.Stream, ProtocolType.Tcp);
        }
        #endregion

        #region Methods Callbacks ///启动服务 ///接收参数消息      
        public void StartListen()
        {
            if (!isRunning)
            {
                serverSocket.Bind(new IPEndPoint(this.address, this.Port));
                serverSocket.Listen(MaxListenCount);
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

        private void TmReceiveSocket(Socket socket)
        {
            ///限制监听数量
            if (TPeers.Count >= MaxListenCount)
            {
                ///触发事件///在线排队等待
                WaitingSockets.Enqueue(socket);
            }
            else
            {
                ///创建一个TPeer接收socket
                new TPeer().BeginReceiveMessage(socket);
            }
        }
        #endregion

        #region ///发送参数信息
        public void SendMvc(MvcParameter mvc)
        {
            SendParameters.Enqueue(mvc);
            SendMvcParameters();
        }

        private void SendMvcParameters()
        {
            while (SendParameters.Count > 0)
            {
                MvcParameter mvc = SendParameters.Dequeue();
                ///用Json将参数（MvcParameter）,序列化转换成字符串（string）
                string mvcJsons = MvcTool.ToString<MvcParameter>(mvc);
                TPeer tpeer;
                TPeers.TryGetValue(mvc.Endpoint, out tpeer);
                if (tpeer != null)
                {
                    tpeer.SendString(mvcJsons);
                }
                else
                {
                    Console.WriteLine("没找TPeer，用Endpoint: " + mvc.Endpoint);
                }
            }
        }
        #endregion
<<<<<<< HEAD
             
=======

        #region ///时钟20毫秒一次 TmUpdate
        void TumoTimer(int ValTime)
        {
            TmTimer = new Timer();                                         //实例化Timer类，在括号里设置间隔时间,单位为毫秒；
            TmTimer.Elapsed += new ElapsedEventHandler(OnTimerEvent);      //到达时间的时候执行事件；
            TmTimer.Interval = ValTime;                                    //事件执行间隔时间1000毫秒；
            TmTimer.Enabled = true;                                        //是否执行事件System.Timers.Timer.Elapsed；
            TmTimer.AutoReset = true;                                      //设置是否循环执行，是执行一次（false）还是一直执行(true)；
        }
        // 当时间发生的时候需要进行的逻辑处理等    // 在这里仅仅是一种方式，可以实现这样的方式很多    
        void OnTimerEvent(object source, ElapsedEventArgs time)
        {
            TmUpdate(time);
        }

        public abstract void TmUpdate(ElapsedEventArgs time);
        #endregion
>>>>>>> 07a544ffdca5ce83fc000e9205c588c3cc349ae8

    }
}
