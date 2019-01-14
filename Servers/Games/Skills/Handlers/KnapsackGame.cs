using Tumo;
using Tumo.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Servers.Games.Handlers
{
    class KnapsackGame : GameHandlerBase
    {
        public override string Code => TenCode.Knapsack.ToString();
        public override void OnTransferParameter(MvcParameter sp)
        {
            ElevenCode ElevenCode = sp.ElevenCode;
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

        public KnapsackGame()
        {
            
        }
         


    }
}
