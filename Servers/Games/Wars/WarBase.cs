using Tumo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Servers.Wars
{
    public abstract class WarBase : TmBase
    {
        public WarBase()
        {
            TumoWar.Instance.Wars.Add(Code, this);
            Console.WriteLine("War:" + this.GetType().Name + "  is register.");
        }

    }
}
