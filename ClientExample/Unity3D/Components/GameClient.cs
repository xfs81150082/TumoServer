using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tumo;

namespace ClientExample
{
    public class GameClient : TmEntity
    {
        public override void TmAwake()
        {
            base.TmAwake();

        }

        public GameClient()
        {
            AddComponent(new TmConnect());
            AddComponent(new TmTcpClient());
            Console.WriteLine(TmTimerTool.CurrentTime() + " " + this.GetType().Name + " 组件加载完成。 ");
        }

        public override void TmDispose()
        {
            base.TmDispose();

        }

    }
}
