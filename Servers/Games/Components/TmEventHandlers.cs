using System;
using System.Collections.Generic;
using Tumo;
namespace Servers
{
    public class TmEventHandlers : TmComponent
    {
        private static TmEventHandlers _instance;
        public static TmEventHandlers Instance { get => _instance; }
        public override void TmAwake()
        {
            base.TmAwake();
            _instance = this;
        }
        public Dictionary<string, EventHandler<TmParameter>> EventHandlers = new Dictionary<string, EventHandler<TmParameter>>();
        public EventHandler<TmParameter> GetComponent(string name)
        { 
            EventHandler<TmParameter> tem;
            EventHandlers.TryGetValue(name, out tem);
            if (tem != null)
            {
                return tem;
            }
            else
            {
                Console.WriteLine(TmTimerTool.CurrentTime() + " " + name + " 此事件不存在！");
                return null;
            }
        }
        public void AddComponent(EventHandler<TmParameter> eve)
        {
            if (eve != null)
            {
                Console.WriteLine(TmTimerTool.CurrentTime() + "eve.ToString()：" + eve);
                string name = eve.GetHashCode().ToString();
                Console.WriteLine(TmTimerTool.CurrentTime() + "eve.ToString()：" + name);
                EventHandler<TmParameter> tem;
                EventHandlers.TryGetValue(name, out tem);
                if (tem == null)
                {
                    EventHandlers.Add(name, eve);
                    Console.WriteLine(TmTimerTool.CurrentTime() + " 事件 {0} 注册成功。", name);
                }
                else
                {
                    Console.WriteLine(TmTimerTool.CurrentTime() + " 异常：此事件或事件名称 {} 已存在！", name);
                }
            }
            else
            {
                Console.WriteLine(TmTimerTool.CurrentTime() + " 异常：此事件或事件名称 {} 不存在！", eve);

            }
        }
        public void RemoveComponent(EventHandler<TmParameter> eve)
        {
            string name = eve.ToString();
            EventHandler<TmParameter> tem;
            EventHandlers.TryGetValue(name, out tem);
            if (tem != null)
            {
                EventHandlers.Remove(name);
                Console.WriteLine(TmTimerTool.CurrentTime() + " 事件 {0} 删除成功。", name);
            }
            else
            {
                Console.WriteLine(TmTimerTool.CurrentTime() + " 异常：此事件或事件名称 {} 已存在！", name);
            }
        }
    }
}