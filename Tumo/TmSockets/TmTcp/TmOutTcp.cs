﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;

namespace Tumo
{
    public abstract class TmOutTcp : TmSystem
    {
        private static TmOutTcp _instance;
        public static TmOutTcp Instance { get => _instance;  }
        public TmOutTcp() { _instance = this; }

        #region Properties
        public string IpString { get; set; }                      //监听的IP地址  
        public int Port { get; set; }                             //监听的端口  
        public int MaxListenCount { get; set; }                   //服务器程序允许的最大客户端连接数  
        public bool IsRunning { get; set; }                       //服务器是否正在运行
        protected IPAddress address { get; set; }                   //监听的IP地址  
        public Socket netSocket { get; set; }                 //服务器使用的异步socket   
        public Queue<Socket> WaitingSockets = new Queue<Socket>();
        public Dictionary<string, TmAsyncTcpSession> TPeers { get; set; } = new Dictionary<string, TmAsyncTcpSession>();
        public TmAsyncTcpSession TClient { get; set; }
        public Queue<TmParameter> RecvParameters { get; set; } = new Queue<TmParameter>();
        protected Queue<TmParameter> SendParameters { get; set; } = new Queue<TmParameter>();
        #endregion
        #region Constructor ///构造函数 ///初始化方法
        public void Init()
        {
            address = IPAddress.Parse(IpString);
            netSocket = new Socket(address.AddressFamily, SocketType.Stream, ProtocolType.Tcp);
        }
        public void Init(string ipString, int port)
        {
            this.IpString = ipString;
            this.Port = port;
            address = IPAddress.Parse(ipString);
            netSocket = new Socket(address.AddressFamily, SocketType.Stream, ProtocolType.Tcp);
        }
        public void Init(string ipString, int port, int maxListenCount)
        {
            this.IpString = ipString;
            this.Port = port;
            this.MaxListenCount = maxListenCount;
            address = IPAddress.Parse(ipString);
            netSocket = new Socket(address.AddressFamily, SocketType.Stream, ProtocolType.Tcp);
        }
        #endregion

        #region ///发送参数信息
        public void SendMvc(TmParameter mvc)
        {
            SendParameters.Enqueue(mvc);
            OnSendMvcParameters();
        }
        public abstract void OnSendMvcParameters();
        #endregion

        public TmAsyncTcpSession TPeer(string ecsid)
        {
            TmAsyncTcpSession peer;
            TPeers.TryGetValue(ecsid, out peer);
            if (peer != null)
            {
                return peer;
            }
            else
            {
                Console.WriteLine(TmTimerTool.GetCurrentTime() + " 没找TPeer，用Key: " + ecsid);
                return null;
            }
        }

    }
}
