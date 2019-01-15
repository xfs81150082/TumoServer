using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Timers;
using Tumo;

namespace Servers
{
    public class TmTcpServer : TmAsyncTcpServer
    {
        public TmTcpServer()  {   }
        public TmTcpServer(string ipString, int port, int maxListenCount)
        {
            IpString = ipString;
            Port = port;
            MaxListenCount = maxListenCount;
        }

        public override void TmUpdate()
        {
            ServerStart();
            ServerRecvParameters();
        }
        void ServerStart()
        {
            if (!IsRunning)
            {
                this.Init("127.0.0.1", 8115, 10);
                this.StartListen();
            }
        }
        void ServerRecvParameters()
        {
            try
            {
                while (RecvParameters.Count > 0)
                {
                    MvcParameter mvc = RecvParameters.Dequeue();
                    if (TumoGate.Instance != null)
                    {
                        TumoGate.Instance.OnTransferParameter(mvc);
                        Console.WriteLine(TmTimerTool.GetCurrentTime() + " RecvParameters: " + RecvParameters.Count);
                    }
                    else
                    {
                        //RecvParameters.Enqueue(mvc);
                        Console.WriteLine(TmTimerTool.GetCurrentTime() + " TumoGate is null.");
                        break;
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(TmTimerTool.GetCurrentTime() + ex.Message);
            }
        }

      
    }
}
