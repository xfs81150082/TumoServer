using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Tumo
{
    public abstract class TmTransfer : TmEntity
    {
        public abstract void OnTransferParameter(TmParameter parameter);
    }
}
