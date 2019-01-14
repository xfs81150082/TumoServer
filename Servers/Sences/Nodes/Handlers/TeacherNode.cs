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

namespace Servers.Sences.Nodes.Handlers
{
    class TeacherNode : NodeHandlerBase
    {
        public override string Code => TenCode.Teacher.ToString();

        public override void OnTransferParameter(MvcParameter mvc)
        {
            ElevenCode elevenCode = mvc.ElevenCode;
            switch (elevenCode)
            {
                case (ElevenCode.GetItems):
                    Console.WriteLine(TmTimer.GetCurrentTime() + " TeacherNode: " + elevenCode);
                    mvc.NineCode = NineCode.Mysqler;
                    TumoNode.Instance.OnTransferParameter(mvc);
                    break;
                case (ElevenCode.None):
                    Console.WriteLine(TmTimer.GetCurrentTime() + " TeacherNode: " + elevenCode);
                    break;
                default:
                    break;
            }
        }
        
 

    }
}
