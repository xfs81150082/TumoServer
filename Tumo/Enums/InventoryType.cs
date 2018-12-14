using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Tumo
{
    [Serializable]
    public enum InventoryType
    {
        Equip,
        Drug,
        Box,
        Stamina,
        Brains,
        Power,
        Agility,
        Hp,
        Mp,
        MaxHp,
        MaxMp,
        Bp,
        Ap,
        Sp,
        Hr,
        Cr,

    }
    [Serializable]
    public enum EquipQuality
    {
        White,          //白字装备-低端-商人卖
        Green,          //绿字装备-普通-小怪掉
        Blue,           //蓝字装备-中端-精英怪掉
        Violet,         //紫字装备-高端-Boss怪掉
        Orange,         //橙字装备-稀少-特殊任务掉
    }
    [Serializable]
    public enum EquipType
    {
        Weapon,                //武器1
        Helm,                  //头盔2
        Necklace,              //项链3  
        Cloth,                 //衣服4
        Bracelet,              //手镯5
        Shoes,                 //鞋子6
        Ring,                  //戒指7
        Wing,                  //翅膀8
        Break,
        Water,
        Box
    }
    [Serializable]
    public enum InfoType
    {
        Name,
        HeadPortrait,
        Exp,
        Level,
        Diamond,
        Coin,
        Stamina,
        Brains,
        Power,
        Agility,
        Hp,
        Mp,
        MaxHp,
        MaxMp,
        Bp,
        Ap,
        Sp,
        Hr,
        Cr,
        Hp2,
        Mp2,
        Ap2,
        Sp2,
        Equip,
        Drug,
        Box,
        Skill,
        All,
    }
    [Serializable]
    public enum Place
    {
        Dressed,        //穿在角色身上的装备
        Knapsack,       //角色背包物品
        Smithy,         //商人背包物品
        Terrain,        //地面掉落的物品   
    }
    [Serializable]
    public enum Profession
    {
        Stamina,
        Brains,
        Power,
        Agility,
    }
 

}
