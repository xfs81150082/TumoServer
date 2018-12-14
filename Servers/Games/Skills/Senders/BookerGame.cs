using Tumo;
using Tumo.Models;
using Tumo;
using Tumo;
using Servers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Servers.Games.Senders.Games
{
    class BookerGame : GameSenderBase
    {
        public override string Code => TenCode.User.ToString();
        public override void OnTransferParameter(MvcParameter mvc)
        {
            ElevenCode elevenCode = mvc.ElevenCode;         
            switch (elevenCode)
            {             
                case (ElevenCode.None):
                    break;
                default:
                    break;
            }
        }

    }
}
