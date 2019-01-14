using Tumo.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;

namespace ClientExample.Sences.Nodes.Controllers
{
    class NodeControllerInfo
    {
        private static NodeControllerInfo _instance;
        public static NodeControllerInfo Instance { get => _instance;}

        //private int gridCount = 10;
        //private int gridDisfance = 100;
        public Dictionary<int, NodeItem> MeasurementNodeItems = new Dictionary<int, NodeItem>(); //计量村地图100个节点，每个节点里有三个列表分别为engineers,bookers,teachers;其中2个不变，1个可变的。

        public Dictionary<int, SoulItem> Engineers = new Dictionary<int, SoulItem>();
        public Dictionary<int, SoulItem> Bookers = new Dictionary<int, SoulItem>();
        public Dictionary<int, SoulItem> Teachers = new Dictionary<int, SoulItem>();
             
        public NodeControllerInfo() { _instance = this; Init(); }

        public void Init() { }
                     



    }
}
