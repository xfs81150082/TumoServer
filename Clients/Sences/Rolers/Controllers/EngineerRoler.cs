﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Timers;
using Tumo;
using Tumo.Models;

namespace Clients.Sences.Rolers.Controllers
{
    class EngineerRoler : RolerControllerBase
    {
        public override string Code => TenCode.Engineer.ToString();
        public override void OnTransferParameter(MvcParameter mvc)
        {
            ElevenCode elevenCode = mvc.ElevenCode;
            switch (elevenCode)
            {
                //case (ElevenCode.SpawnRoler):
                //    Console.WriteLine(TmClientHelper.Instance.GetCurrentTime() + " EngineerRoler: " + elevenCode);
                //    SpawnRoler(mvc);
                //    break;
                //case (ElevenCode.RemoveRoler):
                //    Console.WriteLine(TmClientHelper.Instance.GetCurrentTime() + " EngineerRoler: " + elevenCode);
                //    RemoveRoler(mvc);
                //    break;
                //case (ElevenCode.SyncMoveState):
                //    Console.WriteLine(TmClientHelper.Instance.GetCurrentTime() + " EngineerRoler: " + elevenCode);
                //    SyncMoveState(mvc);
                //    break;
                case (ElevenCode.Test):
                    Console.WriteLine(TmClientHelper.Instance.GetCurrentTime() + " EngineerRoler: " + elevenCode);
                    Test(mvc);
                    break;
                default:
                    break;
            }
        }

        private void Test(MvcParameter mvc)
        {
            int count = MvcTool.GetJsonValue<int>(mvc, mvc.ElevenCode.ToString());
            Console.WriteLine(TmClientHelper.Instance.GetCurrentTime() + " count: " + count);
        }

        public EngineerRoler(){   }

        void SpawnRoler(MvcParameter mvc)
        {
            SoulItem soulItem = MvcTool.GetJsonValue<SoulItem>(mvc, mvc.ElevenCode.ToString());
            RolerInfo.Instance.Engineers.Add(soulItem.Id, soulItem);
            Console.WriteLine(TmClientHelper.Instance.GetCurrentTime() + " Name: " + RolerInfo.Instance.Engineer.Name + " Id: " + RolerInfo.Instance.Engineer.Id + " px: " + RolerInfo.Instance.Engineer.px);
        }
        void RemoveRoler(MvcParameter mvc)
        {
            SoulItem soulItem = MvcTool.GetJsonValue<SoulItem>(mvc, mvc.ElevenCode.ToString());
            RolerInfo.Instance.Engineers.Remove(soulItem.Id);
            Console.WriteLine(TmClientHelper.Instance.GetCurrentTime() + " Name: " + RolerInfo.Instance.Engineer.Name + " Id: " + RolerInfo.Instance.Engineer.Id + " px: " + RolerInfo.Instance.Engineer.px);
        }
        void SyncMoveState(MvcParameter mvc)
        {

        }


    }
}
