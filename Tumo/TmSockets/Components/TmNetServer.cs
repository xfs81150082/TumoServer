using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Tumo
{
    public class TmNetServer : TmEntity
    {
        public override void TmAwake()
        {
            base.TmAwake();
            AddComponent(new TmServer());
            AddComponent(new TmSocket());
            AddComponent(new TmTcp());
            AddComponent(new TmRecvQueue());
            AddComponent(new TmSendQueue());
        }
    }
}
