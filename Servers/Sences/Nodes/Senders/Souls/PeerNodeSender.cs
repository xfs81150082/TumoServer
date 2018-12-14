using Tumo;
using Tumo.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Servers.Gates;
using Servers;

namespace Servers.Sences.Nodes.Senders.Souls
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
                    TPeer peer1 = TmServerHelper.Instance.GetTcpPeer(mvc.Endpoint);
                    mvc.NineCode = NineCode.Controller;
                    Console.WriteLine(TmServerHelper.Instance.GetCurrentTime() + " EngineerSender:/nine:" + elevenCode + "/" + mvc.NineCode);
                    peer1.SendMsg(mvc);
                    break;
                case (ElevenCode.None):                  
                    break;
                default:
                    break;
            }
        }
        
        
    }
}
