using Tumo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ClientExample.Sences.Rolers
{
    public abstract class RolerBase : TmBase
    {
        public RolerBase()
        {
            TumoRoler.Instance.Rolers.Add(Code, this);
            Console.WriteLine("Rolers:" + this.GetType().Name + "  is register.");
        }

    }
}
