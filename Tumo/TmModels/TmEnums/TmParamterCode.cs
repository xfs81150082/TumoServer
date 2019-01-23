using System;
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
        TmEessionCD,  /// 链接心跳包
        TmUserHandler,
        TmEngineerHandler,
        TmUserController,
        TmEngineerController,
        TmBooker,
        TmTeacher,
        TmInventory,
        TmSkill,
        TmTask,
        TmWar,
        TmSence,

        End,



    }
    [Serializable]
    public enum ElevenCode
    {
        None,
        All,
        Register,    /// 注册
        Get,         /// 得到
        Login,       /// 登录
        Save,        /// 保存
        Remove,      /// 删除
        Update,      /// 更新

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
