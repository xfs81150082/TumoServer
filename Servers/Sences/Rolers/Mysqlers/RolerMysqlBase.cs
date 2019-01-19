using Tumo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Servers.Sences.Rolers.Mysqlers
{
    public abstract class RolerMysqlBase : OnTmTransfer
    {
        public RolerMysqlBase()
        {
            TumoRolerMysql.Instance.RolerMysqls.Add(Code, this);
            Console.WriteLine("RolerMysqls:" + this.GetType().Name + " is register.");
        }
    }
}
