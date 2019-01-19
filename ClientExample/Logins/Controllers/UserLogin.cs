using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Tumo;
using Tumo.Models;
using ClientExample;

namespace ClientExample.Logins.Controllers
{
    class UserLogin : LoginControllerBase
    {
        public override string Code => TenCode.User.ToString();

        public override void OnTransferParameter(TmParameter mvc)
        {
            ElevenCode elevenCode = mvc.ElevenCode;
            switch (elevenCode)
            {
                case (ElevenCode.GetItemsByUser):
                    TumoConnect.Instance.OnTransferParameter(mvc);
                    break;
                case (ElevenCode.SpawnRolers):
                    List<TmSoulerItem> SoulItems2 = TmTransferTool.GetJsonValue<List<TmSoulerItem>>(mvc, mvc.ElevenCode.ToString());
                    for (int i = 0; i < SoulItems2.Count; i++)
                    {
                        //Console.WriteLine("SoulItems2: " + SoulItems2.Count + " Id:" + SoulItems2[i].Id + " Name:" + SoulItems2[i].Name);
                        //TmLog.WriteLine("SoulItems: " + SoulItems2.Count + " Id:" + SoulItems2[i].Id + " Name:" + SoulItems2[i].Name);
                    }

                    RolerLoginTest(SoulItems2[0]);
                    
                    break;
                default:
                    break;
            }
        }

        void RolerLoginTest(TmSoulerItem soulItem)
        {
            //TmRequest mvc = TmTransferTool.ToParameter(EightCode.Login, NineCode.Sender, TenCode.Engineer, ElevenCode.EngineerLogin);
            //mvc.RolerId = soulItem.Id.ToString();
            //TumoConnect.Instance.OnTransferParameter(mvc);
            //Console.WriteLine(TmTimerTool.GetCurrentTime() + " Test1-UserLogin: " + mvc.RolerId);
        }

    }
}
