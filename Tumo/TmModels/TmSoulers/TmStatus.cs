using System;
using System.Collections;
using System.Collections.Generic;
namespace Tumo
{
    [Serializable]
    public class TmStatus
    {
        public int KeyId;
        public int State;
        public string CurdateTime;
        public double MoveSpeed;
        public TmTransform MyselfTmTransform;
        public TmTransform TargetTmTransform;
    }
}