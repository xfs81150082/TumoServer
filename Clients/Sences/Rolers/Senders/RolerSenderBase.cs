﻿using Tumo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Clients.Sences.Rolers.Senders
{
    public abstract class RolerSenderBase : MvcBase
    {
        public RolerSenderBase()
        {
            TumoRolerSender.Instance.NodeSenders.Add(Code, this);
            Console.WriteLine("MeasurementSenders:" + this.GetType().Name + "  is register.");
        }
    }
}
