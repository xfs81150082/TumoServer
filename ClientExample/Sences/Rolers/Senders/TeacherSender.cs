using Tumo;
using Tumo.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ClientExample.Sences.Rolers.Senders
{
    class TeacherSender : RolerSenderBase
    {
        public override string Code => TenCode.Teacher.ToString();

        public override void OnTransferParameter(MvcParameter mvc)
        {
            ElevenCode elevenCode = mvc.ElevenCode;
            switch (elevenCode)
            {
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
