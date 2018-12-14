using Tumo;
using Tumo.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Clients.Games.Controllers
{
    class TeacherGame : GameControllerBase
    {
        public override string Code => ElevenCode.Teacher.ToString();

        public override void OnTransferParameter(MvcParameter mvc)
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

        void SpawnRolers(MvcParameter mvc)
        {
            Dictionary<int, SoulItem> items = MvcTool.GetJsonValue<Dictionary<int, SoulItem>>(mvc, "SoulItems");
            Console.WriteLine("TeacherController-SpawnItems: " + items.Count);
        }

        void SpawnRoler(MvcParameter mvc)
        {
            SoulItem item = MvcTool.GetJsonValue<SoulItem>(mvc, "SoulItem");
            Console.WriteLine("TeacherController-SpawnRoler: " + item.Name + item.Id);

        }
        void RemoveRoler(MvcParameter mvc)
        {
            SoulItem item = MvcTool.GetJsonValue<SoulItem>(mvc, "SoulItem");
            Console.WriteLine("TeacherController-RemoveRoler: " + item.Name + item.Id);

        }




    }
}
