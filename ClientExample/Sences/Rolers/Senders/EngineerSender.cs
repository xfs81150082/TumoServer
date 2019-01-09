using Tumo;
using Tumo.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ClientExample.Sences.Rolers.Senders
{
    class EngineerSender : RolerSenderBase
    {
        public override string Code => TenCode.Engineer.ToString();
        public override void OnTransferParameter(MvcParameter mvc)
        {
            ElevenCode elevenCode = mvc.ElevenCode;
            switch (elevenCode)
            {
                case (ElevenCode.SyncMoveState):
                    Console.WriteLine(TimerTool.GetCurrentTime() + " EngineerRoler: " + elevenCode);
                    mvc.NineCode = NineCode.Handler;
                    TumoRoler.Instance.OnTransferParameter(mvc);
                    break;
                case (ElevenCode.SpawnRoler):

                    break;
                case (ElevenCode.RemoveRoler):

                    break;
                default:
                    break;
            }
        }
        
        
    }
}
