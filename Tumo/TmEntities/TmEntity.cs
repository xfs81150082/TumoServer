using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Tumo
{
    public abstract class TmEntity : TmEcsBase
    {
        public Dictionary<string, TmComponent> Components = new Dictionary<string, TmComponent>();
        public Dictionary<string, TmEntity> Entities = new Dictionary<string, TmEntity>();
        public TmEntity()
        {
            TmEcsDictionary.Entities.Add(EcsId, this);
        }
        public override void TmDispose()
        {
            TmEcsDictionary.Entities.Remove(EcsId);
            Console.WriteLine(TmTimer.GetCurrentTime() + " EcsId:" + EcsId + " TmEntity已释放资源");
        }

    }
}
