using System;
using System.Collections.Generic;
using UnityEngine;

namespace Tumo
{
    public class TmTransform : TmComponent
    {
        public int senceId { get; set; }
        public string map { get; set; }
        public int rolerId { get; set; }
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
        public TmTransform(double px, double py, double pz, double ay)
        {
            this.px = px;
            this.py = py;
            this.pz = pz;
            this.ay = ay;
        }
        public TmTransform(TmSoulerItem souler)
        {
            if (souler.GetComponent<TmTransform>() != null)
            {
                TmTransform trans = souler.GetComponent<TmTransform>();
                this.px = trans.px;
                this.py = trans.py;
                this.pz = trans.pz;
                this.ax = trans.ax;
                this.ay = trans.ay;
                this.az = trans.az;                
            }
            else
            {
                Console.WriteLine(TmTimerTool.CurrentTime() + " " + souler.GetType().Name + " 无TmTransform组件。");
            }
        }
    }
}
