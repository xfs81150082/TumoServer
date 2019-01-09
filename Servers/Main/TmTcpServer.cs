using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Timers;
using Tumo;
using Servers.Gates;

namespace Servers
{
    class TmTcpServer : TmAsyncTcpServer
    {
        public TmTcpServer()
        {
            //IpString = "172.17.16.15";
            IpString = "127.0.0.1";
            Port = 8115;
            MaxListenCount = 10;
            Init();
        }

        public override void TmUpdate(ElapsedEventArgs time)
        {
             while (RecvParameters.Count > 0)
            {
                MvcParameter mvc = RecvParameters.Dequeue();
                TumoGate.Instance.OnTransferParameter(mvc);
                Console.WriteLine("RecvParameters: " + RecvParameters.Count);
            }
        }

    }
}
