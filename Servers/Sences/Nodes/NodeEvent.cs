using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Servers.Sences.Nodes
{
    class NodeEvent
    {
        private static NodeEvent _instance;
        internal static NodeEvent Instance { get => _instance; }
        public NodeEvent() { _instance = this; }

        public delegate void  OnGetBookersEvent(string endpoint);
        public event OnGetBookersEvent OnGetBookers;

        public void GetBookers(string endpoint)
        {
            OnGetBookers(endpoint);
        }


    }
}
