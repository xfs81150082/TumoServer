using ClientExample;
using Tumo;
using Tumo.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ClientExample.Sences.Nodes.Senders
{
    class PeerNodeSender : NodeSenderBase
    {
        public override string Code => TenCode.Peer.ToString();
        public override void OnTransferParameter(TmRequest mvc)
        {
            ElevenCode elevenCode = mvc.ElevenCode;
            switch (elevenCode)
            {
                case (ElevenCode.HeartBeat):
                    Console.WriteLine(TmTimerTool.GetCurrentTime() + " PeerSender: " + elevenCode);
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
