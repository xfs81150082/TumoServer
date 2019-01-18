using Tumo;
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

        public override void OnTransferParameter(TmRequest mvc)
        {
            ElevenCode elevenCode = mvc.ElevenCode;
            switch (elevenCode)
            {
                case (ElevenCode.GetItems):
                    Console.WriteLine(TmTimerTool.GetCurrentTime() + " TeacherRoler: " + elevenCode);
                    Getitems(mvc);
                    break;
                default:
                    break;
            }
        }

        void Getitems(TmRequest mvc)
        {
            Dictionary<int, TmSoulerItem> bookers = TmTransferTool.GetJsonValue<Dictionary<int, TmSoulerItem>>(mvc, mvc.ElevenCode.ToString());
            RolerInfo.Instance.Bookers = bookers;
            Console.WriteLine(TmTimerTool.GetCurrentTime() + " Bookers:" + RolerInfo.Instance.Bookers.Count);
        }




    }
}
