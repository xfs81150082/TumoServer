namespace Tumo
{
    public class TmSence : TmEntity
    {
        public override void TmAwake()
        {
            this.AddComponent(new TmSystemManangerDll());
        }
    }
}
