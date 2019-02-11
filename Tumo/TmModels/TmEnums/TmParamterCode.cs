using System;
namespace Tumo
{
    [Serializable]
    public enum TenCode
    {
        None,
        All,
        EessionCD,  /// 链接心跳包
        User,
        Engineer,
        Booker,
        Teacher,
        StatusSync,
        Skill,
        Ability,
        Buff,
        Inborn,
        Inventory,
        Dressed,
        Knapsack,
        Smithy,
        Task,
        War,
        Sence,
        Ugui,

        End,
    }
    [Serializable]
    public enum ElevenCode
    {
        None,
        All,
        Register,            /// 注册
        Get,                 /// 得到
        Login,               /// 登录
        UserLogin,           /// 登录
        EngineerLogin,       /// 登录
        GetRolers,           ///得到小怪或NPC
        GetRoler,            ///生产一只小怪或NPC
        Souler,
        Roler,
        Die,
        StatusSync,
        Engineer,
        Booker,
        Teacher,
        GetSkills,           ///得到小怪或NPC
        GetSkill,            ///生产一只小怪或NPC
        GetInventorys,
        GetInventory,
        Inventory,
        Dressed,
        Smithy,
        Knapscak,
        Save,                /// 保存
        Add,                 /// 添加
        UserRemove,          /// 删除
        RolerRemove,         /// 删除
        Update,              /// 更新
        Bar,
        Chat,
        Teerain,
        Map,
        HeadPortrait,
        TargetPortrait,
        MySelf,
        Target,
        Message,
        Hudtext,
        Hp,
        Mp,
        Bp,
        Ap,
        MaxHp,
        MaxMp,
        Button,
        System,


        End,
    }
    [Serializable]
    public enum KeyCode
    {
        None,
        One,
        Two,

        All,     
        End,
    }
}