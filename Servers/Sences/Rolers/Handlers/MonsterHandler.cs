﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Timers;
using Tumo;
using Tumo.Models;
using Servers.Sences.Nodes.Mysqlers;
using Servers;
using Servers.Sences.Models;

namespace Servers.Sences.Rolers.Handlers
{ 
    class MonsterHandler : RolerHandlerBase
    {
        public override string Code => TenCode.Booker.ToString();
        public override void OnTransferParameter(TmParameter mvc)
        {
            ElevenCode elevenCode = mvc.ElevenCode;
            switch (elevenCode)
            {
                case (ElevenCode.None):
                    Console.WriteLine(TmTimerTool.CurrentTime() + " MonsterHandler: " + elevenCode);
                    break;
                default:
                    break;
            }
        }
        public override void TmAwake()
        {

        }
        public override void TmUpdate(ElapsedEventArgs time)
        {

        }

   
    }
}
