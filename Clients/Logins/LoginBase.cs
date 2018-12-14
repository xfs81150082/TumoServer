using Tumo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Clients.Logins
{
    public abstract class LoginBase : MvcBase
    {
        public LoginBase()
        {
            TumoLogin.Instance.Logins.Add(Code, this);
            Console.WriteLine("Logins: " + this.GetType().Name + " is register.");
        }
    }
}
