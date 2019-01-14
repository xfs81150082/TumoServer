using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Timers;

namespace Tumo
{
    public abstract class TmSystem : TmEcsBase
    {
        #region TmSystem       
        public override void TmAwake()
        {
            TmEcsDictionary.Systems.Add(EcsId, this);
        }
        public TmSystem()
        {
            TumoTimer(ValTime);
        }
        #endregion

        #region TmUpdate Timer
        public int ValTime = 20;
        private Timer Timer;
        private void TumoTimer(int ValTime)
        {
            Timer = new Timer();                                         ///实例化Timer类，在括号里设置间隔时间,单位为毫秒；
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
            Console.WriteLine(TmTimer.GetCurrentTime() + " Timer关闭并释放资源");
        }
        public abstract void TmUpdate();
        #endregion

        #region GetTmEntities
        public List<TmEntity> GetTmEntities(List<TmComponent> components)
        {
            List<TmEntity> parents = new List<TmEntity>();
            foreach (var tem in TmEcsDictionary.Entities.Values)
            {
                List<TmComponent> list = new List<TmComponent>(tem.Components.Values);
                if (components.All(a => list.Any(b => b.GetType().Name == a.GetType().Name)))
                {
                    parents.Add(tem);
                }
            }
            return parents;
        }
        #endregion

        #region TmDispose  
        public override void TmDispose()
        {
            TmEcsDictionary.Systems.Remove(EcsId);
            Close();       ///关闭Timer时钟
            Console.WriteLine(TmTimer.GetCurrentTime() + " EcsId:" + EcsId + " TmSystem释放资源");
        }
        #endregion

    }
}
