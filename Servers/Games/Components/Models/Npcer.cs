using System;
using System.Collections.Generic;
using Tumo;
namespace Servers
{
    [Serializable]
    public class Npcer : TmEntity
    {
        public override void TmAwake()
        {
            base.TmAwake();
            AddComponent(new TmTeacher());
            AddComponent(new TmCoolDown());
            AddComponent(new TmSoulerDB());
        }
    }
}
