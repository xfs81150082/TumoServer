using ClientExample;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Tumo;

namespace ClientExample
{
    class ClientMain
    {
        static void Main(string[] args)
        {
            new TumoConnect();
            TmTcpClient tmTcpClient = new TmTcpClient();
            new Test();
            

            Console.ReadKey();
            Console.WriteLine(TmTimerTool.CurrentTime() + " 退出联接，并关闭程序。");
        }
               

    }
}
