using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Timers;

namespace Tumo
{
    public abstract class TmCoolDown : TmSystem
    {       
        public string Key { get; set; }
        public int CdCount { get; set; } = 0;
        public int MaxCdCount { get; set; } = 4;
        public double CdTime { get; set; } = 0.0;
        public double MaxCdTime { get; set; } = 14.0;
        public bool Start { get; set; }
        public bool End { get; set; }
        public TmCoolDown() { }
    }
}
