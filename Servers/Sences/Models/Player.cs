using Tumo;
using Tumo.Models;
using Servers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Timers;

namespace Servers.Sences.Models
{
    [Serializable]
    public class Player : Roler
    {
        public SpawnCDitem SpawnCDitem;
        public Player()
        {

        }

        public Player(SoulItem item)
        {
            this.SoulItem = item;
            this.TmTransform = new TmTransform(item);
            //this.RolerMove.SpawnTransform = new TmTransform(item);
            //this.RolerMove.TargetTransform = new TmTransform(item);
        }

        public override void TmUpdate()
        {

        }


    }
}
