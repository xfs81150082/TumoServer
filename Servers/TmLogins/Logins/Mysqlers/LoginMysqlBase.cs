using Tumo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Servers.Logins.Mysqlers
{
    public abstract class LoginMysqlBase : TmTransfer
    {
        public LoginMysqlBase()
        {
            TumoLoginMysql.Instance.LoginMysqls.Add(Code, this);
            Console.WriteLine("LoginMysqls: " + this.GetType().Name + " is register.");
        }

    }
}
