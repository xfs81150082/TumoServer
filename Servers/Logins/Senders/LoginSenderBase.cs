using Tumo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Servers.Logins.Senders
{
    public abstract class LoginSenderBase : MvcBase
    {
        public LoginSenderBase()
        {
            TumoLoginSender.Instance.Logins.Add(Code, this);
            Console.WriteLine("Logins: " + this.GetType().Name + " is register.");
        }

    }
}
