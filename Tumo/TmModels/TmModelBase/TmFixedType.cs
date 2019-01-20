using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Tumo
{
    public class TmFixedType : TmComponent
    {
        public RoleType RoleType { get; set; } = RoleType.CostEngineer;     //种族和职业：造价师、监理师、建造师
        public EquipType EquipType { get; set; } = EquipType.Weapon;         //装备类型（帽子，衣，鞋子，武器，项链。。。等）  套装技能
        public InfoType InfoType { get; set; } = InfoType.Bp;               //作用类型，表示作用在那个属性之上
        public Quality Quality { get; set; } = Quality.Green;               //品质等级（白绿蓝紫橙）//怪的级别：普通-白、精英-蓝、首领-橙
        public double DamageDis { get; set; } = 10.0f;
        public double MaxDuration { get; set; } = 120;                       //持续时间
        public int ColdTime { get; set; } = 4;                              //冷却时间
        public bool Start { get; set; } = false;
        public bool End { get; set; } = false;
    }
}
