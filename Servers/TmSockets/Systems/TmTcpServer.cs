using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Timers;
using Tumo;

namespace Servers
{
    public class TmTcpServer : TmSystem
    {
        public TmTcpServer()  {   }      

        public override void TmUpdate()
        {
            ServerStart();
            ServerRecvParameters();
        }

        private bool isCon = false;
        void ServerStart()
        {
            if (!TmAsyncTcpServer.Instance.IsRunning && isCon == false)
            {
                TmAsyncTcpServer.Instance.Init("127.0.0.1", 8115, 10);
                TmAsyncTcpServer.Instance.StartListen();
                isCon = true;
                isCon = TmAsyncTcpServer.Instance.IsRunning;
                Console.WriteLine(TmTimerTool.CurrentTime() + " IsRunning: " + TmAsyncTcpServer.Instance.IsRunning);
            }
        }
        void ServerRecvParameters()
        {
            try
            {
                while (TmAsyncTcpServer.Instance.RecvParameters.Count > 0)
                {
                    TmRequest mvc = TmAsyncTcpServer.Instance.RecvParameters.Dequeue();
                    if (TmGate.Instance != null)
                    {
                        TmGate.Instance.OnTransferParameter(mvc);
                        Console.WriteLine(TmTimerTool.GetCurrentTime() + " RecvParameters: " + TmAsyncTcpServer.Instance.RecvParameters.Count);
                    }
                    else
                    {
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
