﻿using Tumo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Clients.Sences.Nodes.Controllers
{
    public abstract class NodeCotrollerBase : MvcBase
    {
        public NodeCotrollerBase()
        {
            TumoNodeController.Instance.MeasurementNodes.Add(Code, this);
            Console.WriteLine("Node:" + this.GetType().Name + " is register.");
        }

    }
}
