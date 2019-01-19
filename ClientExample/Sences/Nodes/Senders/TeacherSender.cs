using Tumo;
using Tumo.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ClientExample.Sences.Nodes.Senders
{
    class TeacherSender : NodeSenderBase
    {
        public override string Code => TenCode.Teacher.ToString();

        public override void OnTransferParameter(TmRequest mvc)
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

        void SpawnRolers(TmSoulerItem roler)
        {
        }

        void SpawnRoler(TmSoulerItem roler)
        {
        }

        void RemoveRoler(TmSoulerItem roler)
        {
        }


    }
}
