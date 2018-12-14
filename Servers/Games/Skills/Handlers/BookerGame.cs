using Tumo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Servers.Games.Handlers
{
    class BookerGame : GameHandlerBase
    {
        public override string Code => TenCode.Booker.ToString();
        public override void OnTransferParameter(MvcParameter mvc)
        {
            ElevenCode ElevenCode = mvc.ElevenCode;
            switch (ElevenCode)
            {         
                case (ElevenCode.None):
                    break;
                case (ElevenCode.Test):
                    break;
                default:
                    break;
            }
        }

    }
}
