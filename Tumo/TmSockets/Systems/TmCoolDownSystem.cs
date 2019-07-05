using System;
namespace Tumo
{
    public class TmCoolDownSystem : TmSystem
    {
        public override void TmAwake()
        {
            ValTime = 4000;
            AddComponent(new TmCoolDown());
        }
        public override void TmUpdate()
        {
            foreach (TmEntity entity in GetTmEntities())
            {
                UpdateCoolDown(entity);
            }
        }
        void UpdateCoolDown(TmEntity entity)
        {
            TmCoolDown cd = entity.GetComponent<TmCoolDown>();
            if (cd.Counting)
            {
                cd.CdCount += 1;
                if (cd.CdCount >= cd.MaxCdCount)
                {
                    cd.CdCount = 0;
                    cd.Counting = false;
                }
            }
            if (cd.Timing)
            {
                cd.CdTime += 4;
                if (cd.CdTime >= cd.MaxCdTime)
                {
                    cd.CdTime = 0;
                    cd.Timing = false;
                }
            }
        }
    }
}