using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Timers;
using Tumo;

namespace ClientExample
{
    public class TmTcpClient : TmAsyncTcpClient , TmUpdate
    {
        //public int ValTime = 20;
        //private Timer TmTimer;

        public TmTcpClient()
        {
            //TumoTimer(ValTime);
            //IpString = "172.17.16.15";
            IpString = "127.0.0.1";
            Port = 8115;
            Init();
        }
<<<<<<< HEAD

        public void TumoTimer(int ValTime)
        {
            TmTimer = new Timer();                                         //实例化Timer类，在括号里设置间隔时间,单位为毫秒；
            TmTimer.Elapsed += new ElapsedEventHandler(TmUpdate);          //到达时间的时候执行事件；
            TmTimer.Interval = ValTime;                                    //事件执行间隔时间1000毫秒；
            TmTimer.Enabled = true;                                        //是否执行事件System.Timers.Timer.Elapsed；
            TmTimer.AutoReset = true;                                      //设置是否循环执行，是执行一次（false）还是一直执行(true)；
        }

        ///当时间发生的时候需要进行的逻辑处理等    // 在这里仅仅是一种方式，可以实现这样的方式很多 
        public void TmUpdate(object source, ElapsedEventArgs time)
=======
        
        //void TumoTimer(int ValTime)
        //{
        //    TmTimer = new Timer();                                         //实例化Timer类，在括号里设置间隔时间,单位为毫秒；
        //    TmTimer.Elapsed += new ElapsedEventHandler(OnTimerEvent);      //到达时间的时候执行事件；
        //    TmTimer.Interval = ValTime;                                    //事件执行间隔时间1000毫秒；
        //    TmTimer.Enabled = true;                                        //是否执行事件System.Timers.Timer.Elapsed；
        //    TmTimer.AutoReset = true;                                      //设置是否循环执行，是执行一次（false）还是一直执行(true)；
        //}
        //// 当时间发生的时候需要进行的逻辑处理等    // 在这里仅仅是一种方式，可以实现这样的方式很多    
        //void OnTimerEvent(object source, ElapsedEventArgs time)
        //{
        //    TmUpdate(time);
        //}

        //private void TmUpdate(ElapsedEventArgs time)
        //{
        //    while (RecvParameters.Count > 0)
        //    {
        //        MvcParameter mvc = RecvParameters.Dequeue();
        //        TumoConnect.Instance.OnTransferParameter(mvc);
        //        Console.WriteLine("RecvParameters: " + RecvParameters.Count);
        //    }
        //}

        public override void TmUpdate(ElapsedEventArgs time)
>>>>>>> 07a544ffdca5ce83fc000e9205c588c3cc349ae8
        {
            while (RecvParameters.Count > 0)
            {
                MvcParameter mvc = RecvParameters.Dequeue();
                TumoConnect.Instance.OnTransferParameter(mvc);
                Console.WriteLine("RecvParameters: " + RecvParameters.Count);
            }
        }

<<<<<<< HEAD
                     
=======

>>>>>>> 07a544ffdca5ce83fc000e9205c588c3cc349ae8
    }
}
