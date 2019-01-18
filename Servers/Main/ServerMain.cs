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
    class ServerMain
    { 
        //程序启动入口
        static void Main(string[] args)
        {
            //new TmMysql();
            //new TmGate();
            //new TmTcpServer();

            new TmGame();

            Thread.CurrentThread.Name = "ServerMainThread26";
            Console.WriteLine(TmTimerTool.GetCurrentTime() + " EngineerNode Thread Name:" + Thread.CurrentThread.Name);
            Console.WriteLine(TmTimerTool.GetCurrentTime() + " EngineerNode Thread Name:" + Thread.CurrentThread.ManagedThreadId);

            Console.ReadKey();
            Console.WriteLine("退出监听，并关闭程序。");
        }
    }
}
