using Tumo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Servers.Sences.Rolers
{
    public abstract class RolerBase : MvcBase
    {
        public RolerBase()
        {
            TumoRoler.Instance.Rolers.Add(Code, this);
            Console.WriteLine("Roler:" + this.GetType().Name + "  is register.");
        }

    }
}
