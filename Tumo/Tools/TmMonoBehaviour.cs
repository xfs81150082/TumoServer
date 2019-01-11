using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Timers;

namespace Tumo
{
    public abstract class TmMonoBehaviour : IDisposable
    {
        public int ValTime = 1000;
        private Timer TmTimer;
        public TmMonoBehaviour()
        {
            TmAwake();
            TumoTimer(ValTime);
            Console.WriteLine(TimerTool.GetCurrentTime() + " TmMonoBehaviour 实例化");
        }
        void TumoTimer(int ValTime)
        {
            TmTimer = new Timer();                                         //实例化Timer类，在括号里设置间隔时间,单位为毫秒；
            TmTimer.Elapsed += new ElapsedEventHandler(OnTimerEvent);      //到达时间的时候执行事件；
            TmTimer.Interval = ValTime;                                    //事件执行间隔时间1000毫秒；
            TmTimer.Enabled = true;                                        //是否执行事件System.Timers.Timer.Elapsed；
            TmTimer.AutoReset = true;                                      //设置是否循环执行，是执行一次（false）还是一直执行(true)；
        }
        // 当时间发生的时候需要进行的逻辑处理等    // 在这里仅仅是一种方式，可以实现这样的方式很多    
        void OnTimerEvent(object source, ElapsedEventArgs time)
        {
            TmUpdate(time);
        } 
        public void Close()
        {
            TmTimer.AutoReset = false;                                      //设置是否循环执行，是执行一次（false）还是一直执行(true)；
            TmTimer.Enabled = false;                                        //是否执行事件System.Timers.Timer.Elapsed；
            TmTimer.Elapsed -= new ElapsedEventHandler(OnTimerEvent);       //到达时间的时候执行事件；
            TmTimer.Close();
            Dispose();
        }
        public void Dispose()
        {
            Console.WriteLine(TimerTool.GetCurrentTime() + " TmMonoBehaviour 已释放资源");            
        }
        public abstract void TmAwake();
        public abstract void TmUpdate(ElapsedEventArgs time);

    }
}
