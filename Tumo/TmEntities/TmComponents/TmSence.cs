namespace Tumo
{
    public class TmSence : TmEntity
    {
        public override void TmAwake()
        {
            base.TmAwake();
            this.AddComponent(new TmSystemManangerDll());
        }
    }
}
