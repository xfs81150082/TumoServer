﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Tumo
{
    public abstract class TmBase
    {
        public abstract string Code { get; }
        public abstract void OnTransferParameter(MvcParameter mvc);
    }
}