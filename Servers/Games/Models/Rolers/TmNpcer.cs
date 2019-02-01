using System;
using System.Collections.Generic;
using Tumo;
namespace Servers
{
    public class TmNpcer : TmEntity
    {
        public override void TmAwake()
        {
            base.TmAwake();
            AddComponent(new TmTeacher());
            AddComponent(new TmCoolDown());
        }
        public TmNpcer() { }
        public TmNpcer(TmEntity entity)
        {
            this.Parent = entity;
        }
    }
}