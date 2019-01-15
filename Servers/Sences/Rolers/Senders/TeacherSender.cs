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
    class TeacherSender : RolerSenderBase
    {
        public override string Code => TenCode.Teacher.ToString();

        public override void OnTransferParameter(MvcParameter mvc)
        {
            ElevenCode elevenCode = mvc.ElevenCode;
            switch (elevenCode)
            {                
                case (ElevenCode.None):
                    Console.WriteLine(TmTimerTool.GetCurrentTime() + " TeacherSender: " + elevenCode);
                    break;
                default:
                    break;
            }
        }

        
    }
}
