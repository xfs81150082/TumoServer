using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Tumo.Models
{
    [Serializable]
    public class Skill : Attribute
    {
        public SkillType SkillType { get => skillType; set => skillType = value; }
        public int ColdTime { get => coldTime; set => coldTime = value; }
        public double DamageDis { get => damageDis; set => damageDis = value; }
        public bool Start { get => start; set => start = value; }
        public double Duration { get => duration; set => duration = value; }

        public Skill() { }
        private SkillType skillType = SkillType.Basic;
        private double damageDis = 10.0f;
        private int coldTime = 4;                              //冷却时间
        private bool start = false;
        private double duration = 120;
    }
}
