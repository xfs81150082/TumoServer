using ClientExample;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using Tumo;

namespace ClientExample
{
    class ClientMain
    {
        static void Main(string[] args)
        {
            Console.WriteLine(TmTimerTool.CurrentTime() + " ... ");
            ///创建控制台客户端并运行
            Thread.Sleep(4000);

            TmGame.TmSence.AddComponent(new TmConnect());
            TmGame.TmSence.AddComponent(new TmClientSocket());

            //new TumoConnect();
            //TmTcpClient tmTcpClient = new TmTcpClient();
            //new Test();


            Console.ReadKey();
            Console.WriteLine(TmTimerTool.CurrentTime() + " 退出联接，并关闭程序。");
        }
               

    }
}
