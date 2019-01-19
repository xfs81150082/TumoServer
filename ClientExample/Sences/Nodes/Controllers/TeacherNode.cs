using Tumo;
using Tumo.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Timers;

namespace ClientExample.Sences.Nodes.Controllers
{
    class TeacherNode : NodeCotrollerBase
    {
        public override string Code => TenCode.Teacher.ToString();

        public override void OnTransferParameter(TmParameter mvc)
        {
            ElevenCode elevenCode = mvc.ElevenCode;
            switch (elevenCode)
            {
                case (ElevenCode.GetItems):
                    Console.WriteLine(TmTimerTool.CurrentTime() + " TeacherNode: " + elevenCode);
                    GetItems(mvc);
                    break;
                case (ElevenCode.None):
                    break;
                default:
                    break;
            }
        }
        
        public TeacherNode() {     }

        private void GetItems(TmParameter mvc)
        {
            Dictionary<int, TmSoulerItem> teachers = TmTransferTool.GetJsonValue<Dictionary<int, TmSoulerItem>>(mvc, mvc.ElevenCode.ToString());
            NodeInfo.Instance.Teachers = teachers;
            Console.WriteLine(TmTimerTool.CurrentTime() + " NodeInfo.Instance.Teachers is count: " + NodeInfo.Instance.Teachers.Count);
        }


    }
}
