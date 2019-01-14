using Tumo;
using Tumo.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Timers;
using Servers.Sences.Nodes.Mysqlers;
using Servers;

namespace Servers.Sences.Rolers.Handlers
{
    class NpcerHandler : RolerHandlerBase
    {
        public override string Code => TenCode.Teacher.ToString();

        public override void OnTransferParameter(MvcParameter mvc)
        {
            ElevenCode elevenCode = mvc.ElevenCode;
            switch (elevenCode)
            {
                case (ElevenCode.None):
                    Console.WriteLine(TmTimer.GetCurrentTime() + " TeacherRolerHandler: " + elevenCode);
                    break;
                default:
                    break;
            }
        }

        public override void TmAwake()
        {
        }

        public override void TmUpdate(ElapsedEventArgs time)
        {
        }

      


    }
}
