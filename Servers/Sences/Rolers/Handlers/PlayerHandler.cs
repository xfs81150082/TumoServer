﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;
using System.Timers;
using Tumo;
using Tumo.Models;
using Servers;
using Servers.Sences.Models;

namespace Servers.Sences.Rolers.Handlers
{
    class PlayerHandler : RolerHandlerBase
    {
        public override string Code => TenCode.Engineer.ToString();
        public override void OnTransferParameter(TmParameter mvc)
        {
            ElevenCode elevenCode = mvc.ElevenCode;
            switch (elevenCode)
            {
                case (ElevenCode.None):
                    Console.WriteLine(TmTimerTool.GetCurrentTime() + " EngineerRolerHandler: " + elevenCode);
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
