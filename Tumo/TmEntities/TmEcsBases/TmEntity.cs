using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Tumo
{
    public abstract class TmEntity : TmComponent
    {
        public Dictionary<string, TmComponent> Components { get; set; } = new Dictionary<string, TmComponent>();
        public override void TmAwake()
        {
            base.TmAwake();
            TmDictionary.Entities.Add(EcsId, this);
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
                Console.WriteLine(TmTimerTool.CurrentTime() + tem.GetType().Name + "此类型组件不存在！");
                return null;
            }
        }
        public void AddComponent<T>(T tm) where T : TmComponent
        {
            TmComponent tem;
            Components.TryGetValue(typeof(T).Name, out tem);
            if (tem == null)
            {
                tm.Parent = this;
                Components.Add(typeof(T).Name, tm);
                Console.WriteLine(TmTimerTool.CurrentTime() + " 实例{0},成功添加组件{1}.", this.GetType().Name, typeof(T).Name);
            }
            else
            {
                Console.WriteLine(TmTimerTool.CurrentTime() + " 此类型组件 {} 已存在！", typeof(T).Name);
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
                tem.Parent = null;
                Console.WriteLine(TmTimerTool.CurrentTime() + " 实例 {0} 删除组件 {1} 成功", this.GetType().Name, typeof(T).Name);
                tem.Dispose();
            }
            else
            {
                Console.WriteLine(TmTimerTool.CurrentTime() + name + "此类型组件不存在！");
            }
        }
        public override void TmDispose()
        {
            base.TmDispose();
            TmDictionary.Entities.Remove(EcsId);
            try
            {
                if (Components.Count > 0)
                {
                    foreach (var tem in Components.Values)
                    {
                        tem.Dispose();
                    }
                    Console.WriteLine(TmTimerTool.CurrentTime() + " EcsId:" + EcsId + " TmEntity释放资源");

                }
                Components.Clear();
            }
            catch (Exception ex)
            {
                Console.WriteLine(TmTimerTool.CurrentTime() + " ex: " + ex.Message + " TmEntity释放资源异常...");
            }
        }
    }
}
