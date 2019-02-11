using System;
using System.Collections.Generic;
using System.Net.Sockets;
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
                //TcpServer.Init("172.17.16.15", 8115, 10);
                TcpServer.StartListen();
            }
        }
        void ServerRecvParameters()
        {
            try
            {
                while (TcpServer.RecvParameters.Count > 0)
                {
                    TmParameter parameter = TcpServer.RecvParameters.Dequeue();
                    if (TmGateHandler.Instance != null)
                    {
                        TmGateHandler.Instance.OnTransferParameter(this, parameter);
                        Console.WriteLine(TmTimerTool.CurrentTime() + " RecvParameters: " + TcpServer.RecvParameters.Count);
                    }
                    else
                    {
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