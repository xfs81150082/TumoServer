using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Timers;
using Tumo;
using Servers;
using Timer = System.Timers.Timer;


namespace Servers.Logins.Senders
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
                    Console.WriteLine(TmTimer.GetCurrentTime() + " EngineerLoginSender: " + elevenCode);
                    LoginGetItems(mvc);
                    break;
                case (ElevenCode.None):
                    break;
                default:
                    break;
            }
        }
        
        void LoginGetItems(MvcParameter mvc)   
        {
            MvcParameter mvc2 = MvcTool.ToJsonParameter(EightCode.Node, NineCode.Handler, TenCode.Engineer, ElevenCode.EngineerLogin);
            mvc2.EcsId = mvc.EcsId;
            mvc2.RolerId = mvc.RolerId;
            TumoGate.Instance.OnTransferParameter(mvc2);

            //MvcParameter mvc3 = MvcTool.ToJsonParameter(EightCode.Roler, NineCode.Handler, TenCode.Booker, ElevenCode.GetItems);
            //mvc3.Endpoint = mvc.Endpoint;
            //mvc3.RolerId = mvc.RolerId;
            //TumoGate.Instance.OnTransferParameter(mvc3);

            //MvcParameter mvc4 = MvcTool.ToJsonParameter(EightCode.Roler, NineCode.Handler, TenCode.Teacher, ElevenCode.GetItems);
            //mvc4.Endpoint = mvc.Endpoint;
            //mvc4.RolerId = mvc.RolerId;
            //TumoGate.Instance.OnTransferParameter(mvc4);
        }
        
    }
}
