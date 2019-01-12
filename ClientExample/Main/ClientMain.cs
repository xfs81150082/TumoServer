﻿using ClientExample;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ClientExample
{
    class ClientMain
    {
        static void Main(string[] args)
        {
            new TmClientHelper();
            new TumoConnect();
            TmTcpClient tmTcpClient = new TmTcpClient();
            tmTcpClient.Init("127.0.0.1", 8115);
            tmTcpClient.StartConnect();
            new Test();
            

            Console.ReadKey();
            Console.WriteLine("退出联接，并关闭程序。");
        }
               

    }
}
