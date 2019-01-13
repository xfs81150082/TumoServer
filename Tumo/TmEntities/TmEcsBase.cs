using System;
using System.Timers;

namespace Tumo
{
    public abstract class TmEcsBase : IDisposable
    {
        #region TmAwake EcsId
        /// 身份证号
        public string EcsId { get; set; }
        public TmEcsBase()
        {
            TmInit();
            TmAwake();
            TumoTimer(ValTime);
        }
        void TmInit()
        {
            EcsId = TmIdGenerater.GetId();
            TmEcsDictionary.Ecses.Add(EcsId, this);
        }
        public abstract void TmAwake();
        #endregion

        #region TmUpdate Timer
        public int ValTime = 20;
        private Timer Timer;
        void TumoTimer(int ValTime)
        {
            Timer = new Timer();                                         ///实例化Timer类，在括号里设置间隔时间,单位为毫秒；
            Timer.Elapsed += new ElapsedEventHandler(OnTimerEvent);      ///到达时间的时候执行事件；
            Timer.Interval = ValTime;                                    ///事件执行间隔时间1000毫秒；
            Timer.Enabled = true;                                        ///是否执行事件System.Timers.Timer.Elapsed；
            Timer.AutoReset = true;                                      ///设置是否循环执行，是执行一次（false）还是一直执行(true)；
        }
        /// 当时间发生的时候需要进行的逻辑处理等    /// 在这里仅仅是一种方式，可以实现这样的方式很多    
        void OnTimerEvent(object source, ElapsedEventArgs time)
        {
            TmUpdate();
        }
        public abstract void TmUpdate();
        #endregion

        #region Dispose
        ///是否已释放了资源，true时方法都不可用了。
        private bool isDisposed = false;
        ///供程序员显式调用的Dispose方法
        public void Dispose()
        {
            if (!isDisposed)
            {
                Close();   ///关闭Timer时钟
                TmEcsDictionary.Ecses.Remove(EcsId);   ///从ECS管理字典中删除
                TmDispose();   /// 为继承类释放时使用，用抽象方法
                isDisposed = true;
                Console.WriteLine(TmTimer.GetCurrentTime() + " EcsId:" + EcsId + " TmEcsBase释放资源");
            }
            else
            {
                Console.WriteLine(TmTimer.GetCurrentTime() + " EcsId:" + EcsId + " TmEcsBase已经释放");
            }
        }
        /// 为继承类释放时使用(Note:这儿为什么要写成虚方法呢？)
        /// 1. 为了让派生类清理自已的资源。将销毁和析构的共同工作提取出来，并让派生类也可以释放其自已分配的资源。
        /// 2. 为派生类提供了根据Dispose()或终结器的需要进行资源清理的必要入口。
        private void Close()
        {
            Timer.AutoReset = false;                                      ///设置是否循环执行，是执行一次（false）还是一直执行(true)；
            Timer.Enabled = false;                                        ///是否执行事件System.Timers.Timer.Elapsed；
            Timer.Elapsed -= new ElapsedEventHandler(OnTimerEvent);       ///到达时间的时候执行事件；
            Timer.Close();
            Console.WriteLine(TmTimer.GetCurrentTime() + " Timer关闭并释放资源");
        }
        public abstract void TmDispose();
        #endregion

    }
}