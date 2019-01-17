using Tumo;
using Tumo.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ClientExample.Games.Controllers
{
    class BookerGame : GameControllerBase
    {
        public override string Code => ElevenCode.Booker.ToString();

        public override void OnTransferParameter(TmRequest mvc)
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

        public BookerGame()
        {

        }

        void SpawnRolers(TmRequest mvc)
        {
            Dictionary<int, SoulItem> items = TmTransferTool.GetJsonValue<Dictionary<int, SoulItem>>(mvc, "SoulItems");
            Console.WriteLine("BookerController-SpawnItems: " + items.Count);
        }

        void SpawnRoler(TmRequest mvc)
        {
            SoulItem item = TmTransferTool.GetJsonValue<SoulItem>(mvc, "SoulItem");
            Console.WriteLine("SpawnRoler: " + item.Name + item.Id);

        }
        void RemoveRoler(TmRequest mvc)
        {
            SoulItem item = TmTransferTool.GetJsonValue<SoulItem>(mvc, "SoulItem");
            Console.WriteLine("RemoveRoler: " + item.Name + item.Id);

        }




    }
}
