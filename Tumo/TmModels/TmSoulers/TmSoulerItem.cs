using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Tumo
{
    [Serializable]
    public class TmSoulerItem : TmEntity
    {
        public override void TmAwake()
        {
            base.TmAwake();
            AddComponent(new TmName());
            AddComponent(new TmTransform());
            AddComponent(new TmSouler());
            AddComponent(new TmSoulerDB());
            AddComponent(new TmAttribute());
            AddComponent(new TmInventoryAdd());
            AddComponent(new TmBuffAdd());
            AddComponent(new TmSkillAdd());
            AddComponent(new TmChangeType());
        }
        public TmSoulerItem() { }                        ///构造函数 
        public TmSoulerItem(TmSoulerDB itemDB)
        {
            if (GetComponent<TmSoulerDB>() != null)
            {
                TmSoulerDB tem = GetComponent<TmSoulerDB>() as TmSoulerDB;
                tem = itemDB;
            }
        }
        //public void InitAttribute()
        //{
        //    UpdateLevel();
        //    Stamina = (Soul.Stamina + Level);
        //    Brains = (Soul.Brains + Level);
        //    Power = (Soul.Power + Level);
        //    Agility = (Soul.Agility + Level);
        //    MaxHp = (int)Math.Round(Stamina * Soul.StaminaRate);                            //Hp与根骨成正比；暂定10倍；
        //    MaxMp = (int)Math.Round(Level * Soul.StaminaRate);                              //Mp与等级有关；暂定10倍；
        //    Bp = (int)Math.Round(Brains * Soul.BrainsRate);                                 //Bp与智力成正比；暂定1倍；
        //    Ap = (int)Math.Round(Power * Soul.PowerRate);                                   //Ap与力量成正比；暂定1倍；
        //    Hr = Math.Round((Soul.Hr + (Agility * Soul.AgilityRate) / (100 * Level)), 4);   //hr命中率与敏捷成正比。
        //    Cr = Math.Round((Soul.Cr + (Agility * Soul.AgilityRate) / (100 * Level)), 4);   //cr暴击率与敏捷成正比。
        //    Sp = Math.Round((Soul.Sp + (Agility * Soul.AgilityRate) / (100 * Level)), 4);
        //} //更新属性
        //void UpdateLevel()
        //{
        //    if (Level == Soul.LevelUpLimit) return;
        //    int expTem = (int)Math.Round((Level + 1.0) * (Level + 1.0) + 10.0);
        //    if (Exp >= expTem)
        //    {
        //        Exp -= expTem;
        //        Level++;
        //        if (Level >= Soul.LevelUpLimit)
        //        {
        //            Level = Soul.LevelUpLimit;
        //            Exp = 0;
        //        }
        //        this.Hp = this.MaxHp;
        //        this.Mp = this.MaxMp;
        //    }
        //    //1-59级：经验值 = ((8 × 角色等级) + 难度系数(角色等级)) × 基础经验值(角色等级) × 经验系数(角色等级)
        //    //60级：经验值 = 155 + 基础经验值(角色等级) × (1275 - ((69 - 角色等级) × (3 + (69 - 角色等级) × 4)));
        //    //61-69级：经验值 = 155 + 基础经验值(角色等级) × (1344 - ((69 - 角色等级) × (3 + (69 - 角色等级) × 4)));
        //    //基础经验值(角色等级) = 45 + (5 × 角色等级) (适用于艾泽拉斯的怪物) 基础经验值(角色等级) = 235 + (5 × 角色等级) (适用于外域的怪物) 基础经验值(角色等级) = 626 + (5 × 角色等级) (适用于诺森德的怪物);
        //    //难度系数(角色等级) = 0 (角色等级 <= 28) 难度系数(角色等级) = 1 (角色等级 = 29) 难度系数(角色等级) = 3 (角色等级 = 30) 难度系数(角色等级) = 6 (角色等级 = 31) 难度系数(角色等级) = 5 × (角色等级 - 30) (角色等级 >= 32, <= 59);
        //    //经验系数(角色等级) = 1(角色等级 <= 10) 经验系数(角色等级) = (1 - (角色等级 - 10) / 100)(角色等级 >= 11, <= 27) 经验系数(角色等级) = 0.82(角色等级 >= 28, <= 59);
        //} //等级更新        

    }
}
