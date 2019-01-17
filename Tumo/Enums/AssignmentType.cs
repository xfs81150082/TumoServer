using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Tumo
{
    [Serializable]
    public enum AssignmentType
    {
        Main,          //主线任务
        Reward,        //赏金任务
        Daily,         //日常任务
    }
    [Serializable]
    public enum AssignmentState
    {
        NoAccept,        //不能领取    /**0 不可接状态*/  
        NoStart,         //没开始      /**1 可接  但还未接的状态*/ 
        Accept,          //接受        /**2 已接  正在进行中*/ 
        Reward,          //奖金        /**4 完成  未领奖*/  
        Complete,        //完成        /**3 完成  结束*/ 
    }


}
