using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tumo;
using Servers.Gates;
using Servers;

namespace Servers.Logins.Handlers
{
    class Userlogin : LoginBase
    {
        public override string Code => TenCode.User.ToString();

        public override void OnTransferParameter(MvcParameter mvc)
        {
            ElevenCode elevenCode = mvc.ElevenCode;
            switch (elevenCode)
            {
                case (ElevenCode.UserLogin):
                    Console.WriteLine(TmTimer.GetCurrentTime() + " EngineerloginHandler: " + elevenCode);
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
