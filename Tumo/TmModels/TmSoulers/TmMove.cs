using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Timers;

namespace Tumo
{
    public class TmMove : TmComponent
    {       
        public double MoveSpeed = 0;
        public TmTransform TargetTransform;
        public bool IsCanSeeing = false;
        public bool IsAttacking = false;
        public TmTransform SpawnTransform;
        private TmRoler target;
        private double canSeeDistance = 225.0;
        private double arriveDistance = 25.0;
        private double runSpeed = 4.0;
        private double walkSpeed = 2.0;
        private int timer1 = 0;
        private int restTime1 = 3;
        private int valTime = 1;

        public TmMove() { }
        public TmMove(TmTransform spawn)
        {
            if (spawn != null)
            {
                this.SpawnTransform = spawn;
            }
        }
        public TmMove(TmSoulerItem soulItem)
        {
            if (soulItem != null)
            {
                this.SpawnTransform = new TmTransform();
            }
        }

        public void AIPatrols(TmRoler myself, List<TmRoler> targets)
        {
            if (targets.Count > 0)
            {
                if(IsAttacking = false || target == null) 
                {
                   target = NearestTarget(myself, targets);
                }                
                if (target != null)
                {
                    double distance = Distance(myself.TmTransform, target.TmTransform);
                    if (distance < canSeeDistance)
                    {
                        //当canSeeDistance > 目标距离平方 > arriveDistance，则怪物追击目标//小怪转向目标
                        IsCanSeeing = true;
                        if (distance > arriveDistance)
                        {
                            IsAttacking = false;
                            TargetTransform = target.TmTransform;
                            MoveSpeed = runSpeed;
                        }
                        else
                        {
                            //进入小怪攻击范围 
                            IsAttacking = true;
                            MoveSpeed = 0;
                        }
                    }
                    else
                    {
                        Patrols(myself);
                        IsCanSeeing = false;
                        IsAttacking = false;
                    }
                }
                else
                {
                    Patrols(myself);
                    IsCanSeeing = false;
                    IsAttacking = false;
                }
            }
            else
            {
                Patrols(myself);
                IsCanSeeing = false;
                IsAttacking = false;
            }
        }
        void Patrols(TmRoler myself)
        {
            double dis = Distance(myself.TmTransform, TargetTransform);
            if (dis < arriveDistance)
            {
                MoveSpeed = 0;
                timer1 += valTime;
                if (timer1 > restTime1)
                {
                    timer1 = 0;
                    TargetTransform = GetTarget();
                }
                else
                {
                    if (dis != 0)
                    {
                        myself.TmTransform = TargetTransform;
                    }
                }             
            }
            else
            {
                MoveSpeed = walkSpeed;
            }
        }
        TmRoler NearestTarget(TmRoler myself, List<TmRoler> targets)
        {
            TmRoler target = null;
            double distance = 1000000;
            for (int i = 0; i < targets.Count; i++)
            {
                double curDis = Distance(myself.TmTransform, targets[i].TmTransform);
                if (curDis < distance)
                {
                    target = targets[i];
                    distance = curDis;
                }
            }
            return target;
        }
        double Distance(TmTransform myself, TmTransform target)
        {
            double dis = Math.Pow((myself.px - target.px), 2) + Math.Pow((myself.pz - target.pz), 2);
            return dis;
        }
        TmTransform GetTarget()
        {
            TmTransform target = new TmTransform();
            Random ran = new Random();
            double rx = ran.NextDouble();
            double rz = ran.NextDouble();
            double x = rx * 40 - 20;
            double z = rz * 40 - 20;
            target.px = SpawnTransform.px + x;
            target.pz = SpawnTransform.pz + z;
            return target;           
        }

    }
}
