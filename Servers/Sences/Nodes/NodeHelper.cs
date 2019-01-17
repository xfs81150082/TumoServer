using Tumo.Models;
using Tumo;
using Servers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Servers.Sences.Nodes
{
    class NodeHelper
    {
        private static NodeHelper _instance;
        public static NodeHelper Instance { get => _instance; }
        private int gridDisfance = 50;
        private int gridCount = 10;
        //public Dictionary<int, CoolDownItem> BookerCounterItems = new Dictionary<int, CoolDownItem>();
        //public Dictionary<int, CoolDownItem> TeacherCounterItems = new Dictionary<int, CoolDownItem>();

        public NodeHelper() { _instance = this; }

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
        //public List<int> GetNineNodeIds(TPeer peer)
        //{
        //    List<int> nodeIds = new List<int>();
        //    for (int i = 0; i < 3; i++)
        //    {
        //        for (int j = 0; j < 3; j++)
        //        {
        //            int xc = (int)Math.Ceiling(peer.Player.SoulItem.px / gridDisfance);
        //            int yc = (int)Math.Ceiling(peer.Player.SoulItem.pz / gridDisfance);
        //            int xi = xc + i - 1;
        //            int yj = yc + j - 2;
        //            if (xi > 0 && xi <= gridCount && yj > 0 && yj <= gridCount)
        //            {
        //                int nodeId = xi + yj * gridCount;
        //                nodeIds.Add(nodeId);
        //            }
        //        }
        //    }
        //    return nodeIds;
        //}


    }
}
