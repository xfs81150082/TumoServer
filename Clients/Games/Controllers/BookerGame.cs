using Tumo;
using Tumo.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Clients.Games.Controllers
{
    class BookerGame : GameControllerBase
    {
        public override string Code => ElevenCode.Booker.ToString();

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

        public BookerGame()
        {

        }

        void SpawnRolers(MvcParameter mvc)
        {
            Dictionary<int, SoulItem> items = MvcTool.GetJsonValue<Dictionary<int, SoulItem>>(mvc, "SoulItems");
            Console.WriteLine("BookerController-SpawnItems: " + items.Count);
        }

        void SpawnRoler(MvcParameter mvc)
        {
            SoulItem item = MvcTool.GetJsonValue<SoulItem>(mvc, "SoulItem");
            Console.WriteLine("SpawnRoler: " + item.Name + item.Id);

        }
        void RemoveRoler(MvcParameter mvc)
        {
            SoulItem item = MvcTool.GetJsonValue<SoulItem>(mvc, "SoulItem");
            Console.WriteLine("RemoveRoler: " + item.Name + item.Id);

        }




    }
}
