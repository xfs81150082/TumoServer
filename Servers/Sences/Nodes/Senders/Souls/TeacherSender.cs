using Tumo;
using Tumo.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Servers;

namespace Servers.Sences.Nodes.Senders.Souls
{
    class TeacherSender : NodeSenderBase
    {
        public override string Code => TenCode.Teacher.ToString();

        public override void OnTransferParameter(MvcParameter mvc)
        {
            ElevenCode elevenCode = mvc.ElevenCode;
            switch (elevenCode)
            {
                case (ElevenCode.GetItems):
                    Console.WriteLine(TmTimerTool.GetCurrentTime() + " TeacherSender: " + elevenCode);
                    mvc.NineCode = NineCode.Controller;
                    //TPeer peer1 = TmServerHelper.Instance.GetTcpPeer(mvc.Endpoint);
                    //peer1.SendMsg(mvc);
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
