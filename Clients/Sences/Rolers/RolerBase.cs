using Tumo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Clients.Sences.Rolers
{
    public abstract class RolerBase : MvcBase
    {
        public RolerBase()
        {
            TumoRoler.Instance.Rolers.Add(Code, this);
            Console.WriteLine("Rolers:" + this.GetType().Name + "  is register.");
        }

    }
}
