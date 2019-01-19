using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tumo;

namespace Servers.Logins.Components
{
    public class TmUser : TmComponent
    {
        public override void OnTransferParameter(TmParameter mvc)
        {
            ElevenCode elevenCode = mvc.ElevenCode;
            switch (elevenCode)
            {
                case (ElevenCode.UserLogin):
                    Console.WriteLine(TmTimerTool.CurrentTime() + " TmUser: " + elevenCode);
                    mvc.NineCode = NineCode.Mysqler;
                    TumoLogin.Instance.OnTransferParameter(mvc);
                    break;
                case (ElevenCode.SpawnRolers):

                    break;
                default:
                    break;
            }
        }




    }
}
