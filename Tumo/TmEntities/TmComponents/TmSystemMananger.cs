namespace Tumo
{
    public class TmSystemMananger : TmEntity
    {
        public override void TmAwake()
        {
            AddComponent(new TmSystemManangerDll());
        }
    }
}