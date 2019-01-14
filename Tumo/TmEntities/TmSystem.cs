using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Timers;

namespace Tumo
{
    public abstract class TmSystem : TmEcsBase
    {
        #region TmAwake
        public override void TmAwake()
        {
            TmEcsDictionary.Systems.Add(EcsId, this);
        }
        public TmSystem()
        {

        }
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
            Console.WriteLine(TmTimer.GetCurrentTime() + " EcsId:" + EcsId + " TmSystem释放资源");
        }       
        #endregion

    }
}
