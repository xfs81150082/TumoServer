using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
namespace Tumo
{
    public class TmSession : TmComponent
    {
        public int bookersChange { get; set; } = -1;
        public int teachersChange { get; set; } = -1;
        public int engineersChange { get; set; } = -1;
    }
}
