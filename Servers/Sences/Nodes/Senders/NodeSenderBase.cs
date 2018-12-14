using Tumo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Servers.Sences.Nodes.Senders
{
    public abstract class NodeSenderBase : MvcBase
    {
        public NodeSenderBase()
        {
            TumoNodeSender.Instance.NodeSenders.Add(Code, this);
            Console.WriteLine("MeasurementSenders:" + this.GetType().Name + "  is register.");
        }
    }
}
