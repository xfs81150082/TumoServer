using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Tumo;
using Clients;

namespace Clients.Logins.Senders
{
    class EngineerLogin : LoginSenderBase
    {
        public override string Code => TenCode.Engineer.ToString();

        public override void OnTransferParameter(MvcParameter mvc)
        {
            ElevenCode elevenCode = mvc.ElevenCode;
            switch (elevenCode)
            {
                case (ElevenCode.EngineerLogin):
                    Console.WriteLine(TmClientHelper.Instance.GetCurrentTime() + " EngineerLoginSender: " + elevenCode);
                    mvc.NineCode = NineCode.Handler;
                    TClient.Instance.SendMsg(mvc);
                    break;
                case (ElevenCode.None):
                    break;
                default:
                    break;
            }
        }
    }
}
