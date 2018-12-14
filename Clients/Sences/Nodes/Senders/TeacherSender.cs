using Tumo;
using Tumo.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Clients.Sences.Nodes.Senders
{
    class TeacherSender : NodeSenderBase
    {
        public override string Code => TenCode.Teacher.ToString();

        public override void OnTransferParameter(MvcParameter mvc)
        {
            TwelveCode twelveCode = mvc.TwelveCode;
            switch (twelveCode)
            {           
                case (TwelveCode.None):
                   
                    break;
                default:
                    break;
            }
        }

        void SpawnRolers(SoulItem roler)
        {
        }

        void SpawnRoler(SoulItem roler)
        {
        }

        void RemoveRoler(SoulItem roler)
        {
        }


    }
}
