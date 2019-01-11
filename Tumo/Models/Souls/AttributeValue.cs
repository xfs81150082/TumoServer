using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Tumo.Models
{
    public class AttributeValue
    {
        public int Stamina { get => stamina; set => stamina = value; }
        public int Brains { get => brains; set => brains = value; }
        public int Power { get => power; set => power = value; }
        public int Agility { get => agility; set => agility = value; }
        public int Hp { get => hp; set => hp = value; }
        public int Mp { get => mp; set => mp = value; }
        public int MaxHp { get => maxHp; set => maxHp = value; }
        public int MaxMp { get => maxMp; set => maxMp = value; }
        public int Bp { get => bp; set => bp = value; }
        public int Ap { get => ap; set => ap = value; }
        public double Hr { get => hr; set => hr = value; }
        public double Cr { get => cr; set => cr = value; }
        public double Sp { get => sp; set => sp = value; }
        public double StaminaRate { get => staminaRate; set => staminaRate = value; }
        public double BrainsRate { get => brainsRate; set => brainsRate = value; }
        public double PowerRate { get => powerRate; set => powerRate = value; }
        public double AgilityRate { get => agilityRate; set => agilityRate = value; }
        public double HpRate { get => hpRate; set => hpRate = value; }
        public double MpRate { get => mpRate; set => mpRate = value; }
        public double MaxHpRate { get => maxHpRate; set => maxHpRate = value; }
        public double MaxMpRate { get => maxMpRate; set => maxMpRate = value; }
        public double ApRate { get => apRate; set => apRate = value; }
        public double BpRate { get => bpRate; set => bpRate = value; }
        public double HrRate { get => hrRate; set => hrRate = value; }
        public double CrRate { get => crRate; set => crRate = value; }
        public double SpRate { get => spRate; set => spRate = value; }

        public AttributeValue() { }
        private int stamina = 0;            //耐力，案例，每升1级加1，影响血量
        private int brains = 0;             //智力，计价，每升1级加1，影响魔法攻击强度，魔法防御
        private int power = 0;              //力量，计量，每升1级加1，影响物理攻击强度，物理防御
        private int agility = 0;            //敏捷，管理，每升1级加1，影响暴击率，命中率，闪避率 
        private int hp = 0;                 //当前血量
        private int mp = 0;                 //当前血量
        private int maxHp = 0;              //HP=10 * 耐力 + 装备 + 法术；暂定10倍；
        private int maxMp = 0;              //MP=10 * Level;
        private int bp = 0;                 //Bp与智力成正比；暂定1倍；
        private int ap = 0;                 //Ap与力量成正比；暂定1倍；
        private double hr = 0.0f;           //hr命中率与敏捷成正比。
        private double cr = 0.0f;           //cr暴击率与敏捷成正比。
        private double sp = 0.0f;           //移动速度,与敏捷成正比。 
        private double staminaRate = 0.0f;  //耐力，案例，每升1级加1，影响血量
        private double brainsRate = 0.0f;   //智力，计价，每升1级加1，影响魔法攻击强度，魔法防御
        private double powerRate = 0.0f;    //力量，计量，每升1级加1，影响物理攻击强度，物理防御
        private double agilityRate = 0.0f;  //敏捷，管理，每升1级加1，影响暴击率，命中率，闪避率 
        private double hpRate = 0.0f;       //当前血量
        private double mpRate = 0.0f;       //当前血量
        private double maxHpRate = 0.0f;    //HP=10 * 耐力 + 装备 + 法术；暂定10倍；
        private double maxMpRate = 0.0f;    //MP=10 * Level;
        private double apRate = 0.0f;       //Ap与力量成正比；暂定1倍；
        private double bpRate = 0.0f;       //Bp与智力成正比；暂定1倍；
        private double hrRate = 0.0f;       //hr命中率与敏捷成正比。
        private double crRate = 0.0f;       //cr暴击率与敏捷成正比。
        private double spRate = 0.0f;       //移动速度
    }
}
