using System;
using System.Collections.Generic;
namespace Tumo
{
    [Serializable]
    public class TmStatus : TmComponent
    {
        public int RoelerId;
        public string CurdateTime;              //当前时间数值
        public string Animator;                 //动画状态
        public double MoveSpeed;                //当前速度
        public TmTransform MyselfTmTransform;   //当前坐标
        public TmTransform TargetTmTransform;   //当前目标坐标或朝向
        public TmStatus() { }
    }
}
