

using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Timers;
using Tumo;

namespace ClientExample
{
    public class TmTcpClient : Tumo.TmTcpClient 
    {
        public TmTcpClient() {  }     

        public override void TmUpdate()
        {
            ConnectToServer();
            ClientRecvParamers();
        }
        void ConnectToServer()
        {
            if (!IsRunning)
            {
                IsRunning = true;
                this.Init("127.0.0.1", 8115);
                this.StartConnect();
                Console.WriteLine(TmTimerTool.CurrentTime() + " Connecting...");
            }
        }
        void ClientRecvParamers()
        {
            try
            {
                while (RecvParameters.Count > 0)
                {
                    TmParameter mvc = RecvParameters.Dequeue();
                    if (TmConnect.Instance != null)
                    {
                        TmConnect.Instance.OnTransferParameter(mvc); ///与客户端的接口函数
                        Console.WriteLine(TmTimerTool.CurrentTime() + " RecvParameters: " + RecvParameters.Count);
                    }
                    else
                    {
                        //RecvParameters.Enqueue(mvc);
                        Console.WriteLine(TmTimerTool.CurrentTime() + " TumoConnect is null.");
                        break;
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(TmTimerTool.CurrentTime() + " " + ex.Message);
            }
        }

    
        ///与客户端的接口函数

    }
}
