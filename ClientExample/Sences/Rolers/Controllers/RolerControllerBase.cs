using Tumo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ClientExample.Sences.Rolers.Controllers
{
    public abstract class RolerControllerBase : TmBase
    {
        public RolerControllerBase()
        {
            TumoRolerController.Instance.Controllers.Add(Code, this);
            Console.WriteLine("Controller:" + this.GetType().Name + " is register.");
        }

    }
}
