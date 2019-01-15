﻿using Tumo;
using Tumo.Models;
using Servers;
using Servers.Sences.Rolers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Timers;

namespace Servers.Sences.Models
{
    public class SpawnCDitem : TmCoolDown
    {
        public override void TmAwake()
        {
            ValTime = 4000;
        }

        public SpawnCDitem() { }

        public override void TmUpdate()
        {
            UpdateCDTime();
        }

        void UpdateCDTime()
        {
            if (Start)
            {
                CdTime += ValTime/1000;
                if (CdTime > MaxCdTime)
                {
                    Start = false;
                }                
            }
        }

        public override void TmDispose()
        {
            throw new NotImplementedException();
        }

     
    }
}
