using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ClientExample.Sences.Nodes.Senders
{
    class NodeSenderInfo
    {
        private static NodeSenderInfo _instance;
        public static NodeSenderInfo Instance { get => _instance;}

        //public Dictionary<int, Peer> Peers = new Dictionary<int, Peer>();

        public NodeSenderInfo() { _instance = this; }




    }
}
