﻿using Tumo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Timers;

namespace Servers.Sences.Nodes.Handlers
{
    public abstract class NodeHandlerBase : TmBase
    {
        private Timer TmTimer;
        private int ValTime = 1000;
        public NodeHandlerBase()
        {
            TumoNodeHandler.Instance.NodeHandlers.Add(Code, this);
            Console.WriteLine("Node:" + this.GetType().Name + " is register.");
        }        
   
     


    }
}
