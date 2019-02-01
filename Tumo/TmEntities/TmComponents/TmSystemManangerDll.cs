namespace Tumo
{
    public class TmSystemManangerDll : TmEntity
    {
        public override void TmAwake()
        {
            base.TmAwake();
            AddComponent(new TmCoolDownSystem());
        }
    }
}
