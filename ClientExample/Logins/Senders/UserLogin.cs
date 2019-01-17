using ClientExample;
using Tumo;
using Tumo.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ClientExample.Logins.Senders
{
    class UserLogin : LoginSenderBase
    {
        public override string Code => TenCode.User.ToString();
        public override void OnTransferParameter(TmRequest mvc)
        {
            ElevenCode elevenCode = mvc.ElevenCode;
            switch (elevenCode)
            {
                case (ElevenCode.UserLogin):
                    Console.WriteLine(TmTimerTool.GetCurrentTime() + " UserLoginSender: " + elevenCode);
                    mvc.NineCode = NineCode.Mysqler;
                    TmAsyncTcpClient.Instance.SendMvc(mvc);
                    //TClient.Instance.SendMsg(mvc);
                    break;
                default:
                    break;
            }
        }

    }
}
