using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Tumo
{
    public abstract class TmComponent : TmEcsBase
    {
        public TmEntity Parent { get; set; }
        public override void TmAwake()
        {
            TmEcsDictionary.Components.Add(EcsId, this);         
        }
        public override void TmDispose()
        {
            base.TmDispose();
            TmEcsDictionary.Components.Remove(EcsId);
            if (Parent != null)
            {
                TmComponent tm;
                Parent.Components.TryGetValue(this.GetType().Name, out tm);
                if (tm != null)
                {
                    Parent.Components.Remove(this.GetType().Name);
                }
                Parent = null;
            }
            Console.WriteLine(TmTimerTool.CurrentTime() + " EcsId:" + EcsId + " TmComponent释放资源");
        }

    }
}
