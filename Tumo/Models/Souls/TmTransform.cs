using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Tumo.Models
{
    public class TmTransform
    {
        public double px = 0;
        public double py = 0;
        public double pz = 0;
        public double ax = 0;
        public double ay = 0;
        public double az = 0;
        public TmTransform() { }
        public TmTransform(double px,double py,double pz)
        {
            this.px = px;
            this.py = py;
            this.pz = pz;
        }
        public TmTransform(double ay)
        {
            this.ay = ay;
        }
        public TmTransform(SoulItem item)
        {
            this.px = item.px;
            this.py = item.py;
            this.pz = item.pz;
            this.ax = item.ax;
            this.ay = item.ay;
            this.az = item.az;
        }
      

    }
}
