﻿using Tumo;
using Tumo.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Timers;

namespace ClientExample.Sences.Rolers.Controllers
{
    class TeacherRoler : RolerControllerBase
    {
        public override string Code => TenCode.Teacher.ToString();

        public override void OnTransferParameter(MvcParameter mvc)
        {
            ElevenCode elevenCode = mvc.ElevenCode;
            switch (elevenCode)
            {
                case (ElevenCode.GetItems):
                    Console.WriteLine(TmTimer.GetCurrentTime() + " TeacherRoler: " + elevenCode);
                    Getitems(mvc);
                    break;
                default:
                    break;
            }
        }

        void Getitems(MvcParameter mvc)
        {
            Dictionary<int, SoulItem> bookers = MvcTool.GetJsonValue<Dictionary<int, SoulItem>>(mvc, mvc.ElevenCode.ToString());
            RolerInfo.Instance.Bookers = bookers;
            Console.WriteLine(TmTimer.GetCurrentTime() + " Bookers:" + RolerInfo.Instance.Bookers.Count);
        }




    }
}