using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Timers;

namespace Tumo
{
    public abstract class TmMonoBehaviour : IDisposable
    {
        public TmMonoBehaviour()
        {
            //TmAwake();
            TumoTimer(ValTime);
            Console.WriteLine(TmTimer.GetCurrentTime() + " TmMonoBehaviour 实例化");
        }

        #region Timer
        public int ValTime = 1000;
        private Timer Timer;
        void TumoTimer(int ValTime)
        {
            Timer = new Timer();                                         //实例化Timer类，在括号里设置间隔时间,单位为毫秒；
            Timer.Elapsed += new ElapsedEventHandler(OnTimerEvent);      //到达时间的时候执行事件；
            Timer.Interval = ValTime;                                    //事件执行间隔时间1000毫秒；
            Timer.Enabled = true;                                        //是否执行事件System.Timers.Timer.Elapsed；
            Timer.AutoReset = true;                                      //设置是否循环执行，是执行一次（false）还是一直执行(true)；
        }
        // 当时间发生的时候需要进行的逻辑处理等    // 在这里仅仅是一种方式，可以实现这样的方式很多    
        void OnTimerEvent(object source, ElapsedEventArgs time)
        {
            TmUpdate();
        }
        public abstract void TmUpdate();
        #endregion

        #region Close
        private bool _isDisposed = false;//是否已释放了资源，true时方法都不可用了。
        //供程序员显式调用的Dispose方法
        public void Close()
        {
            Timer.AutoReset = false;                                      //设置是否循环执行，是执行一次（false）还是一直执行(true)；
            Timer.Enabled = false;                                        //是否执行事件System.Timers.Timer.Elapsed；
            Timer.Elapsed -= new ElapsedEventHandler(OnTimerEvent);       //到达时间的时候执行事件；
            Timer.Close();
            Dispose();
        }
        //供程序员显式调用的Dispose方法
        public void Dispose()
        {
            //调用带参数的Dispose方法，释放托管和非托管资源
            Dispose(true);
            //手动调用了Dispose释放资源，那么析构函数就是不必要的了，这里阻止GC调用析构函数
            GC.SuppressFinalize(this);
            Console.WriteLine(TmTimer.GetCurrentTime() + " TmMonoBehaviour 已释放资源");
        }
        /// <summary>
        /// 为继承类释放时使用
        /// <remarks>
        /// Note:这儿为什么要写成虚方法呢？
        /// 1. 为了让派生类清理自已的资源。将销毁和析构的共同工作提取出来，并让派生类也可以释放其自已分配的资源。
        /// 2. 为派生类提供了根据Dispose()或终结器的需要进行资源清理的必要入口。
        /// </remarks>
        /// </summary>
        /// <param name="isDisposing"></param>
        protected virtual void Dispose(bool isDisposing)
        {
            if (_isDisposed) return;

            if (isDisposing)
            {
                //释放托管资源
                //（由CLR管理分配和释放的资源，即由CLR里new出来的对象）
                //TODO: other code   

            }

            //释放非托管资源
            //(不受CLR管理的对象，windows内核对象，如文件、数据库连接、套接字、COM对象等)
            //TODO: other code

            _isDisposed = true;
        }
        /// <summary>
        /// 如果没有非托管资源，不要实现它;//供GC调用的析构函数
        /// </summary>
        ~TmMonoBehaviour()
        {
            Dispose(false);
        }
        #endregion


    }
}
