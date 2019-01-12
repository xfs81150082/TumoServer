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
        public int ValTime = 20;
        private Timer Timer;

        public TmTcpServer()
        {
            TumoTimer(ValTime);
            //IpString = "172.17.16.15";
            IpString = "127.0.0.1";
            Port = 8115;
            MaxListenCount = 10;
            Init();
        }

        public void TumoTimer(int time)
        {
            Timer = new Timer();                                         //实例化Timer类，在括号里设置间隔时间,单位为毫秒；
            Timer.Elapsed += new ElapsedEventHandler(TmUpdate);          //到达时间的时候执行事件；
            Timer.Interval = ValTime;                                    //事件执行间隔时间1000毫秒；
            Timer.Enabled = true;                                        //是否执行事件System.Timers.Timer.Elapsed；
            Timer.AutoReset = true;                                      //设置是否循环执行，是执行一次（false）还是一直执行(true)；
        }

        public void TmUpdate(object source, ElapsedEventArgs time)
        {
             while (RecvParameters.Count > 0)
            {
                MvcParameter mvc = RecvParameters.Dequeue();
                TumoGate.Instance.OnTransferParameter(mvc);
                Console.WriteLine(TmTimer.GetCurrentTime() + " RecvParameters: " + RecvParameters.Count);
            }
        }
        #region PeerCD
        private int valTime = 4000;
        private int cdsCount = -1;
        void CheckPeersCD()
        {
            if (TmAsyncTcpServer.Instance.TPeers.Count != cdsCount)
            {
                cdsCount = TmAsyncTcpServer.Instance.TPeers.Count;
                Console.WriteLine(TmTimer.GetCurrentTime() + " PeerCD:心跳包每" + valTime / 1000 + "秒钟心跳一次(秒针:" + ela.SignalTime.Second + ", 毫秒针:" + ela.SignalTime.Millisecond + ")");
                TmLog.WriteLine(TmTimer.GetCurrentTime() + " EngineerTimer每" + valTime / 1000 + "秒钟心跳一次(秒针:" + ela.SignalTime.Second + ",毫秒针:" + ela.SignalTime.Millisecond + ")");
                //初始化服务器PeersCD字典
                if (TmAsyncTcpServer.Instance.TPeers.Count > 0)
                {
                    List<string> list1 = new List<string>(TmAsyncTcpServer.Instance.TPeers.Keys);
                    for (int i = 0; i < list1.Count; i++)
                    {
                        CoolDownItem cd1;
                        //bool yes = PeerCDItems.TryGetValue(list1[i], out cd1);
                        bool yes = TmAsyncTcpServer.Instance.CDItems.TryGetValue(list1[i], out cd1);
                        if (yes == false)
                        {
                            PeerCDItem cd2 = new PeerCDItem();
                            cd2.CdCount = 0;
                            cd2.CoolDown.MaxCdCount = 4;
                            cd2.Key = list1[i];
                            //PeerCDItems.Add(list1[i], cd2);
                            TmAsyncTcpServer.Instance.CDItems.Add(list1[i], cd2);
                        }
                    }
                }
                else
                {
                    if (TmAsyncTcpServer.Instance.CDItems.Count > 0)
                    {
                        TmAsyncTcpServer.Instance.CDItems.Clear();
                    }
                }
                Console.WriteLine(TmTimer.GetCurrentTime() + " PeerCDItems: " + TmAsyncTcpServer.Instance.CDItems.Count + "-" + TmAsyncTcpServer.Instance.TPeers.Count);
            }
        }
        void PeerSignIn(MvcParameter mvc)
        {
            CoolDownItem cd;
            TmAsyncTcpServer.Instance.CDItems.TryGetValue(mvc.Endpoint, out cd);
            if (cd != null)
            {
                cd.CdCount = 0;
            }
        }
        void RemovePeerCDItem(MvcParameter mvc)
        {
            if (TmAsyncTcpServer.Instance.CDItems.Count > 0)
            {
                CoolDownItem item;
                TmAsyncTcpServer.Instance.CDItems.TryGetValue(mvc.Endpoint, out item);
                if (item != null)
                {
                    item.Close();
                    TmAsyncTcpServer.Instance.CDItems.Remove(mvc.Endpoint);
                }
            }
        }
        #endregion

    }
}
