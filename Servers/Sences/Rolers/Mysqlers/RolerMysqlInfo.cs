using Tumo.Models;
using Tumo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Servers.Sences.Rolers.Mysqlers
{
    class RolerMysqlInfo
    {
        private static RolerMysqlInfo _instance;
        public static RolerMysqlInfo Instance { get => _instance; }
        
        public Dictionary<int, SoulItem> Engineers = new Dictionary<int, SoulItem>();
        public Dictionary<int, SoulItem> Bookers = new Dictionary<int, SoulItem>();
        public Dictionary<int, SoulItem> Teachers = new Dictionary<int, SoulItem>();


        public RolerMysqlInfo() { _instance = this; Init(); }

        public void Init() { }





    }
}
