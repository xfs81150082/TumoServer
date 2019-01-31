using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Tumo
{
    public class TmSystemManangerDll : TmEntity
    {
        public override void TmAwake()
        {
            base.TmAwake();
            AddComponent(new TmSessionCDSystem());
        }
    }
}
