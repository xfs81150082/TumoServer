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
        public void Add(TmProperty pro)
        {
            this.Stamina += pro.Stamina;           //耐力，案例，每升1级加1，影响血量
            this.Brains += pro.Brains;             //智力，计价，每升1级加1，影响魔法攻击强度，魔法防御
            this.Power += pro.Power;               //力量，计量，每升1级加1，影响物理攻击强度，物理防御
            this.Agility += pro.Agility;           //敏捷，管理，每升1级加1，影响暴击率，命中率，闪避率 
            //this.Hp += pro.Hp;                     //当前血量
            //this.Mp += pro.Mp;                     //当前血量
            //this.MaxHp += pro.MaxHp;            //HP=10 * 耐力 + 装备 + 法术；暂定10倍；
            //this.MaxMp += pro.MaxMp;            //MP=10 * Level;
            //this.Bp += pro.Bp;                    //Bp与智力成正比；暂定1倍；
            //this.Ap += pro.Ap;                    //Ap与力量成正比；暂定1倍；
            //this.Hr += pro.Hr;                    //hr命中率与敏捷成正比。
            //this.Cr += pro.Cr;                    //cr暴击率与敏捷成正比。
            //this.Sp += pro.Sp;                    //移动速度,与敏捷成正比。 
            //this.StaminaRate += pro.StaminaRate;  //耐力，案例，每升1级加1，影响血量
            //this.BrainsRate += pro.BrainsRate;     //智力，计价，每升1级加1，影响魔法攻击强度，魔法防御
            //this.PowerRate += pro.PowerRate;      //力量，计量，每升1级加1，影响物理攻击强度，物理防御
            //this.AgilityRate += pro.AgilityRate;  //敏捷，管理，每升1级加1，影响暴击率，命中率，闪避率 
            //this.HpRate += pro.HpRate;            //当前血量
            //this.MpRate += pro.MpRate;            //当前血量
            this.MaxHpRate += pro.MaxHpRate;      //HP=10 * 耐力 + 装备 + 法术；暂定10倍；
            //this.MaxMpRate += pro.MaxMpRate;      //MP=100;
            this.ApRate += pro.ApRate;            //Ap与力量成正比；暂定1倍；
            this.BpRate += pro.BpRate;            //Bp与智力成正比；暂定1倍；
            this.HrRate += pro.HrRate;            //hr命中率与敏捷成正比。
            this.CrRate += pro.CrRate;            //cr暴击率与敏捷成正比。
            this.SpRate += pro.SpRate;            //移动速度
        }
        public void Zero()
        {
            this.Stamina = 0;            //耐力，案例，每升1级加1，影响血量
            this.Brains = 0;             //智力，计价，每升1级加1，影响魔法攻击强度，魔法防御
            this.Power = 0;              //力量，计量，每升1级加1，影响物理攻击强度，物理防御
            this.Agility = 0;            //敏捷，管理，每升1级加1，影响暴击率，命中率，闪避率 
            //this.Hp = 0;                 //当前血量
            //this.Mp = 0;                 //当前血量
            //this.MaxHp = 0;              //HP=10 * 耐力 + 装备 + 法术；暂定10倍；
            //this.MaxMp = 0;              //MP=10 * Level;
            //this.Bp = 0;                 //Bp与智力成正比；暂定1倍；
            //this.Ap = 0;                 //Ap与力量成正比；暂定1倍；
            //this.Hr = 0.0f;           //hr命中率与敏捷成正比。
            //this.Cr = 0.0f;           //cr暴击率与敏捷成正比。
            //this.Sp = 0.0f;           //移动速度,与敏捷成正比。 
            //this.StaminaRate = 0.0f;  //耐力，案例，每升1级加1，影响血量
            //this.BrainsRate = 0.0f;   //智力，计价，每升1级加1，影响魔法攻击强度，魔法防御
            //this.PowerRate = 0.0f;    //力量，计量，每升1级加1，影响物理攻击强度，物理防御
            //this.AgilityRate = 0.0f;  //敏捷，管理，每升1级加1，影响暴击率，命中率，闪避率 
            //this.HpRate = 0.0f;       //当前血量
            //this.MpRate = 0.0f;       //当前血量
            this.MaxHpRate = 0.0f;    //HP=10 * 耐力 + 装备 + 法术；暂定10倍；
            //this.MaxMpRate = 0.0f;    //MP=10 * Level;
            this.ApRate = 0.0f;       //Ap与力量成正比；暂定1倍；
            this.BpRate = 0.0f;       //Bp与智力成正比；暂定1倍；
            this.HrRate = 0.0f;       //hr命中率与敏捷成正比。
            this.CrRate = 0.0f;       //cr暴击率与敏捷成正比。
            this.SpRate = 0.0f;       //移动速度
        }
        public void Init()
        {
            this.StaminaRate = 10.0;
            this.BrainsRate = 1.0;
            this.PowerRate = 1.0;
            this.AgilityRate = 1.0;
            this.MaxHp = (int)(this.Stamina * this.StaminaRate * (1 + this.HpRate));       //HP=10 * 耐力 + 装备 + 法术；暂定10倍；
            this.MaxMp = 100;
            this.Bp = (int)(this.Brains * this.BrainsRate * (1 + this.BpRate));            //Bp与智力成正比；暂定1倍；
            this.Ap = (int)(this.Power * this.PowerRate * (1 + this.ApRate));              //Ap与力量成正比；暂定1倍；
            this.Hr = this.HrRate + 0.8;                                                   //+ (int)(this.Agility * this.AgilityRate / (this.Agility * this.AgilityRate + 100));           //hr命中率与敏捷成正比。
            this.Cr = this.CrRate + (int)(this.Agility * this.AgilityRate / (this.Agility * this.AgilityRate + 100));           //cr暴击率与敏捷成正比。
            this.Sp = this.SpRate + 1.0;                                                   //移动速度,与敏捷成正比。 
        }
    }
}