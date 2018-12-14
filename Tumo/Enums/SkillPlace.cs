using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Tumo
{
    [Serializable]
    public enum SkillPlace
    {
        Basic,   //无快捷按键位置
        One,     //快捷按键位置
        Two,     //快捷按键位置
        Three,   //快捷按键位置      
        Sky,     //空位置
        Icon,    //图标位置
    }
    [Serializable]
    public enum SkillType
    {
        Basic,
        Skill,
    }
    [Serializable]
    public enum EffectType
    {
        BloodSplat, //掉血
        Crowstorm,  //龙卷风
        DevilHand,  //鬼手
        DustStorm,  //尘暴
        FirePhoenix,//火凤凰
        HolyFire,   //圣火
        IceStrike,  //冰击
        Weapon,     //武器电芒

    }


}
