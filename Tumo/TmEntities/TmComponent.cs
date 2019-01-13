using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Tumo
{
    public abstract class TmComponent : TmEcsBase
    {
        public TmEntity Parent { get; set; }
        public TmComponent()
        {
            TmEcsDictionary.Components.Add(EcsId, this);
        }        
        public override void TmDispose()
        {
            TmEcsDictionary.Components.Remove(EcsId);
            Console.WriteLine(TmTimer.GetCurrentTime() + " EcsId:" + EcsId + " TmComponent释放资源");
        }

    }
}
