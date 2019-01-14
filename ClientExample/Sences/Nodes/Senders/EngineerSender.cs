﻿using ClientExample;
using Tumo;
using Tumo.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ClientExample.Sences.Nodes.Senders
{
    class EngineerSender : NodeSenderBase
    {
        public override string Code => TenCode.Engineer.ToString();
        public override void OnTransferParameter(MvcParameter mvc)
        {
            ElevenCode elevenCode = mvc.ElevenCode;
            switch (elevenCode)
            {
                case (ElevenCode.HeartBeat):
                    Console.WriteLine(TmTimer.GetCurrentTime() + " EngineerSender: " + elevenCode);
                    mvc.NineCode = NineCode.Handler;
                    TmAsyncTcpClient.Instance.SendMvc(mvc);
                    //TClient.Instance.SendMsg(mvc);
                    break;          
                default:
                    break;
            }
        }

     

    }
}