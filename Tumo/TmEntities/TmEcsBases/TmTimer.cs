using System;
using System.Timers;

namespace Tumo
{
    public abstract class TmTimer : TmComponent
    {
        public TmTimer()
        {
            Timer = new Timer(ValTime);                                     ///实例化Timer类，在括号里设置间隔时间,单位为毫秒；
            Open();
        }
        #region TmUpdate Timer
        public int ValTime = 20;
        private Timer Timer;
        private void Open()
        {
            Timer.Elapsed += new ElapsedEventHandler(OnTimerEvent);      ///到达时间的时候执行事件；
            Timer.Interval = ValTime;                                    ///事件执行间隔时间1000毫秒；
            Timer.Enabled = true;                                        ///是否执行事件System.Timers.Timer.Elapsed；
            Timer.AutoReset = true;                                      ///设置是否循环执行，是执行一次（false）还是一直执行(true)；
        }
        /// 当时间发生的时候需要进行的逻辑处理等    /// 在这里仅仅是一种方式，可以实现这样的方式很多    
        private void OnTimerEvent(object source, ElapsedEventArgs time)
        {
            TmUpdate();
        }
        private void Close()
        {
            Timer.AutoReset = false;                                      ///设置是否循环执行，是执行一次（false）还是一直执行(true)；
            Timer.Enabled = false;                                        ///是否执行事件System.Timers.Timer.Elapsed；
            Timer.Elapsed -= new ElapsedEventHandler(OnTimerEvent);       ///到达时间的时候执行事件；
            Timer.Close();
        }
        public virtual void TmUpdate() { }
        #endregion
        #region TmDispose  
        public override void TmDispose()
        {
            Close();       ///关闭Timer时钟
            Console.WriteLine(TmTimerTool.CurrentTime() + " EcsId:" + EcsId + " Timer释放资源");
        }
        #endregion

    }
}