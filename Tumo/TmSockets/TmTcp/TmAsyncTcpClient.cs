using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Timers;

namespace Tumo
{
    public abstract class TmAsyncTcpClient : TmOutTcp
    {      
        #region Methods Callbacks ///接收参数消息
        public void StartConnect()
        {
            try
            {
                //开始连接
                netSocket.BeginConnect(new IPEndPoint(address, Port), new AsyncCallback(this.ConnectCallback), netSocket);
                IsRunning = true;
            }
            catch (Exception ex)
            {
                netSocket.Close();
                IsRunning = false;
                Console.WriteLine(ex.ToString());
            }
        }
        private void ConnectCallback(IAsyncResult ar)
        {
            if (IsRunning)
            {
                //创建一个Socket接收传递过来的TmSocket
                Socket tcpSocket = (Socket)ar.AsyncState;
                try
                {
                    //得到成功的连接
                    tcpSocket.EndConnect(ar);
                    ///触发事件///创建一个方法接收peerSocket (在方法里创建一个peer来处理读取数据//开始接受来自该客户端的数据)
                    TmReceiveSocket(tcpSocket);
                    Console.WriteLine("{0} 连接服务器成功 {1}", TmTimerTool.GetCurrentTime(), tcpSocket.RemoteEndPoint.ToString());
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.ToString());
                }
            }
        }
        public void TmReceiveSocket(Socket socket)
        {
            ///创建一个TClient接收socket            
            new TClient().BeginReceiveMessage(socket);
        }
        #endregion

        #region ///接收参数消息的抽象方法
        public override void OnSendMvcParameters()
        {
            try
            {
                while (SendParameters.Count > 0)
                {
                    TmParameter mvc = SendParameters.Dequeue();
                    ///用Json将参数（MvcParameter）,序列化转换成字符串（string）
                    string mvcJsons = TmJson.ToString<TmParameter>(mvc);
                    if (TClient != null)
                    {
                        TClient.SendString(mvcJsons);
                    }
                    else
                    {
                        TClient = new TClient();
                        Console.WriteLine(TmTimerTool.GetCurrentTime() + " TClient is Null. {0}", "new TClient() 重新连接。");
                    }
                }
            }
            catch(Exception ex)
            {
                Console.WriteLine(TmTimerTool.GetCurrentTime() + " SendMvcParameters: " + ex.Message);
            }
        }
        #endregion

    }
}
