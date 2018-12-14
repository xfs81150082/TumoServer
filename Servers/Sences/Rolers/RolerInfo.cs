using Tumo.Models;
using Tumo;
using Servers;
using Servers.Sences.Models;
using Servers.Sences.Rolers.Mysqlers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Servers.Sences.Rolers
{
    class RolerInfo
    {
        private static RolerInfo _instance;
        public static RolerInfo Instance { get => _instance; }
        public Dictionary<int, Player> Players = new Dictionary<int, Player>();
        public Dictionary<int, Monster> Monsters = new Dictionary<int, Monster>();
        public Dictionary<int, Npcer> Npcers = new Dictionary<int, Npcer>();
        public Dictionary<int, List<string>> Endpoints = new Dictionary<int, List<string>>();

        public RolerInfo() { _instance = this; }



    }
}