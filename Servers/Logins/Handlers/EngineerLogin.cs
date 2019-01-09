using Tumo;
using Tumo.Models;
using Servers.Gates;
using Servers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Servers.Logins.Handlers
{
    class EngineerLogin : HandlerBase
    {
        public override string Code => TenCode.Engineer.ToString();

        public override void OnTransferParameter(MvcParameter mvc)
        {
            ElevenCode elevenCode = mvc.ElevenCode;
            switch (elevenCode)
            {
                case (ElevenCode.EngineerLogin):
                    Console.WriteLine(TimerTool.GetCurrentTime() + " EngineerloginHandler: " + elevenCode);
                    mvc.NineCode = NineCode.Sender;
                    TumoLogin.Instance.OnTransferParameter(mvc);
                    break;
                case (ElevenCode.None):
                    break;
                default:
                    break;
            }
        }


    }
}
