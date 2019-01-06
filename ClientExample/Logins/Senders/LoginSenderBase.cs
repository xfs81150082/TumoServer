﻿using Tumo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ClientExample.Logins.Senders
{
    public abstract class LoginSenderBase : TmBase
    {
        public LoginSenderBase()
        {
            TumoLoginSender.Instance.Senders.Add(Code, this);
            Console.WriteLine("Senders: " + this.GetType().Name + "  is register.");
        }

    }
}
