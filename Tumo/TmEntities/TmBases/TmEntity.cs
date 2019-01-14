using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Tumo
{
    public abstract class TmEntity : TmEcsBase
    {
        public Dictionary<string, TmComponent> Components { get; set; } = new Dictionary<string, TmComponent>();
        public override void TmAwake()
        {
            TmEcsDictionary.Entities.Add(EcsId, this);
        }
        public TmEntity() { }



        public TmComponent GetComponent<T>()
        {
            string name = typeof(T).Name;
            TmComponent tem;
            Components.TryGetValue(name, out tem);
            if (tem != null)
            {                
                return tem;
            }
            else
            {
                Console.WriteLine(TmTimer.GetCurrentTime() + tem.GetType().Name + "此类型组件不存在！");
                return null;
            }
        }
        public void AddComponent<T>(T component)
        {
            TmComponent tm = component as TmComponent;
            TmComponent tem;
            Components.TryGetValue(tm.GetType().Name, out tem);
            if (tem == null)
            {
                Components.Add(tm.GetType().Name, tm);
            }
            else
            {
                Console.WriteLine(TmTimer.GetCurrentTime() + tm.GetType().Name + "此类型组件已存在！");
            }
        }
        public void RemoveComponent<T>()
        {
            string name = typeof(T).Name;
            TmComponent tem;
            Components.TryGetValue(name, out tem);
            if (tem != null)
            {
                Components.Remove(name);
                tem.Dispose();
            }
            else
            {
                Console.WriteLine(TmTimer.GetCurrentTime() + name + "此类型组件不存在！");
            }
        }
        public override void TmDispose()
        {
            TmEcsDictionary.Entities.Remove(EcsId);
            OnDispose();
            Console.WriteLine(TmTimer.GetCurrentTime() + " EcsId:" + EcsId + " TmEntity释放资源");
        }
        void OnDispose()
        {
            foreach(var tem in Components.Values)
            {                
                tem.Dispose();
            }
            Components.Clear();
        }


    }
}
