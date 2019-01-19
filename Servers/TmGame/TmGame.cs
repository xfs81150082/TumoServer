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
            AddComponent(new TmMysql());
            AddComponent(new TmTcpServer());
            AddComponent(new TmLogin());
            TmLog.WriteLine(TmTimerTool.CurrentTime() + this.GetType().Name+ " 注册组件完成。 ");

        }
        public override void OnTransferParameter(TmParameter parameter)
        {
            base.OnTransferParameter(parameter);
            Console.WriteLine(TmTimerTool.CurrentTime() + " OnTransferParameter EcsId:" + EcsId + " TmGame释放资源");
            TmLog.WriteLine(TmTimerTool.CurrentTime() + " OnTransferParameter EcsId:" + EcsId + " TmGame释放资源");
        }



    }
}
