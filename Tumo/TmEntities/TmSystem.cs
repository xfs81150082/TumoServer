using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Timers;

namespace Tumo
{
    public abstract class TmSystem : TmEcsBase
    {
        #region 
        public TmSystem()
        {
            TmEcsDictionary.Systems.Add(EcsId, this);
        }
        #endregion

        #region GetTmEntities
        public Dictionary<string,TmEntity> GetTmEntities(List<TmComponent> tmComponents)
        {
            Dictionary<string, TmEntity> dict = new Dictionary<string, TmEntity>();
            List<List<string>> list1 = new List<List<string>>();
            List<string> list2 = new List<string>();
            for (int i = 0; i < tmComponents.Count; i++)
            {
                List<string> ens = GetParentIdByType(tmComponents[i]);
                list1.Add(ens);
            }
            for(int j = 0; j < list1.Count; j++)
            {             
                list2 = list2.Intersect(list1[j]).ToList();
            }
            for(int r = 0; r < list2.Count; r++)
            {
                TmEntity entity = null;
                TmEcsDictionary.Entities.TryGetValue(list2[r], out entity);
                if (entity != null)
                {
                    dict.Add(entity.EcsId, entity);
                }
            }
            return dict;
        }
        List<string> GetParentIdByType(TmComponent component)
        {
            List<string> parents = new List<string>();
            foreach(var tem in TmEcsDictionary.Components.Values)
            {
                if(tem.GetType().Name== component.GetType().Name)
                {
                    parents.Add(tem.Parent.EcsId);
                }
            }
            return parents;
        }
        #endregion
        
        public override void TmDispose()
        {
            TmEcsDictionary.Systems.Remove(EcsId);
            Console.WriteLine(TmTimer.GetCurrentTime() + " EcsId:" + EcsId + " TmSystem释放资源");
        }

    }
}
