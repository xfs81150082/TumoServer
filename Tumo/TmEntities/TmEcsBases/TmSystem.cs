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
            TmDictionary.Systems.Add(EcsId, this);
        }
        public TmSystem() { }
        #endregion

        #region GetTmEntities
        private Dictionary<string, TmComponent> Comopnents { get; set; } = new Dictionary<string, TmComponent>();
        public void AddComponent<T>(T tm) where T : TmComponent
        {
            TmComponent com;
            bool have = Comopnents.TryGetValue(typeof(T).Name, out com);
            if (have)
            {
                Console.WriteLine(TmTimerTool.CurrentTime() + typeof(T).Name + "此类组件已添加");
            }
            else
            {
                Comopnents.Add(typeof(T).Name, tm);
            }
        }
        public List<TmEntity> GetTmEntities()
        {
            List<TmEntity> tms = new List<TmEntity>();
            List<TmEntity> entites = new List<TmEntity>(TmDictionary.Entities.Values);
            List<string> coms = new List<string>(Comopnents.Keys);
            if (Comopnents.Count > 0)
            {         
                for (int i = 0; i < entites.Count; i++)
                {
                    List<string> entC = new List<string>(entites[i].Components.Keys);
                    if (coms.Except(entC).ToList().Count == 0) 
                    {
                        tms.Add(entites[i]);
                    }
                }
                if (tms.Count > 0)
                {
                    for (int x = 0; x < tms.Count; x++)
                    {
                        Console.WriteLine(TmTimerTool.CurrentTime() + " TmSystem, tms-entites: " + tms.Count + "-" + entites.Count + " Name:" + tms[x].GetType().Name);
                    }
                }
                return tms;
            }
            else
            {
                return null;
            }
        }      
        #endregion

        #region TmDispose
        public override void TmDispose()
        {
            base.TmDispose();
            TmDictionary.Systems.Remove(EcsId);
            Console.WriteLine(TmTimerTool.CurrentTime() + " EcsId:" + EcsId + " TmSystem释放资源");
        }
        #endregion

    }
}
