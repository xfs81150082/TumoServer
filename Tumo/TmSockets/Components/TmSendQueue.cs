using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Tumo
{
    public class TmSendQueue : TmComponent
    {
        public Queue<TmParameter> SendParameters { get; set; } = new Queue<TmParameter>();
    }
}
