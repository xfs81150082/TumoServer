namespace Tumo
{
    public class TmProperty : TmComponent
    {      
        public int Stamina { get; set; } = 0;            //耐力，案例，每升1级加1，影响血量
        public int Brains { get; set; } = 0;             //智力，计价，每升1级加1，影响魔法攻击强度，魔法防御
        public int Power { get; set; } = 0;              //力量，计量，每升1级加1，影响物理攻击强度，物理防御
        public int Agility { get; set; } = 0;            //敏捷，管理，每升1级加1，影响暴击率，命中率，闪避率 
        public int Hp { get; set; } = 0;                 //当前血量
        public int Mp { get; set; } = 0;                 //当前血量
        public int MaxHp { get; set; } = 0;              //HP=10 * 耐力 + 装备 + 法术；暂定10倍；
        public int MaxMp { get; set; } = 0;              //MP=10 * Level;
        public int Bp { get; set; } = 0;                 //Bp与智力成正比；暂定1倍；
        public int Ap { get; set; } = 0;                 //Ap与力量成正比；暂定1倍；
        public double Hr { get; set; } = 0.0f;           //hr命中率与敏捷成正比。
        public double Cr { get; set; } = 0.0f;           //cr暴击率与敏捷成正比。
        public double Sp { get; set; } = 0.0f;           //移动速度,与敏捷成正比。 
        public double StaminaRate { get; set; } = 0.0f;  //耐力，案例，每升1级加1，影响血量
        public double BrainsRate { get; set; } = 0.0f;   //智力，计价，每升1级加1，影响魔法攻击强度，魔法防御
        public double PowerRate { get; set; } = 0.0f;    //力量，计量，每升1级加1，影响物理攻击强度，物理防御
        public double AgilityRate { get; set; } = 0.0f;  //敏捷，管理，每升1级加1，影响暴击率，命中率，闪避率 
        public double HpRate { get; set; } = 0.0f;       //当前血量
        public double MpRate { get; set; } = 0.0f;       //当前血量
        public double MaxHpRate { get; set; } = 0.0f;    //HP=10 * 耐力 + 装备 + 法术；暂定10倍；
        public double MaxMpRate { get; set; } = 0.0f;    //MP=10 * Level;
        public double ApRate { get; set; } = 0.0f;       //Ap与力量成正比；暂定1倍；
        public double BpRate { get; set; } = 0.0f;       //Bp与智力成正比；暂定1倍；
        public double HrRate { get; set; } = 0.0f;       //hr命中率与敏捷成正比。
        public double CrRate { get; set; } = 0.0f;       //cr暴击率与敏捷成正比。
        public double SpRate { get; set; } = 0.0f;       //移动速度
    }
}