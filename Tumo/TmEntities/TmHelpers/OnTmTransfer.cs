﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Tumo
{
    public abstract class OnTmTransfer
    {
        public abstract string Code { get; }
        public abstract void OnTransferParameter(TmParameter mvc);
    }
}