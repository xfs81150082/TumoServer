using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Tumo
{
    [Serializable]
    public enum ReturnCode
    {
        Success,
        Error,
        Fail,
        Exception,
        GetTeam,
        WartingTeam
    }
    [Serializable]
    public enum EightCode
    {
        None,
        Gate,
        Game,
        Chat,
        War,
        Sender,
        Node,
        User,
        Roler,
        Engineer,
        Booker,
        Teacher,
        Login,
        Valuation,
        Case,
        Administration,
        Measurement, 
        
        Test,     
    }
    [Serializable]
    public enum NineCode
    {
        None,
        TmEessionCD,  /// 链接心跳包
        TmLogin,      /// 登录


        Handler,
        Mysqler,
        Sender,
        Controller,
        Node,
        Chat,
        War,
        Game,
        User,
        Login,
        Gate,
        Valuation,
        Case,
        Administration,
        Measurement,
        Test,
    }
    [Serializable]
    public enum TenCode
    {
        None,
        TmUser,       /// 用户注册、登录
        TmEngineer,   /// 角色注册、登录、保存

        HeartBeat,    /// 链接心跳包
        Server,
        Register,
        UserLogin,
        EngineerLogin,
        Battle,
        Task,
        Role,
        Boss,
        User,
        Node,
        Login,
        Gate,
        Game,
        Chat,
        War,
        Valuation,
        Case,
        Administration,
        Measurement,
        Message,
        Text,
        Image,
        Class,
        Sender,
        Peer,
        Timer,
        Camera,
        Engineer,
        Booker,
        Teacher,
        Skill,
        Ability,
        Buff,
        Inborn,
        Effect,
        Audio,
        Inventory,
        Dressed,
        Knapsack,
        Smithy,
        Terrain,
        Map,
        Shop,
        Bar,
        Pivot,
        Npcer,
        Monster,
        Player,
        Team,

        Attack,
        Agent,
        Animator,
        CharacterController,
        Rigidbody,
        MessageShow,

        OnPress,
        Target,
        Talks,
    }
    [Serializable]
    public enum ElevenCode
    {
        None,
        All,
        Single,
        SyncMoveState,
        UpdateRoler,
        SyncSpawn,

        InsertItemdb,
        UpdateItemdb,
        UpdateItemdbName,
        UpdateItemdb2,
        UpdateItemdb3,
        RemoveItemdb,
        GetItemdbs,
        GetItemdb,
        GetItems,
        GetItem,
        Geters,
        Geter,
        Check,
        GetItemsByUser,
        GetItemsByRolerId,
        GetItemById,
        GetItemByNodeId,
        Message,
        Text,
        Image,
        Class,

        Attribute,
        SignIn,
        RemoveHeartBeat,
        SpawnRoler,
        SpawnRolerById,
        SpawnRolerByPeer,
        SpawnNodeRolers,
        SpawnNineNodeRolers,
        SpawnRolers,
        SpawnRolersByPeer,
        UpdateRolersByPeer,
        RemoveRolerById,
        RemoveRoler,
        RemoveNodeRolers,
        RemoveNineNodeRolers,


        Server,
        Register,
        UserLogin,
        EngineerLogin,
        Battle,
        Task,
        Role,
        Roler,
        Boss,
        User,

        HeartBeat,
        Engineer,
        Booker,
        Teacher,
        Skill,
        Ability,
        Buff,
        Inborn,
        Effect,
        Audio,
        Inventory,
        Dressed,
        Knapsack,
        Smithy,
        Terrain,
        Map,
        Shop,
        Pivot,

        GetSoulTransform,
        SetCamera,
        GetFixedBar,
        GetUguiPivot,
        GetBarUguiesGo,
        GetRolerHpMpBar,
        GetItemsUI,
        UpdateHeadUI,
        UpdateTargetUI,
        DeleteBarUI,
        AddIconUI,
        Test,


        Synchronization,
    }
    [Serializable]
    public enum TwelveCode
    {
        None,
        All,
        Single,
        SignIn,
        Remove,
        Spawn,
        Attribute,

        HeartBeat,
        RemoveHeartBeat,
        SpawnRoler,
        SpawnNodeRolers,
        SpawnNineNodeRolers,
        SpawnRolers,
        RemoveRoler,
        RemoveNodeRolers,
        RemoveNineNodeRolers,

        Peer,
        SoulItem,
        SoulItems,
        BookerRoler,
        BookerRolers,
        TeacherRoler,
        TeacherRolers,
        EngineerRoler,
        EngineerRolers,
        NodeItem,

        InsertItemdb,
        UpdateItemdb,
        UpdateItemdbName,
        UpdateItemdb2,
        UpdateItemdb3,
        RemoveItemdb,
        GetItemdbs,
        GetItemdb,
        GetItems,
        GetItem,
        Geters,
        Geter,
        GetItemsByUser,



    }
 

}
