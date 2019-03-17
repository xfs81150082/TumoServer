using System;
using System.ComponentModel;
namespace Tumo
{
    public abstract class TmEcsBase : IDisposable, ISupportInitialize
    {
        #region Awake        
        public string EcsId { get; set; }           /// 身份证号
        public TmEcsBase()
        {
            EcsId = TmIdGenerater.GetId();
            TmEcsBase tmEcs;
            TmObjects.Ecses.TryGetValue(EcsId, out tmEcs);
            if (tmEcs != null)
            {
                EcsId += 5200;
            }
            TmObjects.Ecses.Add(EcsId, this);
            BeginInit();
            TmAwake();
            EndInit();
        }
        public virtual void BeginInit() { }
        public virtual void EndInit() { }
        public virtual void TmAwake() { }
        public virtual void OnTransferParameter(object sender, TmParameter parameter) { }
        #endregion
        #region Dispose
        ///是否已释放了资源，true时方法都不可用了。
        private bool isDisposed { get; set; } = false;
        ///供程序员显式调用的Dispose方法
        public void Dispose()
        {
            if (!isDisposed)
            {
                TmObjects.Ecses.Remove(EcsId);   ///从ECS管理字典中删除
                TmDispose();   /// 为继承类释放时使用，用抽象方法
                GC.SuppressFinalize(this); ///GC不用二次释放this资源   
                isDisposed = true;
                //Console.WriteLine(TmTimerTool.CurrentTime() + " TmDispose EcsId:" + EcsId + " TmEcsBase释放资源");
            }
            else
            {
                Console.WriteLine(TmTimerTool.CurrentTime() + " EcsId:" + EcsId + " TmEcsBase已经释放");
            }
        }
        /// 为继承类释放时使用(Note:这儿为什么要写成虚方法呢？)
        /// 1. 为了让派生类清理自已的资源。将销毁和析构的共同工作提取出来，并让派生类也可以释放其自已分配的资源。
        /// 2. 为派生类提供了根据Dispose()或终结器的需要进行资源清理的必要入口。
        public virtual void TmDispose() { }
        #endregion
    }
}