using Tumo;
using Servers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Timers;

namespace Servers.Sences.Nodes.Handlers
{
    class BookerNode : NodeHandlerBase
    {
        public override string Code => TenCode.Booker.ToString();

        public override void OnTransferParameter(TmRequest mvc)
        {
            ElevenCode elevenCode = mvc.ElevenCode;
            switch (elevenCode)
            {
                case (ElevenCode.GetItems):
                    Console.WriteLine(TmTimerTool.GetCurrentTime() + " BookerNode: " + elevenCode);
                    mvc.NineCode = NineCode.Mysqler;
                    TumoNode.Instance.OnTransferParameter(mvc);
                    break;
                case (ElevenCode.None):
                    Console.WriteLine(TmTimerTool.GetCurrentTime() + " BookerNode: " + elevenCode);
                    break;
                default:
                    break;
            }
        }
         

              
    }
}
