using Tumo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Servers.Games.Handlers
{
    public abstract class GameHandlerBase : MvcBase
    {
        public GameHandlerBase()
        {
            TumoGameHandler.Instance.Handlers.Add(Code, this);
            Console.WriteLine("Handlers:" + this.GetType().Name + "  is register.");
        }
    }
}
