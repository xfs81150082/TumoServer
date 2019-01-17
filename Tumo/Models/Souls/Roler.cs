using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Timers;

namespace Tumo.Models
{
    public abstract class Roler : TmSystem
    {
        public TmTransform TmTransform { get; set; }
        public SoulItem SoulItem { get; set; }
        public MoveState MoveState { get; set; }
        public RolerMove RolerMove { get; set; }
        public RolerAttack RolerAttack { get; set; }
        public List<Roler> TargetRolers { get; set; }
        public bool IsOut { get; set; } = true;
        
        public Roler() {   }
        public void SetMoveState(MoveState moveState)
        {
            this.MoveState = moveState;
            this.TmTransform = moveState.MyselfTmTransform;
            //this.RolerMove.TargetTransform = moveState.TargetTmTransform;
            //this.RolerMove.MoveSpeed = moveState.MoveSpeed;
        }
        public MoveState GetMoveState()
        {
            MoveState = new MoveState();
            MoveState.RoelerId = this.SoulItem.Id;
            MoveState.MyselfTmTransform = this.TmTransform;
            //MoveState.TargetTmTransform = this.RolerMove.TargetTransform;
            //MoveState.MoveSpeed = this.RolerMove.MoveSpeed;
            //MoveState.CurdateTime = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss:fff");
            return MoveState;
        }

    }
}
