using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Timers;
using Tumo;

namespace Servers
{
    public class TmServerSocket : TmSystem
    {
        public TmTcpServer TcpServer = null;
        public TmServerSocket()
        {
            TcpServer = new TmTcpServer();
        }
        public override void TmUpdate()
        {
            ServerStart();
            ServerRecvParameters();
        }
        void ServerStart()
        {
            if (!TcpServer.IsRunning)
            {
                TcpServer.Init("127.0.0.1", 8115, 10);
                TcpServer.StartListen();
            }
        }
        void ServerRecvParameters()
        {
            try
            {
                while (TcpServer.RecvParameters.Count > 0)
                {
                    TmParameter mvc = TcpServer.RecvParameters.Dequeue();
                    if (TmGate.Instance != null)
                    {
                        TmGate.Instance.OnTransferParameter(mvc);
                        Console.WriteLine(TmTimerTool.CurrentTime() + " RecvParameters: " + TcpServer.RecvParameters.Count);
                    }
                    else
                    {
                        //RecvParameters.Enqueue(mvc);
                        Console.WriteLine(TmTimerTool.CurrentTime() + " TumoGate is null.");
                        break;
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(TmTimerTool.CurrentTime() + ex.Message);
            }
        }
    }
}
