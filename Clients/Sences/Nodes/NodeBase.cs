﻿using Tumo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Clients.Sences.Nodes
{
    public abstract class NodeBase : MvcBase
    {
        public NodeBase()
        {
            TumoNode.Instance.Nodes.Add(Code, this);
            Console.WriteLine("Node:" + this.GetType().Name + " is register.");
        }

    }
}
