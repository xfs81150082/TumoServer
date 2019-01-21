using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Tumo
{
    public class TmRecvQueue : TmComponent
    {
        public Queue<TmParameter> RecvParameters { get; set; } = new Queue<TmParameter>();
    }
}
