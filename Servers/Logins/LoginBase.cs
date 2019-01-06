using Tumo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Servers.Logins
{
    public abstract class LoginBase : TmBase
    {
        public LoginBase()
        {
            TumoLogin.Instance.Logins.Add(Code, this);
            Console.WriteLine("Logins:" + this.GetType().Name + " is register.");
        }

    }
}
