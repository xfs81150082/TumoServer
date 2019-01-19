using Tumo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ClientExample.Sences.Nodes
{
    public abstract class NodeBase : OnTmTransfer
    {
        public NodeBase()
        {
            TumoNode.Instance.Nodes.Add(Code, this);
            Console.WriteLine("Node:" + this.GetType().Name + " is register.");
        }

    }
}
