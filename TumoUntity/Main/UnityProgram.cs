using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Tumo;

namespace TumoUntity
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine(TmTimerTool.CurrentTime() + " ... ");
            Thread.Sleep(2000);       ///线程暂停2000毫秒

            ///客户端加载组件
            TmGame.TmSence.AddComponent(new TmConnect());
            TmGame.TmSence.AddComponent(new TmClientSocket());
            TmGame.TmSence.AddComponent(new TmEngineerController());
            TmGame.TmSence.AddComponent(new TmUserController());
            TmGame.TmSence.AddComponent(new TmTest());


            Console.ReadKey();
            Console.WriteLine(TmTimerTool.CurrentTime() + " 退出联接，并关闭程序。");
        }
    }
}
