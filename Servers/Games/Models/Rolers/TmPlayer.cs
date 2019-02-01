using Tumo;
using Tumo.Models;
using System;
namespace Servers
{
    public class TmPlayer : TmEntity
    {
        public override void TmAwake()
        {
            base.TmAwake();
            AddComponent(new TmEngineer());
            AddComponent(new TmCoolDown());
        }
    }
}