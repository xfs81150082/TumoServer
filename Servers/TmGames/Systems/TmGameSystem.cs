using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tumo;

namespace Servers
{
    public class TmGameSystem : TmSystem
    {
        public override void TmAwake()
        {
            base.TmAwake();
            AddComponent(new TmMysql());            ///TmEntity 负责建立数据库链接，让相关组件调用获取或保存数据
            AddComponent(new TmAsyncTcpServer());   ///TmComponent 负责建立套接字外网链接（含心跳包），让相关组件调用传送信息
            AddComponent(new TmGate());             ///TmEntity 负责将客户端发来的数据分流处理
            AddComponent(new TmLogin());            ///TmEntity 负责用户登录验证，角色登录获取数据和保存数据
        }

        public override void TmUpdate()
        {
            Dictionary<string, TmEntity> entitis = GetTmEntities();
            Console.WriteLine(TmTimerTool.CurrentTime() + " Components: " + Components.Count);
            Console.WriteLine(TmTimerTool.CurrentTime() + " Entities: " + TmEcsDictionary.Entities.Count);
            Console.WriteLine(TmTimerTool.CurrentTime() + " entitis: " + entitis.Count);

            foreach (var entity in entitis.Values)
            {
                foreach(var com in entity.Components)
                {
                    Console.WriteLine(TmTimerTool.CurrentTime() + " entityComponents: " + entity.Components.Count + " entity: " + entity.GetType().Name + " com: " + com.Key);
                    //Console.WriteLine(TmTimerTool.CurrentTime() + " Type: " + com.GetType().Name);
                }
            }
            foreach(var tem in Components)
            {
                Console.WriteLine(TmTimerTool.CurrentTime() + " Component: " + tem.Value.GetType().Name);
            }

        }

    }
}
