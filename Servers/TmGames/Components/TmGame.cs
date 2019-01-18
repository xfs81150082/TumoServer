using Servers.Logins;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tumo;

namespace Servers
{
    public class TmGame : TmEntity
    {
        public override void TmAwake()
        {
            base.TmAwake();
            Init();
        }
        /// <summary>
        /// 设计思路，ECS组件式思路，并不完全
        /// </summary>
        void Init()
        {
            AddComponent(new TmMysql());           ///TmEntity 负责建立数据库链接，让相关组件调用获取或保存数据
            AddComponent(new TmAsyncTcpServer());  ///TmComponent 负责建立套接字外网链接（含心跳包），让相关组件调用传送信息
            AddComponent(new TmTcpServer());       ///TmSystem 负责建立套接字外网链接（含心跳包），让相关组件调用传送信息
            AddComponent(new TmGate());            ///TmEntity 负责将客户端发来的数据分流处理
            AddComponent(new TmLogin());           ///TmEntity 负责用户登录验证，角色登录获取数据和保存数据
            AddComponent(new TmGameSystem());      ///TmSystem 负责处理各个组件之间关系，主要是数据交换
        }

    }
}
