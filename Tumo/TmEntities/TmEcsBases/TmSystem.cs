using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Timers;

namespace Tumo
{
    public abstract class TmSystem : TmTimer
    {
        #region TmSystem       
        public override void TmAwake()
        {
            TmEcsDictionary.Systems.Add(EcsId, this);
        }
        public TmSystem() { }
        #endregion

        #region GetTmEntities
        public Dictionary<string, TmComponent> Components { get; set; } = new Dictionary<string, TmComponent>();
        public void AddComponent<T>(T tm) where T : TmComponent
        {
            TmComponent com;
            bool have = Components.TryGetValue(typeof(T).Name, out com);
            if (have)
            {
                Console.WriteLine(TmTimerTool.GetCurrentTime() + typeof(T).Name + "此类组件已添加");
            }
            else
            {
                Components.Add(typeof(T).Name, tm);
            }
        }
        public Dictionary<string, TmEntity> GetTmEntities()
        {
            Dictionary<string, TmEntity> entites = new Dictionary<string, TmEntity>();
            entites = TmEcsDictionary.Entities;
            List<string> types = new List<string>(Components.Keys);
            if (Components.Count > 0)
            {
                for (int i = 0; i < types.Count; i++)
                {
                    foreach (var entity in entites.Values)
                    {
                        TmComponent com;
                        bool yes = entity.Components.TryGetValue(types[i], out com);
                        if (!yes)
                        {
                            entites.Remove(types[i]);
                        }
                    }
                }
                return entites;
            }
            return null;
        }     
        #endregion

        #region TmDispose
        public override void TmDispose()
        {
            base.TmDispose();
            TmEcsDictionary.Systems.Remove(EcsId);
            Console.WriteLine(TmTimerTool.GetCurrentTime() + " EcsId:" + EcsId + " TmSystem释放资源");
        }

        #endregion

    }
}
