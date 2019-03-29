using System;
using System.Threading;
using Tumo;
namespace ClientExample
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine(TmTimerTool.CurrentTime() + " ... ");
            Thread.Sleep(4000);
            TmGameSenceInit();

            TmGame.TmSence.AddComponent(new TmTest());                 ///客户端加载组件 : 测试组件1
            TmGame.TmSence.AddComponent(new SyncTest());               ///客户端加载组件 : 测试组件2


            Thread.CurrentThread.Name = "TumoWorld";
            Console.WriteLine(TmTimerTool.CurrentTime() + " ThreadName:" + Thread.CurrentThread.Name);
            Console.WriteLine(TmTimerTool.CurrentTime() + " ThreadId:" + Thread.CurrentThread.ManagedThreadId);

            Console.ReadKey();
            Console.WriteLine(TmTimerTool.CurrentTime() + " 退出联接，并关闭程序。");
        }
        static void TmGameSenceInit()
        {
            TmGame.TmSence.AddComponent(new TmConnectController());              ///客户端加载组件 : 接收分发组件
            TmGame.TmSence.AddComponent(new TmClientSocket());         ///客户端加载组件 : 套接字网络组件
            TmGame.TmSence.AddComponent(new TmUserController());       ///客户端加载组件 : User处理组件
            TmGame.TmSence.AddComponent(new TmEngineerController());   ///客户端加载组件 : Engineer处理组件
            TmGame.TmSence.AddComponent(new TmBookerController());     ///客户端加载组件 : Booker处理组件
            TmGame.TmSence.AddComponent(new TmTeacherController());    ///客户端加载组件 : Teacher处理组件
            TmGame.TmSence.AddComponent(new TmStatusSyncController());    ///客户端加载组件 : Teacher处理组件
        }
    }
}
