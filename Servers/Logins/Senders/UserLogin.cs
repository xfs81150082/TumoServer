using Tumo;
using Tumo.Models;
using Servers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Servers.Logins.Senders
{
    class UserLogin : LoginSenderBase
    {
        public override string Code => TenCode.User.ToString();
        public override void OnTransferParameter(MvcParameter mvc)
        {
            ElevenCode elevenCode = mvc.ElevenCode;
            switch (elevenCode)
            {
                case (ElevenCode.GetItems):
                    Console.WriteLine(TimerTool.GetCurrentTime() +" UserLoginSender: " + elevenCode);
                    mvc.NineCode = NineCode.Controller;
                    TmAsyncTcpServer.Instance.SendMvc(mvc);
                    break;
                case (ElevenCode.None):
                    break;
                default:
                    break;
            }
        }

    }
}
