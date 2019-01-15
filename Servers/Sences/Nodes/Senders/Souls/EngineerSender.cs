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
    class EngineerSender : NodeSenderBase
    {
        public override string Code => TenCode.Engineer.ToString();
        public override void OnTransferParameter(MvcParameter mvc)
        {
            ElevenCode elevenCode = mvc.ElevenCode;
            switch (elevenCode)
            {
                case (ElevenCode.HeartBeat):
                    TPeer peer1 = TmAsyncTcpServer.Instance.GetTPeer(mvc.EcsId);
                    mvc.NineCode = NineCode.Controller;
                    //Console.WriteLine(TmTimer.GetCurrentTime() + " EngineerSender:/nine:" + elevenCode + "/" + mvc.NineCode);
                    //peer1.SendMsg(mvc);
                    TmAsyncTcpServer.Instance.SendMvc(mvc);
                    break;
                case (ElevenCode.EngineerLogin):
                    Console.WriteLine(TmTimerTool.GetCurrentTime() + " EngineerSender: " + elevenCode);
                    mvc.NineCode = NineCode.Controller;
                    //TPeer peer2 = TmServerHelper.Instance.GetTcpPeer(mvc.Endpoint);
                    //peer2.SendMsg(mvc);
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
