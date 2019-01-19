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

        public override void OnTransferParameter(TmParameter mvc)
        {
            ElevenCode elevenCode = mvc.ElevenCode;
            switch (elevenCode)
            {
                case (ElevenCode.GetItems):
                    Console.WriteLine(TmTimerTool.GetCurrentTime() + " BookerNode: " + elevenCode);
                    GetItems(mvc);
                    break;
                case (ElevenCode.None):
                    break;
                default:
                    break;
            }
        }

        public BookerNode() {  } 

        private void GetItems(TmParameter mvc)
        {
            Dictionary<int, TmSoulerItem> bookers = TmTransferTool.GetJsonValue<Dictionary<int, TmSoulerItem>>(mvc, mvc.ElevenCode.ToString());
            NodeInfo.Instance.Bookers = bookers;
            Console.WriteLine(TmTimerTool.GetCurrentTime() + " NodeInfo.Instance.Bookers is count: " + NodeInfo.Instance.Bookers.Count);
        }



    }
}
