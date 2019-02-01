﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

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
        Inventory,
        Dressed,
        Knapsack,
        Smithy,
        Skill,
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
        Save,                /// 保存
        Add,                 /// 添加
        UserRemove,          /// 删除
        RolerRemove,         /// 删除
        Update,              /// 更新
        Die,
        StatusSync,
        Engineer,
        Booker,
        Teacher,
        Bar,
        Chat,
        Inventory,
        Dressed,
        Smithy,
        Knapscak,
        Teerain,
        Map,
        Souler,
        Roler,

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
