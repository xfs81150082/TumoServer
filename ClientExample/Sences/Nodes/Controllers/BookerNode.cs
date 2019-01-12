using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Timers;
using ClientExample;
using Tumo;
using Tumo.Models;

namespace ClientExample.Sences.Nodes.Controllers
{
    class BookerNode : NodeCotrollerBase
    {
        public override string Code => TenCode.Booker.ToString();

        public override void OnTransferParameter(MvcParameter mvc)
        {
            ElevenCode elevenCode = mvc.ElevenCode;
            switch (elevenCode)
            {
                case (ElevenCode.GetItems):
                    Console.WriteLine(TmTimer.GetCurrentTime() + " BookerNode: " + elevenCode);
                    GetItems(mvc);
                    break;
                case (ElevenCode.None):
                    break;
                default:
                    break;
            }
        }

        public BookerNode() {  } 

        private void GetItems(MvcParameter mvc)
        {
            Dictionary<int, SoulItem> bookers = MvcTool.GetJsonValue<Dictionary<int, SoulItem>>(mvc, mvc.ElevenCode.ToString());
            NodeInfo.Instance.Bookers = bookers;
            Console.WriteLine(TmTimer.GetCurrentTime() + " NodeInfo.Instance.Bookers is count: " + NodeInfo.Instance.Bookers.Count);
        }



    }
}
