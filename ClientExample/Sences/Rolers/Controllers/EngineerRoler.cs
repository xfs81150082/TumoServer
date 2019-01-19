using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Timers;
using Tumo;
using Tumo.Models;

namespace ClientExample.Sences.Rolers.Controllers
{
    class EngineerRoler : RolerControllerBase
    {
        public override string Code => TenCode.Engineer.ToString();
        public override void OnTransferParameter(TmParameter mvc)
        {
            ElevenCode elevenCode = mvc.ElevenCode;
            switch (elevenCode)
            {
                //case (ElevenCode.SpawnRoler):
                //    Console.WriteLine(TmTimer.GetCurrentTime() + " EngineerRoler: " + elevenCode);
                //    SpawnRoler(mvc);
                //    break;
                //case (ElevenCode.RemoveRoler):
                //    Console.WriteLine(TmTimer.GetCurrentTime() + " EngineerRoler: " + elevenCode);
                //    RemoveRoler(mvc);
                //    break;
                //case (ElevenCode.SyncMoveState):
                //    Console.WriteLine(TmTimer.GetCurrentTime() + " EngineerRoler: " + elevenCode);
                //    SyncMoveState(mvc);
                //    break;
                case (ElevenCode.Test):
                    Console.WriteLine(TmTimerTool.GetCurrentTime() + " EngineerRoler: " + elevenCode);
                    Test(mvc);
                    break;
                default:
                    break;
            }
        }

        private void Test(TmParameter mvc)
        {
            int count = TmTransferTool.GetJsonValue<int>(mvc, mvc.ElevenCode.ToString());
            Console.WriteLine(TmTimerTool.GetCurrentTime() + " count: " + count);
        }

        public EngineerRoler(){   }

        //void SpawnRoler(TmRequest mvc)
        //{
        //    TmSoulerItem soulItem = TmTransferTool.GetJsonValue<TmSoulerItem>(mvc, mvc.ElevenCode.ToString());
        //    RolerInfo.Instance.Engineers.Add(soulItem.Id, soulItem);
        //    Console.WriteLine(TmTimerTool.GetCurrentTime() + " Name: " + RolerInfo.Instance.Engineer.Name + " Id: " + RolerInfo.Instance.Engineer.Id + " px: " + RolerInfo.Instance.Engineer.px);
        //}
        //void RemoveRoler(TmRequest mvc)
        //{
        //    TmSoulerItem soulItem = TmTransferTool.GetJsonValue<TmSoulerItem>(mvc, mvc.ElevenCode.ToString());
        //    RolerInfo.Instance.Engineers.Remove(soulItem.Id);
        //    Console.WriteLine(TmTimerTool.GetCurrentTime() + " Name: " + RolerInfo.Instance.Engineer.Name + " Id: " + RolerInfo.Instance.Engineer.Id + " px: " + RolerInfo.Instance.Engineer.px);
        //}
        //void SyncMoveState(TmRequest mvc)
        //{

        //}


    }
}
