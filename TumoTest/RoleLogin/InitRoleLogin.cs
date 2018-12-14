using Clients;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace TumoTest.RoleLogin
{
     class InitRoleLogin
    {
        public InitRoleLogin()
        {
            new TmClientHelper();
            new TumoConnect();
            TmTcpClient tmTcpClient = new TmTcpClient();
            tmTcpClient.StartConnect();
            new Test();
        }

    }
}
