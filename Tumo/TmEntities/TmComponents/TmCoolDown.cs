using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Timers;

namespace Tumo
{
    public class TmCoolDown : TmComponent
    {
        public string Key { get; set; }
        public int CdCount { get; set; } = 0;
        public int MaxCdCount { get; set; } = 4;
        public double CdTime { get; set; } = 0.0;
        public double MaxCdTime { get; set; } = 14.0;
        public bool Start { get; set; } = true;
        public bool End { get; set; } = false;
        public bool IsServer { get; set; } = true;
        public TmCoolDown(string key) { this.Key = key; }
        public TmCoolDown() {  }
    }
}
