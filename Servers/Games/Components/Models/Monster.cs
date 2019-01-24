using Tumo;
using System;
using System.Collections.Generic;
namespace Servers
{
    public class Monster : TmEntity
    {
        public override void TmAwake()
        {
            base.TmAwake();
            AddComponent(new TmBooker());
            AddComponent(new TmCoolDown());
            AddComponent(new TmSoulerDB());
        }
    }
}