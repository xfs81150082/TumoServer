﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Tumo
{
    public class TmName : TmComponent
    {
        public string Name { get; set; } = "tumo";
        public int Id { get; set; } = 100001;
        public int ParentId { get; set; } = 0;
    }
}
