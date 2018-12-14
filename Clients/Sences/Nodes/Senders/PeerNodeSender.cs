﻿using Clients;
using Tumo;
using Tumo.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Clients.Sences.Nodes.Senders
{
    class PeerNodeSender : NodeSenderBase
    {
        public override string Code => TenCode.Peer.ToString();
        public override void OnTransferParameter(MvcParameter mvc)
        {
            ElevenCode elevenCode = mvc.ElevenCode;
            switch (elevenCode)
            {
                case (ElevenCode.HeartBeat):
                    Console.WriteLine(TmClientHelper.Instance.GetCurrentTime() + " EngineerSender: " + elevenCode);
                    mvc.NineCode = NineCode.Handler;
                    TClient.Instance.SendMsg(mvc);
                    break;          
                default:
                    break;
            }
        }

     

    }
}
