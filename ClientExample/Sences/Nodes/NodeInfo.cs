using Tumo.Models;
using Tumo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ClientExample.Sences.Nodes
{
    class NodeInfo
    {
        private static NodeInfo _instance;
        public static NodeInfo Instance { get => _instance; }

        public int gridCount = 10;
        public int gridDisfance = 50;
        public NodeItem[,] MapNodes = new NodeItem[10, 10];
        public Dictionary<int, NodeItem> MeasurementNodeItems = new Dictionary<int, NodeItem>();                                                      //计量村地图100个节点，每个节点里有三个列表分别为engineers,bookers,teachers;其中2个不变，1个可变的。
        public Dictionary<int, SoulItem> Engineers = new Dictionary<int, SoulItem>();
        public Dictionary<int, SoulItem> Bookers = new Dictionary<int, SoulItem>();
        public Dictionary<int, SoulItem> Teachers = new Dictionary<int, SoulItem>();
        public SoulItem Engineer { get; set; }                 

        public NodeInfo() { _instance = this; Init(); }

        public void Init() { }

        public List<int[,]> GetNineIds(TmTransform transform)
        {
            List<int[,]> nodeIds = new List<int[,]>();
            for (int i = 0; i < 3; i++)
            {
                for (int j = 0; j < 3; j++)
                {
                    int xc = (int)Math.Floor(transform.px / gridDisfance);
                    int zc = (int)Math.Floor(transform.pz / gridDisfance);
                    int xi = xc + i - 1;
                    int zj = zc + j - 1;
                    if (xi > 0 && xi <= gridCount && zj > 0 && zj <= gridCount)
                    {
                        int[,] Idxz = new int[xi, zj];
                        nodeIds.Add(Idxz);
                    }
                }
            }
            return nodeIds;
        }
        public List<int> GetNineNodeIds(TmTransform transform)
        {
            List<int> nodeIds = new List<int>();
            for (int i = 0; i < 3; i++)
            {
                for (int j = 0; j < 3; j++)
                {
                    int xc = (int)Math.Ceiling(transform.px / gridDisfance);
                    int yc = (int)Math.Ceiling(transform.pz / gridDisfance);
                    int xi = xc + i - 1;
                    int yj = yc + j - 2;
                    if (xi > 0 && xi <= gridCount && yj > 0 && yj <= gridCount)
                    {
                        int nodeId = xi + yj * gridCount;
                        nodeIds.Add(nodeId);
                    }
                }
            }
            return nodeIds;
        }



    }
}
