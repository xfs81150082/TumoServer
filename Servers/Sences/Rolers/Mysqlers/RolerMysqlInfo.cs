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
        
        public Dictionary<int, TmSoulerItem> Engineers = new Dictionary<int, TmSoulerItem>();
        public Dictionary<int, TmSoulerItem> Bookers = new Dictionary<int, TmSoulerItem>();
        public Dictionary<int, TmSoulerItem> Teachers = new Dictionary<int, TmSoulerItem>();


        public RolerMysqlInfo() { _instance = this; Init(); }

        public void Init() { }





    }
}
