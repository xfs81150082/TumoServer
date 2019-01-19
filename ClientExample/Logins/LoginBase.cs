using Tumo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ClientExample.Logins
{
    public abstract class LoginBase : OnTmTransfer
    {
        public LoginBase()
        {
            TumoLogin.Instance.Logins.Add(Code, this);
            Console.WriteLine("Logins: " + this.GetType().Name + " is register.");
        }
    }
}
