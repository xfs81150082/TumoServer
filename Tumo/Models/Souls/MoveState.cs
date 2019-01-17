using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Tumo.Models
{
    public class MoveState
    {
        public int RoelerId;
        public string CurdateTime;              //当前时间数值
        public double MoveSpeed;                //当前速度
        public TmTransform MyselfTmTransform;   //当前坐标
        public TmTransform TargetTmTransform;   //当前目标坐标
        public MoveState() { }
    }
}
