using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Timers;
using Tumo;

namespace ClientExample
{
    public class TmTcpClient : TmAsyncTcpClient 
    {
        public TmTcpClient() {  }
        public TmTcpClient(string ipString, int port)
        {
            IpString = ipString;
            Port = port;
        }
        public override void TmAwake()
        {

        }
        public override void TmUpdate()
        {
            ConnectToServer();
            ClientRecvParamers();
        }
        void ConnectToServer()
        {
            if (!IsConnecting)
            {
                this.Init("127.0.0.1", 8115);
                this.StartConnect();
                IsConnecting = true;
                Console.WriteLine(TmTimer.GetCurrentTime() + " Connecting...");
            }
        }
        void ClientRecvParamers()
        {
            try
            {
                while (RecvParameters.Count > 0)
                {
                    MvcParameter mvc = RecvParameters.Dequeue();
                    if (TumoConnect.Instance != null)
                    {
                        TumoConnect.Instance.OnTransferParameter(mvc); ///与客户端的接口函数
                        Console.WriteLine(TmTimer.GetCurrentTime() + " RecvParameters: " + RecvParameters.Count);
                    }
                    else
                    {
                        RecvParameters.Enqueue(mvc);
                        Console.WriteLine(TmTimer.GetCurrentTime() + " TumoConnect is null.");
                        break;
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(TmTimer.GetCurrentTime() + " " + ex.Message);
            }
        }///与客户端的接口函数

    }
}
