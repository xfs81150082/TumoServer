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
            Thread.Sleep(1);            ///线程暂停1毫秒

            ///服务器加载组件
            TmGame.TmSence.AddComponent(new TmMysql());       ///数据库链接组件
            TmGame.TmSence.AddComponent(new TmGate());        ///服务器网关
            TmGame.TmSence.AddComponent(new TmServerSocket());   ///套接字 外网 传输数据
            TmGame.TmSence.AddComponent(new TmUserHandler());
            TmGame.TmSence.AddComponent(new TmUserMysql());
            TmGame.TmSence.AddComponent(new TmEngineerHandler());
            TmGame.TmSence.AddComponent(new TmEngineerMysql());

            
            Thread.CurrentThread.Name = "TumoWorld";
            Console.WriteLine(TmTimerTool.CurrentTime() + " ThreadName:" + Thread.CurrentThread.Name);
            Console.WriteLine(TmTimerTool.CurrentTime() + " ThreadId:" + Thread.CurrentThread.ManagedThreadId);

            Console.ReadKey();
            Console.WriteLine(TmTimerTool.CurrentTime() + " 退出监听，并关闭程序。");
        }
    }
}
