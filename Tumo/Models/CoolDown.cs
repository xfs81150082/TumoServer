using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Tumo
{
    public class CoolDown 
    {
        public int Id { get => id; set => id = value; }
        public double MaxCdTime { get => maxCdTime; set => maxCdTime = value; }
        public int MaxCdCount { get => maxCdCount; set => maxCdCount = value; }

        public CoolDown() { }
        public CoolDown(int id, int maxcdCount)
        {
            this.maxCdCount = maxcdCount;
        }
        public CoolDown(int id, double maxcdTime)
        {
            this.Id = id;
            this.maxCdTime = maxcdTime;
        }
        public CoolDown(int id, double maxcdTime, int maxcdCount)
        {
            this.Id = id;
            this.maxCdTime = maxcdTime;
            this.maxCdCount = maxcdCount;
        }
        public CoolDown(double maxcdTime, int maxcdCount)
        {
            this.maxCdTime = maxcdTime;
            this.maxCdCount = maxcdCount;
        }

        private int id = 1;
        private double maxCdTime = 14;
        private int maxCdCount = 4;
    }
}
