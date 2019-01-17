using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Timers;
using Tumo;
using Tumo.Models;

namespace ClientExample.Sences.Rolers.Controllers
{ 
    class BookerRoler : RolerControllerBase
    {
        public override string Code => TenCode.Booker.ToString();

        public override void OnTransferParameter(TmRequest mvc)
        {
            ElevenCode elevenCode = mvc.ElevenCode;
            switch (elevenCode)
            {
                case (ElevenCode.SpawnRoler):
                    Console.WriteLine(TmTimerTool.GetCurrentTime() + " BookerRoler: " + elevenCode);
                    //SpawnRoler(mvc);
                    break;
                case (ElevenCode.RemoveRoler):
                    Console.WriteLine(TmTimerTool.GetCurrentTime() + " BookerRoler: " + elevenCode);
                    //RemoveRoler(mvc);
                    break;
                //case (ElevenCode.GetItems):
                //    Console.WriteLine(TmTimer.GetCurrentTime() + " BookerRoler: " + elevenCode);
                //    Getitems(mvc);
                //    break;
                default:
                    break;
            }
        }
        //void SpawnRoler(TmRequest mvc)
        //{
        //    TmSoulerItem soulItem = TmTransferTool.GetJsonValue<TmSoulerItem>(mvc, mvc.ElevenCode.ToString());
        //    //RolerInfo.Instance.Bookers.Add(soulItem.Id, soulItem);
        //    //Console.WriteLine(TmTimer.GetCurrentTime() + " SpawnRoler: " + soulItem.Id + " Bookers: " + RolerInfo.Instance.Bookers.Count);
        //    //Console.WriteLine(TmTimer.GetCurrentTime() + " SpawnRoler,Id: " + mvc.RolerId);
        //    //Console.WriteLine(TmTimerTool.GetCurrentTime() + " SpawnRoler,soulItem.Id: " + soulItem.Id);
        //}
        //void RemoveRoler(TmRequest mvc)
        //{
        //    //RolerInfo.Instance.Bookers.Remove(int.Parse(mvc.RolerId));
        //    //Console.WriteLine(TmTimer.GetCurrentTime() + " RemoveRoler,Id: " + mvc.RolerId + " Bookers: " + RolerInfo.Instance.Bookers.Count);
        //    Console.WriteLine(TmTimerTool.GetCurrentTime() + " RemoveRoler,Id: " + mvc.RolerId);
        //}
        ////void Getitems(MvcParameter mvc)
        //{
        //    Dictionary<int, SoulItem> bookers = MvcTool.GetJsonValue<Dictionary<int, SoulItem>>(mvc, mvc.ElevenCode.ToString());
        //    RolerInfo.Instance.Bookers = bookers;
        //    Console.WriteLine(TmTimer.GetCurrentTime() + " Bookers:" + RolerInfo.Instance.Bookers.Count);
        //}

    }
}
