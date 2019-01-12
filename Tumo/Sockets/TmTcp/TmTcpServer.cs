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
        //public int ValTime = 20;
        private Timer Timer;

        public TmTcpServer()
        {
            //TumoTimer(ValTime);
            //IpString = "172.17.16.15";
            IpString = "127.0.0.1";
            Port = 8115;
            MaxListenCount = 10;
            Init();
        }

        //public void TumoTimer(int time)
        //{
        //    Timer = new Timer();                                         //实例化Timer类，在括号里设置间隔时间,单位为毫秒；
        //    Timer.Elapsed += new ElapsedEventHandler(TmUpdate);          //到达时间的时候执行事件；
        //    Timer.Interval = ValTime;                                    //事件执行间隔时间1000毫秒；
        //    Timer.Enabled = true;                                        //是否执行事件System.Timers.Timer.Elapsed；
        //    Timer.AutoReset = true;                                      //设置是否循环执行，是执行一次（false）还是一直执行(true)；
        //}
        public override void TmUpdate()
        {
            CheckPeersCD();
            TmRecvParameters();
        }
        public void TmRecvParameters()
        {
             while (RecvParameters.Count > 0)
            {
                MvcParameter mvc = RecvParameters.Dequeue();
                //TumoGate.Instance.OnTransferParameter(mvc);
                Console.WriteLine(TmTimer.GetCurrentTime() + " RecvParameters: " + RecvParameters.Count);
            }
        }
        #region PeerCD
        //private int valTime = 4000;
        private int cdsCount = -1;
       
        void CheckPeersCD()
        {
            if (TPeers.Count != cdsCount)
            {
                cdsCount = TPeers.Count;
                Console.WriteLine(TmTimer.GetCurrentTime() + " PeerCD:心跳包每" + ValTime  + "秒钟心跳一次(秒针:" + ")");
                TmLog.WriteLine(TmTimer.GetCurrentTime() + " EngineerTimer每" + ValTime  + "秒钟心跳一次(秒针:" + ")");
                //初始化服务器PeersCD字典
                if (TPeers.Count > 0)
                {
                    List<string> list1 = new List<string>(TPeers.Keys);
                    for (int i = 0; i < list1.Count; i++)
                    {
                        CoolDownItem cd1;
                        bool yes = CDItems.TryGetValue(list1[i], out cd1);
                        if (yes == false)
                        {
                            SessionCDItem cd2 = new SessionCDItem();
                            cd2.CdCount = 0;
                            cd2.CoolDown.MaxCdCount = 4;
                            cd2.Key = list1[i];
                            CDItems.Add(list1[i], cd2);
                        }
                    }
                }
                else
                {
                    if (CDItems.Count > 0)
                    {
                        CDItems.Clear();
                    }
                }
                Console.WriteLine(TmTimer.GetCurrentTime() + " PeerCDItems: " + CDItems.Count + "-" + TPeers.Count);
            }
        }

     
        #endregion

    }
}
