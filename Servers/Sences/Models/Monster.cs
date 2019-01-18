using Tumo;
using Tumo.Models;
using Servers;
using Servers.Sences.Rolers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Timers;

namespace Servers.Sences.Models
{
    [Serializable]
    public class Monster : TmRoler
    {
        public override void TmAwake()
        {

        }
        public Monster()  {  }
        public Monster(TmSoulerItem item)
        {
            this.SoulItem = item;
            this.TmTransform = new TmTransform();
            //this.RolerMove.SpawnTransform = new TmTransform(item);
            //this.RolerMove.TargetTransform = new TmTransform(item);
        }


        //public override void TmUpdate()
        //{
        //    SyncSpawn();
        //}

        //void SyncSpawn()
        //{
        //    TmRequest mvc = TmTransferTool.ToParameter<Roler>(EightCode.Roler, NineCode.Handler, TenCode.Booker, ElevenCode.SyncSpawn, ElevenCode.SyncSpawn.ToString(), this);
        //    TumoRoler.Instance.OnTransferParameter(mvc);
        //    Console.WriteLine(TmTimerTool.GetCurrentTime() + " Monster is SyncSpawn, Id:" + this.SoulItem.Id + " px:" + this.TmTransform.px);
        //}

     
    }
}
