using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Tumo
{
    public class TmSence : TmEntity
    {
        public override void TmAwake()
        {
            base.TmAwake();
            this.AddComponent(new TmSystemManangerDll());
        }
    }
}
