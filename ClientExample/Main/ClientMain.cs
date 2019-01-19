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
            Thread.Sleep(1000);
            new TumoConnect();
            TmTcpClient tmTcpClient = new TmTcpClient();
            new Test();
            

            Console.ReadKey();
            Console.WriteLine(TmTimerTool.CurrentTime() + " 退出联接，并关闭程序。");
        }
               

    }
}
