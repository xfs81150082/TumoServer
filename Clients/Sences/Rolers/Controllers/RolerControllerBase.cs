﻿using Tumo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Clients.Sences.Rolers.Controllers
{
    public abstract class RolerControllerBase : MvcBase
    {
        public RolerControllerBase()
        {
            TumoRolerController.Instance.Controllers.Add(Code, this);
            Console.WriteLine("Controller:" + this.GetType().Name + " is register.");
        }

    }
}
