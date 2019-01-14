using Tumo;
using Tumo.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
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
                    Console.WriteLine(TmTimer.GetCurrentTime() + " PeerNodeSender:" + elevenCode);
                    mvc.NineCode = NineCode.Controller;
                    //TPeer peer1 = TmServerHelper.Instance.GetTcpPeer(mvc.Endpoint);
                    //if (peer1 != null)
                    //{
                    //    peer1.SendMsg(mvc);
                    //}
                    TmAsyncTcpServer.Instance.SendMvc(mvc);
                    break;
                case (ElevenCode.None):                  
                    break;
                default:
                    break;
            }
        }
        
        
    }
}
