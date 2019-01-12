using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Tumo
{
    public abstract class TmEntity : IDisposable
    {
        public string EntityId { get; set; }
        public Dictionary<string, TmComponent> Components = new Dictionary<string, TmComponent>();

        public TmEntity()
        {
            TmInit();
        }
        
        void TmInit()
        {
            EntityId = TmIdGenerator.GetId();
            TmEcsDictionary.Entities.Add(EntityId, this);
        }
        
        #region IDisposable 成员
        private bool _isDisposed = false;//是否已释放了资源，true时方法都不可用了。
        //供程序员显式调用的Dispose方法
        public void Dispose()
        { 
            //调用带参数的Dispose方法，释放托管和非托管资源
            Dispose(true);
            TmEcsDictionary.Entities.Remove(EntityId);
            //手动调用了Dispose释放资源，那么析构函数就是不必要的了，这里阻止GC调用析构函数
            GC.SuppressFinalize(this);   
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
        ~TmEntity()
        {
            Dispose(false);
        }
        #endregion


    }
}
