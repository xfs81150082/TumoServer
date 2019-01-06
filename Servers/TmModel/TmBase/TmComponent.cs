using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Servers.TmModel
{
    public abstract class TmComponent : TmObject , IDisposable
    {

        public long InstanceId { get; protected set; }

        private bool isFromPool;


        public bool IsFromPool
        {
            get
            {
                return this.isFromPool;
            }
            set
            {
                this.isFromPool = value;

                if (!this.isFromPool)
                {
                    return;
                }

                if (this.InstanceId == 0)
                {
                    //this.InstanceId = IdGenerater.GenerateId();
                }
            }
        }
        public bool IsDisposed
        {
            get
            {
                return this.InstanceId == 0;
            }
        }

        public virtual void Dispose()
        {
            if (this.IsDisposed)
            {
                return;
            }


        }

        public override void EndInit()
        {
            //Game.EventSystem.Deserialize(this);
        }

        public override string ToString()
        {
            return TmJsonHelper.ToString(this);
        }


    }
}
