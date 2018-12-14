﻿using Tumo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Clients.Logins.Senders
{
    public abstract class LoginSenderBase : MvcBase
    {
        public LoginSenderBase()
        {
            TumoLoginSender.Instance.Senders.Add(Code, this);
            Console.WriteLine("Senders: " + this.GetType().Name + "  is register.");
        }

    }
}
