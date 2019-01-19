using Tumo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;

namespace ClientExample
{
    public abstract class ConnectBase : OnTmTransfer
    {
        public ConnectBase()
        {
            TumoConnect.Instance.Connects.Add(Code, this);
            Console.WriteLine("Connect: " + this.GetType().Name + "  is register.");
        }
    }
}
