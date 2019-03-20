namespace Tumo
{
    public class TmSystemManangerDll : TmEntity
    {
        public override void TmAwake()
        {
            AddComponent(new TmCoolDownSystem());
            AddComponent(new TmAstarSystem());
        }
    }
}