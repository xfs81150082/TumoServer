using Tumo;
using Tumo.Models;
using System;
namespace Servers
{
    [Serializable]
    public class TmPlayer : TmEntity
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
