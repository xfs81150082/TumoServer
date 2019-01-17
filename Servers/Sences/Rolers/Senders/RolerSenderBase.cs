using Tumo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Servers.Sences.Rolers.Senders
{
    public abstract class RolerSenderBase : TmTransfer
    {
        public RolerSenderBase()
        {
            TumoRolerSender.Instance.RolerSenders.Add(Code, this);
            Console.WriteLine("RolerSenders:" + this.GetType().Name + "  is register.");
        }
    }
}
