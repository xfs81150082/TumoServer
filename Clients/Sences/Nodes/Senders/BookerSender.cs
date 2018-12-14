using Tumo;
using Tumo.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;

namespace Clients.Sences.Nodes.Senders
{
    class BookerSender : NodeSenderBase
    {
        public override string Code => TenCode.Booker.ToString();
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
