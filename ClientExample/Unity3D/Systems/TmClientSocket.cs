﻿

using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Timers;
using Tumo;

namespace ClientExample
{
    public class TmClientSocket : TmSystem 
    {
        public TmTcpClient TmClient = null;
        public TmClientSocket()
        {
            TmClient = new TmTcpClient();
        }
        public override void TmUpdate()
        {
            ConnectToServer();
            ClientRecvParamers();
        }
        void ConnectToServer()
        {
            if (!TmClient.IsRunning)
            {
                TmClient.IsRunning = true;
                TmClient.Init("127.0.0.1", 8115);
                TmClient.StartConnect();
                Console.WriteLine(TmTimerTool.CurrentTime() + " Connecting...");
            }
        }
        void ClientRecvParamers()
        {
            try
            {
                while (TmClient.RecvParameters.Count > 0)
                {
                    TmParameter mvc = TmClient.RecvParameters.Dequeue();
                    if (TmConnect.Instance != null)
                    {
                        TmConnect.Instance.OnTransferParameter(mvc); ///与客户端的接口函数
                        Console.WriteLine(TmTimerTool.CurrentTime() + " RecvParameters: " + TmClient.RecvParameters.Count);
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