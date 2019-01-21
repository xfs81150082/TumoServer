using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;

namespace Tumo
{
    public class TmOutClient : TmComponent
    {
        public string IpString { get; set; }                      //监听的IP地址  
        public int Port { get; set; }                             //监听的端口  
        public int MaxListenCount { get; set; }                   //服务器程序允许的最大客户端连接数  
        public bool IsRunning { get; set; }                       //服务器是否正在运行
        protected IPAddress address { get; set; }                 //监听的IP地址  
        public Socket netSocket { get; set; }                     //服务器使用的异步socket   
        public TmTcpSession TClient { get; set; } 
    }
}
