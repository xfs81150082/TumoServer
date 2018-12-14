﻿using Tumo;
using Tumo.Models;
using Servers.Gates;
using Servers;
using Servers.Sences.Models;
using Servers.Sences.Rolers.Mysqlers;
using System;

namespace Servers.Sences.Rolers.Senders
{
    class BookerSender : RolerSenderBase
    {
        public override string Code => TenCode.Booker.ToString();
        public override void OnTransferParameter(MvcParameter mvc)
        {
            ElevenCode elevenCode = mvc.ElevenCode;
            switch (elevenCode)
            {                
                case (ElevenCode.None):
                    Console.WriteLine(TmServerHelper.Instance.GetCurrentTime() + " BookerSender: " + elevenCode);
                    break;
                default:
                    break;
            }
        }


    }
}
