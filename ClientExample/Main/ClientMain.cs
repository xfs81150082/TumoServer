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
            new TumoConnect();
            TmTcpClient tmTcpClient = new TmTcpClient();
            new Test();
            

            Console.ReadKey();
            Console.WriteLine("退出联接，并关闭程序。");
        }
               

    }
}