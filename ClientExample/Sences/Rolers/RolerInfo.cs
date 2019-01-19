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
        public Dictionary<int, TmSoulerItem> Bookers { get => bookers; set => bookers = value; }
        public Dictionary<int, TmSoulerItem> Teachers { get => teachers; set => teachers = value; }
        public Dictionary<int, TmSoulerItem> Engineers { get => engineers; set => engineers = value; }
        public TmSoulerItem Engineer { get => engineer; set => engineer = value; }

        private Dictionary<int, TmSoulerItem> bookers;
        private Dictionary<int, TmSoulerItem> teachers;
        private Dictionary<int, TmSoulerItem> engineers;
        private TmSoulerItem engineer;   //当前客户端 当前角色

        public RolerInfo()
        {
            _instance = this;
        }


    }
}
