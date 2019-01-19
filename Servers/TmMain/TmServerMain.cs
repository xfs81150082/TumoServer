using Servers.Games;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Tumo;

namespace Servers
{
    class TmServerMain
    { 
        //程序启动入口
        static void Main(string[] args)
        {
            Console.WriteLine(TmTimerTool.CurrentTime() + " ... ");
            ///创建游戏服务器并运行
            new GameServer();

            Thread.CurrentThread.Name = "TumoWorld";
            Console.WriteLine(TmTimerTool.CurrentTime() + " ThreadName:" + Thread.CurrentThread.Name);
            Console.WriteLine(TmTimerTool.CurrentTime() + " ThreadId:" + Thread.CurrentThread.ManagedThreadId);

            Console.ReadKey();
            Console.WriteLine(TmTimerTool.CurrentTime() + " 退出监听，并关闭程序。");
        }
    }
}
