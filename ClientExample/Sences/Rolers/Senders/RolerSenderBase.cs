using Tumo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ClientExample.Sences.Rolers.Senders
{
    public abstract class RolerSenderBase : TmTransfer
    {
        public RolerSenderBase()
        {
            TumoRolerSender.Instance.NodeSenders.Add(Code, this);
            Console.WriteLine("MeasurementSenders:" + this.GetType().Name + "  is register.");
        }
    }
}
