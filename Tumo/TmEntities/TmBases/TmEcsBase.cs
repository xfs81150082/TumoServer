using System;
using System.ComponentModel;
using System.Timers;

namespace Tumo
{
    public abstract class TmEcsBase : IDisposable
    {
        #region TmAwake EcsId        
        public string EcsId { get; set; }           /// 身份证号
        public TmEcsBase()
        {
            EcsId = TmIdGenerater.GetId();
            TmEcsDictionary.Ecses.Add(EcsId, this);
            TmAwake();
        }
        public abstract void TmAwake();
        #endregion

        #region Dispose
        ///是否已释放了资源，true时方法都不可用了。
        private bool isDisposed { get; set; } = false;
        ///供程序员显式调用的Dispose方法
        public void Dispose()
        {
            if (!isDisposed)
            {
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
        public abstract void TmDispose();
        #endregion

    }
}