using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Tumo
{
    public class TmNetClientSystem : TmSystem
    {
        public override void TmAwake()
        {
            base.TmAwake();
            AddComponent(new TmClient());
            AddComponent(new TmSocket());
            AddComponent(new TmTcp());
            AddComponent(new TmRecvQueue());
            AddComponent(new TmSendQueue());
        }

        public override void TmUpdate()
        {

        }
    }
}
