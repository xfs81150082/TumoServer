using Tumo.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Timers;

namespace Servers.Sences.Models
{
    [Serializable]
    public class Npcer : Roler
    {
        public Npcer()
        {

        }
        public Npcer(SoulItem item)
        {
            this.SoulItem = item;
            this.TmTransform = new TmTransform(item);
            //this.RolerMove.SpawnTransform = new TmTransform(item);
            //this.RolerMove.TargetTransform = new TmTransform(item);
        }


        public override void TmAwake()
        {

        }

        public override void TmUpdate(ElapsedEventArgs time)
        {

        }
    }
}
