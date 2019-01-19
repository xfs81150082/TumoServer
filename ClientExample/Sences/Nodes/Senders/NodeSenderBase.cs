using Tumo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ClientExample.Sences.Nodes.Senders
{
    public abstract class NodeSenderBase : OnTmTransfer
    {
        public NodeSenderBase()
        {
            TumoNodeSender.Instance.MeasurementSenders.Add(Code, this);
            Console.WriteLine("NodeSenders:" + this.GetType().Name + "  is register.");
        }
    }
}
