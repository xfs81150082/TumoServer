using Tumo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Servers.Sences.Nodes.Mysqlers
{
    public abstract class NodeMysqlBase : MvcBase
    {
        public NodeMysqlBase()
        {
            TumoNodeMysql.Instance.NodeMysqlers.Add(Code, this);
            Console.WriteLine("MeasurementMysqls:" + this.GetType().Name + " is register.");
        }
    }
}
