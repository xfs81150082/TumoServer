using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Servers.Peers
{
    class SocketListen
    {
        //创建一个服务端套接字，用于监听客户端套接字连接，并进行三次握手//定义一个套接字用于监听客户端发来的消息，包含三个参数（IP4寻址协议，流式连接，Tcp协议）        
        Socket socketwatch = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);

        public SocketListen()
        {
            Init(new object());
        }

        void Init(object obj)
        {
            //监听列队长度
            int listenCount = 10;
            //string ipstr = "172.17.16.15";
            string ipstr = "127.0.0.1";
            int port = 2600;
            //服务端发送信息需要一个IP地址和端口号
            IPAddress address = IPAddress.Parse(ipstr);
            //将IP地址和端口号绑定到网络节点point上
            IPEndPoint point = new IPEndPoint(address, port);
            //此端口专门用来监听的

            //监听绑定的网络节点
            socketwatch.Bind(point);

            //将套接字的监听队列长度限制为listenCount = ? 个。 
            socketwatch.Listen(listenCount);

            //负责监听客户端的线程:创建一个监听线程//创建一个通信线程
            ParameterizedThreadStart mypts = new ParameterizedThreadStart(WatchConnecting);
            Thread thread = new Thread(mypts);

            //将窗体线程设置为与后台同步，随着主线程结束而结束 //设置为后台线程，随着主线程退出而退出 
            thread.IsBackground = true;

            //启动线程
            thread.Start(socketwatch);

            Console.WriteLine("服务器时间:" + PeerHelper.Instance.GetCurrentTime() + "\r\n ");
            Console.WriteLine("开启监听..." + "服务器IP端口号：" + point.ToString() + "\r\n");
            Console.WriteLine("点击输入任意数据回车退出程序...\r\n");
        }

        //监听客户端发来的请求
        void WatchConnecting(object obj)
        {
            Socket gameSocket = obj as Socket;
            //当客户端连接时，即时创建一个代理服务端套接字，与客户端套接字通信。（个人备注）
            //此套接字是不停的产生新的或变化着 （个人备注）
            Socket connection = null;
            while (true)
            {
                try
                {
                    //当客户端连接时，创建代理服务端套接字 与客户端套接字通信 （个人备注）
                    connection = gameSocket.Accept();
                    //创建一个通信线程 接收信息
                    BuildReceiveMsgThread(connection);

                }
                catch (Exception ex)
                {
                    //提示套接字监听异常 
                    Console.WriteLine(ex.Message);
                    break;
                }
            }
        }

        //创建一个通信线程 接收信息
        void BuildReceiveMsgThread(object obj)
        {
            Socket socket = obj as Socket;
            //创建一个通信线程
            ParameterizedThreadStart pts = new ParameterizedThreadStart(new Peer().ReceiveMsg);
            Thread thread = new Thread(pts);
            //设置为后台线程，随着主线程退出而退出 
            thread.IsBackground = true;
            //启动线程
            thread.Start(socket);
        }
            

    }
}
