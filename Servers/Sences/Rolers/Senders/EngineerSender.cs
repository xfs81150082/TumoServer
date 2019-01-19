using Tumo;
using Tumo.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Servers;

namespace Servers.Sences.Rolers.Senders
{
    class EngineerSender : RolerSenderBase
    {
        public override string Code => TenCode.Engineer.ToString();
        public override void OnTransferParameter(TmParameter mvc)
        {
            ElevenCode elevenCode = mvc.ElevenCode;
            switch (elevenCode)
            {            
                case (ElevenCode.None):
                    Console.WriteLine(TmTimerTool.CurrentTime() + " EngineerSender: " + elevenCode);
                    break;
                default:
                    break;
            }
        }
        
        
    }
}
