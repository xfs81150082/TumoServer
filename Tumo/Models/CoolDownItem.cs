using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Timers;

namespace Tumo
{
    public abstract class CoolDownItem : TmMonoBehaviour
    {
        public int Id { get => id; set => id = value; }
        public string Key { get => key; set => key = value; }
        public CoolDown CoolDown { get => coolDown; set => coolDown = value; }
        public int CdCount { get => cdCount; set => cdCount = value; }
        public int CdTime { get => cdTime; set => cdTime = value; }
        public bool Start { get => start; set => start = value; }
        public bool End { get => end; set => end = value; }

        private int id = 1;
        private string key;
        private CoolDown coolDown = new CoolDown(14, 4);
        private int cdCount = 0;
        private int cdTime = 0;
        private bool start = false;
        private bool end = false;
        public CoolDownItem() { }

    }
}
