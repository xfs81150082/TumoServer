using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tumo;

namespace Servers
{
    public class GameServer : TmEntity
    {
        public override void TmAwake()
        {
            base.TmAwake();

        }

        public GameServer()
        {            
            AddComponent(new TmMysql());
            AddComponent(new TmGate());
            AddComponent(new TmTcpServer());
            TmLog.WriteLine(TmTimerTool.CurrentTime() + " " + this.GetType().Name + " 组件加载完成。 ");
        }   

        public override void TmDispose()
        {
            base.TmDispose();

        }

    }
}
