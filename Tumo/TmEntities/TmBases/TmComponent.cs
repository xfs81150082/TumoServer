using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Tumo
{
    public abstract class TmComponent : TmEcsBase
    {
        public TmEntity TmEntity { get; set; }
        public override void TmAwake()
        {
            TmEcsDictionary.Components.Add(EcsId, this);  
        }
        public TmComponent() { }
        public TmComponent(TmEntity entity)
        {
            TmEntity = entity;
        }          
        public override void TmDispose()
        {
            //base.TmDispose();
            TmEcsDictionary.Components.Remove(EcsId);
            if (TmEntity != null)
            {
                TmComponent tm;
                TmEntity.Components.TryGetValue(this.GetType().Name, out tm);
                if (tm != null)
                {
                    TmEntity.Components.Remove(this.GetType().Name);
                }
                TmEntity = null;
            }
            Console.WriteLine(TmTimerTool.GetCurrentTime() + " EcsId:" + EcsId + " TmComponent释放资源");
        }

    }
}
