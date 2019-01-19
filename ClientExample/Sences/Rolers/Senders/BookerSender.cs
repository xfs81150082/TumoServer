using Tumo;
using Tumo.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;

namespace ClientExample.Sences.Rolers.Senders
{
    class BookerSender : RolerSenderBase
    {
        public override string Code => TenCode.Booker.ToString();
        public override void OnTransferParameter(TmParameter mvc)
        {
            ElevenCode elevenCode = mvc.ElevenCode;
            switch (elevenCode)
            {
                case (ElevenCode.Synchronization):
                
                    break;
                case (ElevenCode.SpawnRoler):
                  
                
                    break;
                case (ElevenCode.RemoveRoler):
                 
                    break;
                default:
                    break;
            }
        }

        void SynchronizationMoveState(TmParameter mvc)
        {
            //Monster monster = MvcTool.GetJsonValue<Monster>(mvc, mvc.ElevenCode.ToString());
            //List<Player> players = RolerInfo.Instance.GetPlayersByIdxzs(monster.NineNodeIdxzs);
            //MvcParameter mvc2 = MvcTool.ToJsonParameter<MoveState>();
            //foreach(var tem in players)
            //{
            //    tem.Peer.SendMsg(mvc);
            //}
        }




    }
}
