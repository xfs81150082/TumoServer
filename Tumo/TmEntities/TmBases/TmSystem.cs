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
        private Dictionary<string, TmComponent> Comopnents { get; set; } = new Dictionary<string, TmComponent>();
        public void AddComopnent<T>(T tm) where T : TmComponent
        {
            TmComponent com;
            bool have = Comopnents.TryGetValue(typeof(T).Name, out com);
            if (have)
            {
                Console.WriteLine(TmTimerTool.GetCurrentTime() + typeof(T).Name + "此类组件已添加");
            }
            else
            {
                Comopnents.Add(typeof(T).Name, tm);
            }
        }
        public Dictionary<string, TmEntity> GetTmEntities()
        {
            Dictionary<string, TmEntity> tmentites = new Dictionary<string, TmEntity>(TmEcsDictionary.Entities);
            if (Comopnents.Count > 0)
            {
                List<string> types = new List<string>(Comopnents.Keys);
                for (int i = 0; i < types.Count; i++)
                {
                    foreach (var entity in tmentites.Values)
                    {
                        TmComponent com;
                        bool yes = entity.Components.TryGetValue(types[i], out com);
                        if (yes == false)
                        {
                            tmentites.Remove(entity.EcsId);
                        }
                    }
                }
                return tmentites;
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
            TmEcsDictionary.Systems.Remove(EcsId);
            Console.WriteLine(TmTimerTool.GetCurrentTime() + " EcsId:" + EcsId + " TmSystem释放资源");
        }

        #endregion

    }
}
