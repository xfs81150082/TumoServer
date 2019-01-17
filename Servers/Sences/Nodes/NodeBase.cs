using Tumo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Servers.Sences.Nodes
{
    public abstract class NodeBase : TmTransfer
    {
        public NodeBase()
        {
            TumoNode.Instance.MeasurementNodes.Add(Code, this);
            Console.WriteLine("Node:" + this.GetType().Name + " is register.");
        }

    }
}
