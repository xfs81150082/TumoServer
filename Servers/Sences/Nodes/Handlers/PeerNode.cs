using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Timers;
using Tumo;
using Tumo.Models;
using Servers.Sences.Models;

namespace Servers.Sences.Nodes.Handlers
{
    class PeerNode : NodeHandlerBase
    {
        #region OnTransferParameter
        public override string Code => TenCode.Peer.ToString();
        public override void OnTransferParameter(TmParameter mvc)
        {
            ElevenCode elevenCode = mvc.ElevenCode;
            switch (elevenCode)
            {
                case (ElevenCode.HeartBeat):
                    Console.WriteLine(TmTimerTool.CurrentTime() + " EngineerNode: " + elevenCode);
                    //PeerSignIn(mvc);
                    break;
                case (ElevenCode.RemoveHeartBeat):
                    Console.WriteLine(TmTimerTool.CurrentTime() + " EngineerNode: " + elevenCode);
                    //RemovePeerCDItem(mvc);
                    break;
                case (ElevenCode.Test):
                    Console.WriteLine(TmTimerTool.CurrentTime() + " EngineerNode: " + elevenCode);
                    break;
                case (ElevenCode.None):
                    Console.WriteLine(TmTimerTool.CurrentTime() + " EngineerNode: " + elevenCode);
                    break;
                default:
                    break;
            }
        }
        #endregion
                    

    }
}
