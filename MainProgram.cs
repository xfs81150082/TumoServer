using Servers.Gates;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Servers.Peers
{
    class MainProgram
    { 
        //程序启动入口
        static void Main(string[] args)
        {
            new PeerHelper();
            new MysqlHelper();
            new TumoGate();
            new SocketListen();

            Console.ReadKey();
            Console.WriteLine("退出监听，并关闭程序。");
        }
    }
}
