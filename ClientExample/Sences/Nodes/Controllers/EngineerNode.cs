using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Timers;
using ClientExample;
using Tumo;
using Tumo.Models;

namespace ClientExample.Sences.Nodes.Controllers
{
    class EngineerNode : NodeCotrollerBase
    {
        public override string Code => TenCode.Engineer.ToString();
        public override void OnTransferParameter(TmParameter mvc)
        {
            ElevenCode elevenCode = mvc.ElevenCode;
            switch (elevenCode)
            {   
                case (ElevenCode.EngineerLogin):
                    Console.WriteLine(TmTimerTool.GetCurrentTime() + " EngineerNode: " + elevenCode);
                    EngineerLogin(mvc);
                    break;
                default:
                    break;
            }
        }

   
        void EngineerLogin(TmParameter mvc)
        {
            TmSoulerItem soulItem = TmTransferTool.GetJsonValue<TmSoulerItem>(mvc, mvc.ElevenCode.ToString());
            NodeInfo.Instance.Engineer = soulItem;
            //Console.WriteLine(TmTimerTool.GetCurrentTime() + " 当前角色Name: " + NodeInfo.Instance.Engineer.Name + " Id: " + NodeInfo.Instance.Engineer.Id + " px: " + NodeInfo.Instance.Engineer.px);
        }



    }
}
