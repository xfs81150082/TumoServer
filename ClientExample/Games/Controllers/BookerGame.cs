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

        public override void OnTransferParameter(TmParameter mvc)
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

        void SpawnRolers(TmParameter mvc)
        {
            Dictionary<int, TmSoulerItem> items = TmTransferTool.GetJsonValue<Dictionary<int, TmSoulerItem>>(mvc, "SoulItems");
            Console.WriteLine("BookerController-SpawnItems: " + items.Count);
        }

        //void SpawnRoler(TmRequest mvc)
        //{
        //    TmSoulerItem item = TmTransferTool.GetJsonValue<TmSoulerItem>(mvc, "SoulItem");
        //    Console.WriteLine("SpawnRoler: " + item.Name + item.Id);

        //}
        //void RemoveRoler(TmRequest mvc)
        //{
        //    TmSoulerItem item = TmTransferTool.GetJsonValue<TmSoulerItem>(mvc, "SoulItem");
        //    Console.WriteLine("RemoveRoler: " + item.Name + item.Id);

        //}




    }
}
