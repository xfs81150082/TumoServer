using Tumo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Servers.Logins.Handlers
{
    public abstract class HandlerBase : TmBase
    {
        public HandlerBase()
        {
            TumoLoginHandler.Instance.Handlers.Add(Code, this);
            Console.WriteLine("Handlers:" + this.GetType().Name + "  is register.");
        }
    }
}
