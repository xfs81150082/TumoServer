using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tumo;
using Tumo;

namespace Servers.Games.Senders.Games
{
    class EngineerGame : GameSenderBase
    {
        public override string Code => TenCode.Engineer.ToString();

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
