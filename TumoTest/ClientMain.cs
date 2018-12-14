using Clients;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TumoTest.PathFinding;
using TumoTest.RoleLogin;

namespace TumoTest
{
    class ClientMain
    {
        static void Main(string[] args)
        {
            //new InitFinding(); //Ok 2018.11.23

            new InitRoleLogin(); //Ok 2018.11.22


            Console.ReadKey();
            Console.WriteLine("退出联接，并关闭程序。");
        }


    }
}
