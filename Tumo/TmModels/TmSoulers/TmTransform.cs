using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Tumo
{
    public class TmTransform : TmComponent
    {
        public double senceId { get; set; } = 0;
        public double px { get; set; } = 0;
        public double py { get; set; } = 0;
        public double pz { get; set; } = 0;
        public double ax { get; set; } = 0;
        public double ay { get; set; } = 0;
        public double az { get; set; } = 0;
        public TmTransform() { }
        public TmTransform(double px, double py, double pz)
        {
            this.px = px;
            this.py = py;
            this.pz = pz;
        }
        public TmTransform(double ay)
        {
            this.ay = ay;
        }
        public TmTransform(TmSoulerItem souler)
        {
            if (souler.GetComponent<TmTransfer>() != null)
            {
                TmTransform item = souler.GetComponent<TmTransfer>() as TmTransform;
                this.px = item.px;
                this.py = item.py;
                this.pz = item.pz;
                this.ax = item.ax;
                this.ay = item.ay;
                this.az = item.az;
            }
            else
            {
                Console.WriteLine(TmTimerTool.CurrentTime() + " " + souler.GetType().Name + " 无TmTransform组件。");
            }
        }
    }
}
