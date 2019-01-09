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

        public override void OnTransferParameter(MvcParameter mvc)
        {
            ElevenCode elevenCode = mvc.ElevenCode;
            switch (elevenCode)
            {
                case (ElevenCode.SpawnRoler):
                    Console.WriteLine(TimerTool.GetCurrentTime() + " BookerRoler: " + elevenCode);
                    SpawnRoler(mvc);
                    break;
                case (ElevenCode.RemoveRoler):
                    Console.WriteLine(TimerTool.GetCurrentTime() + " BookerRoler: " + elevenCode);
                    RemoveRoler(mvc);
                    break;
                //case (ElevenCode.GetItems):
                //    Console.WriteLine(TimerTool.GetCurrentTime() + " BookerRoler: " + elevenCode);
                //    Getitems(mvc);
                //    break;
                default:
                    break;
            }
        }
        void SpawnRoler(MvcParameter mvc)
        {
            SoulItem soulItem = MvcTool.GetJsonValue<SoulItem>(mvc, mvc.ElevenCode.ToString());
            //RolerInfo.Instance.Bookers.Add(soulItem.Id, soulItem);
            //Console.WriteLine(TimerTool.GetCurrentTime() + " SpawnRoler: " + soulItem.Id + " Bookers: " + RolerInfo.Instance.Bookers.Count);
            //Console.WriteLine(TimerTool.GetCurrentTime() + " SpawnRoler,Id: " + mvc.RolerId);
            Console.WriteLine(TimerTool.GetCurrentTime() + " SpawnRoler,soulItem.Id: " + soulItem.Id);
        }
        void RemoveRoler(MvcParameter mvc)
        {
            //RolerInfo.Instance.Bookers.Remove(int.Parse(mvc.RolerId));
            //Console.WriteLine(TimerTool.GetCurrentTime() + " RemoveRoler,Id: " + mvc.RolerId + " Bookers: " + RolerInfo.Instance.Bookers.Count);
            Console.WriteLine(TimerTool.GetCurrentTime() + " RemoveRoler,Id: " + mvc.RolerId);
        }
        //void Getitems(MvcParameter mvc)
        //{
        //    Dictionary<int, SoulItem> bookers = MvcTool.GetJsonValue<Dictionary<int, SoulItem>>(mvc, mvc.ElevenCode.ToString());
        //    RolerInfo.Instance.Bookers = bookers;
        //    Console.WriteLine(TimerTool.GetCurrentTime() + " Bookers:" + RolerInfo.Instance.Bookers.Count);
        //}

    }
}
