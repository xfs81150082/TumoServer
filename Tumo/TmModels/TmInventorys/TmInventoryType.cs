using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Tumo
{
    public class TmInventoryType : TmComponent
    {
        public Place Place { get; set; }
        public int Count { get; set; }
        public int Durability { get; set; }
    }
}
