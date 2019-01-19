using Tumo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Servers
{
    public abstract class GateBase : OnTmTransfer
    {
        public GateBase()
        {
            TumoGate.Instance.Gates.Add(Code, this);
            Console.WriteLine("Gate:" + this.GetType().Name + "  is register.");
        }
    }
}
