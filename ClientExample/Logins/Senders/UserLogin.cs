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
        public override void OnTransferParameter(MvcParameter mvc)
        {
            ElevenCode elevenCode = mvc.ElevenCode;
            switch (elevenCode)
            {
                case (ElevenCode.UserLogin):
                    Console.WriteLine(TmClientHelper.Instance.GetCurrentTime() + " UserLoginSender: " + elevenCode);
                    mvc.NineCode = NineCode.Mysqler;
                    TClient.Instance.SendMsg(mvc);
                    break;
                default:
                    break;
            }
        }

    }
}
