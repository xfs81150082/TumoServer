using Tumo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Clients.Logins.Controllers
{
    public abstract class LoginControllerBase : MvcBase
    {
        public LoginControllerBase()
        {
            TumoLoginController.Instance.Controllers.Add(Code, this);
            Console.WriteLine("Logins: " + this.GetType().Name + "  is register.");
        }


    }
}
