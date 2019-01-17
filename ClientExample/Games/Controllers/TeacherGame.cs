using Tumo;
using Tumo.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ClientExample.Games.Controllers
{
    class TeacherGame : GameControllerBase
    {
        public override string Code => ElevenCode.Teacher.ToString();

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

        public TeacherGame()
        {

        }

        void SpawnRolers(TmRequest mvc)
        {
            Dictionary<int, SoulItem> items = TmTransferTool.GetJsonValue<Dictionary<int, SoulItem>>(mvc, "SoulItems");
            Console.WriteLine("TeacherController-SpawnItems: " + items.Count);
        }

        void SpawnRoler(TmRequest mvc)
        {
            SoulItem item = TmTransferTool.GetJsonValue<SoulItem>(mvc, "SoulItem");
            Console.WriteLine("TeacherController-SpawnRoler: " + item.Name + item.Id);

        }
        void RemoveRoler(TmRequest mvc)
        {
            SoulItem item = TmTransferTool.GetJsonValue<SoulItem>(mvc, "SoulItem");
            Console.WriteLine("TeacherController-RemoveRoler: " + item.Name + item.Id);

        }




    }
}
