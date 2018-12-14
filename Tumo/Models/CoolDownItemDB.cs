using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Tumo.Models
{
    public class CoolDownItemDB
    {        
        public int Id { get => id; set => id = value; }
        public string Key { get => key; set => key = value; }
        public int Cdid { get => cdid; set => cdid = value; }
        public int CdTime { get => cdTime; set => cdTime = value; }
        public int CdCount { get => cdCount; set => cdCount = value; }

        private int id = 1;
        private string key;
        private int cdid = 1;
        private int cdTime = 0;
        private int cdCount = 0;
    }
}
