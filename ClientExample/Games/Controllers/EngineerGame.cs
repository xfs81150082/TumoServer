using Tumo;
using Tumo.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ClientExample.Games.Controllers
{
    class EngineerGame : GameControllerBase
    {
        public override string Code => TenCode.Engineer.ToString();

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

        public EngineerGame()  {    }

        void RecvEngineerItems(TmRequest mvc)
        {
            List<SoulItem> items = TmTransferTool.GetJsonValue<List<SoulItem>>(mvc, "GetItemsByUser");
            Console.WriteLine("EngineerController-items: " + items.Count);
            foreach (var tem in items)
            {
                tem.Coin = 26;
                //UpdateItemdb(tem.CreatSoulItemDB());
            }

            TmRequest mvc2 = TmTransferTool.ToJsonParameter<SoulItem>(NineCode.User, TenCode.EngineerLogin, ElevenCode.Engineer, TwelveCode.SpawnRoler, "SoulItem", items[0]);
            TumoConnect.Instance.OnTransferParameter(mvc2);
        }
        void SpawnRoler(TmRequest mvc)
        {
            SoulItem item = TmTransferTool.GetJsonValue<SoulItem>(mvc, "SoulItem");
            Console.WriteLine("Spawn-Id: " + item.Id + " Name: " + item.Name);        

        }

        void UpdateItemdb(SoulItemDB itemDB)
        {
            TmRequest mvc = TmTransferTool.ToJsonParameter<SoulItemDB>(NineCode.Game, TenCode.Engineer, ElevenCode.UpdateItemdb,TwelveCode.UpdateItemdb, "SoulItemDB", itemDB);
            //TClient.Instance.SendMsg(mvc);
        }
        
      
        
    }
}
