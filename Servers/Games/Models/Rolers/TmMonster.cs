﻿using Tumo;
using System;
using System.Collections.Generic;
namespace Servers
{
    public class TmMonster : TmEntity
    {
        public override void TmAwake()
        {
            base.TmAwake();
            AddComponent(new TmBooker());
            AddComponent(new TmCoolDown());
        }
        public TmMonster() { }
        public TmMonster(TmEntity entity)
        {
            this.Parent = entity;
        }
    }
}