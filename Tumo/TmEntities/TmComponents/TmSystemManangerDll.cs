namespace Tumo
{
    public class TmSystemManangerDll : TmEntity
    {
        public override void TmAwake()
        {
            AddComponent(new TmSoulerInit());
            AddComponent(new TmInventoryInit());
            AddComponent(new TmSkillInit());
            AddComponent(new TmCoolDownSystem());
            AddComponent(new TmSessionSystem());
            AddComponent(new TmAstarSystem());
            AddComponent(new TmSoulerSystem());
            AddComponent(new TmSkillSystem());
            AddComponent(new TmInventorySystem());

        }
    }
}