using System;
using System.Collections.Generic;
using System.Threading;
using Tumo;
namespace Servers
{
    class TmServerMain
    { 
        //程序启动入口
        static void Main(string[] args)
        {
            Console.WriteLine(TmTimerTool.CurrentTime() + " ... ");  
            Thread.Sleep(1);                                           

            TmGame.TmSence.AddComponent(new TmMysqlConnection());       ///服务器加载组件 : 数据库链接组件
            TmGame.TmSence.AddComponent(new TmMysqlHandler());          ///服务器加载组件 : 数据库表格组件集
            TmGame.TmSence.AddComponent(new TmGateHandler());                  ///服务器加载组件 : 服务器网关组件
            TmGame.TmSence.AddComponent(new TmServerSocket());          ///服务器加载组件 : 套接字 外网 传输数据组件
            //TmGame.TmSence.AddComponent(new TmServerTcpNetHandler());          ///服务器加载组件 : 套接字 外网 传输数据组件
            TmGame.TmSence.AddComponent(new TmUserHandler());           ///服务器加载组件 : 用户处理组件
            TmGame.TmSence.AddComponent(new TmEngineerHandler());       ///服务器加载组件 : Engineer处理组件
            TmGame.TmSence.AddComponent(new TmBookerHandler());         ///服务器加载组件 : Booker处理组件
            TmGame.TmSence.AddComponent(new TmTeacherHandler());        ///服务器加载组件 : Teacher处理组件
            TmGame.TmSence.AddComponent(new TmStatusSyncHandler());        ///服务器加载组件 : Teacher处理组件

            //TmGame.TmSence.AddComponent(new TmServerSocketSystem());          ///服务器加载组件 : 套接字 外网 传输数据组件

            Thread.CurrentThread.Name = "TumoWorld";
            Console.WriteLine(TmTimerTool.CurrentTime() + " ThreadName:" + Thread.CurrentThread.Name);
            Console.WriteLine(TmTimerTool.CurrentTime() + " ThreadId:" + Thread.CurrentThread.ManagedThreadId);

            Console.ReadKey();
            Console.WriteLine(TmTimerTool.CurrentTime() + " 退出监听，并关闭程序。");
        }
    }
}
