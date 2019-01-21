using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Tumo
{
    public static class TmQueue
    {
        public static Queue<TmParameter> RecvParameters { get; set; } = new Queue<TmParameter>();
        public static Queue<TmParameter> SendParameters { get; set; } = new Queue<TmParameter>();
    }
}
