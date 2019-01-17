using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Tumo;
using ClientExample;

namespace ClientExample.Logins.Senders
{
    class EngineerLogin : LoginSenderBase
    {
        public override string Code => TenCode.Engineer.ToString();

        public override void OnTransferParameter(TmRequest mvc)
        {
            ElevenCode elevenCode = mvc.ElevenCode;
            switch (elevenCode)
            {
                case (ElevenCode.EngineerLogin):
                    Console.WriteLine(TmTimerTool.GetCurrentTime() + " EngineerLoginSender: " + elevenCode);
                    mvc.NineCode = NineCode.Handler;
                    TmAsyncTcpClient.Instance.SendMvc(mvc);
                    //TClient.Instance.SendMsg(mvc);
                    break;
                case (ElevenCode.None):
                    break;
                default:
                    break;
            }
        }
    }
}
