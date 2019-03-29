using System;
using System.Collections.Generic;
namespace Tumo
{
    public abstract class TmRoler : TmEntity
    {
        public override void TmAwake()
        {
            base.TmAwake();
            AddComponent(new TmTransform());
            AddComponent(new TmSoulerItem());
            AddComponent(new TmMove());
            AddComponent(new TmAttack());
            AddComponent(new TmInventoryItem());
            AddComponent(new TmSkillItem());
        }
        public TmTransform TmTransform { get; set; }
        public TmSoulerItem SoulItem { get; set; }
        public TmStatus MoveState { get; set; }
        public TmMove RolerMove { get; set; }
        public TmAttack RolerAttack { get; set; }
        public List<TmRoler> TargetRolers { get; set; }
        public bool IsOut { get; set; } = true;
        
        public TmRoler() {   }
        public void SetMoveState(TmStatus moveState)
        {
            //this.MoveState = moveState;
            //this.TmTransform = moveState.MyselfTmTransform;
            //this.RolerMove.TargetTransform = moveState.TargetTmTransform;
            //this.RolerMove.MoveSpeed = moveState.MoveSpeed;
        }
        public TmStatus GetMoveState()
        {
            MoveState = new TmStatus();
            //MoveState.RoelerId = (this.SoulItem.GetComponent<TmName>() as TmName).Id;
            //MoveState.MyselfTmTransform = this.TmTransform;
            //MoveState.TargetTmTransform = this.RolerMove.TargetTransform;
            //MoveState.MoveSpeed = this.RolerMove.MoveSpeed;
            //MoveState.CurdateTime = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss:fff");
            return MoveState;
        }

    }
}
