using Tumo.Models;
using Tumo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ClientExample.Sences.Rolers
{
    public class RolerInfo
    {
        private static RolerInfo _instance;
        public static RolerInfo Instance { get => _instance; }
        public Dictionary<int, SoulItem> Bookers { get => bookers; set => bookers = value; }
        public Dictionary<int, SoulItem> Teachers { get => teachers; set => teachers = value; }
        public Dictionary<int, SoulItem> Engineers { get => engineers; set => engineers = value; }
        public SoulItem Engineer { get => engineer; set => engineer = value; }

        private Dictionary<int, SoulItem> bookers;
        private Dictionary<int, SoulItem> teachers;
        private Dictionary<int, SoulItem> engineers;
        private SoulItem engineer;   //当前客户端 当前角色

        public RolerInfo()
        {
            _instance = this;
        }


    }
}
