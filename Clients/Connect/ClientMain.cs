using Clients;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TumoTest.PathFinding;
using TumoTest.RoleLogin;

namespace Clients
{
    class ClientMain
    {
        static void Main(string[] args)
        {
            //new InitFinding(); //Ok 2018.11.23
            //new InitFinding(); //Ok 2018.12.14
            //new InitRoleLogin(); //Ok 2018.11.22

            new TmClientHelper();
            new TumoConnect();
            TmTcpClient tmTcpClient = new TmTcpClient();
            tmTcpClient.StartConnect();
            new Test();
            

            Console.ReadKey();
            Console.WriteLine("退出联接，并关闭程序。");
        }

       

    }
}
