using System;
namespace Tumo
{
    [Serializable]
    public class TmInventory : TmEntity
    {
        public override void TmAwake()
        {
            base.TmAwake();
            AddComponent(new TmName());
            AddComponent(new TmLabel());
            AddComponent(new TmFixedType());
            AddComponent(new TmProperty());
        }
        public TmInventory()
        {
            (this.GetComponent<TmName>() as TmName).Id = 11101;
            (this.GetComponent<TmName>() as TmName).Name = "衣服";
            (this.GetComponent<TmLabel>() as TmLabel).Icon = "girl1001";
            (this.GetComponent<TmLabel>() as TmLabel).AvatarName = "武器";
            (this.GetComponent<TmLabel>() as TmLabel).ChaterId = 111;
            (this.GetComponent<TmLabel>() as TmLabel).LevelUpLimit = 30;
            (this.GetComponent<TmLabel>() as TmLabel).Does = "reader.GetString(9)";
            (this.GetComponent<TmFixedType>() as TmFixedType).RoleType = (RoleType)1;
            (this.GetComponent<TmFixedType>() as TmFixedType).Quality = (Quality)1;
            (this.GetComponent<TmProperty>() as TmProperty).Stamina = 1;
            (this.GetComponent<TmProperty>() as TmProperty).Brains = 1;
            (this.GetComponent<TmProperty>() as TmProperty).Power = 1;
            (this.GetComponent<TmProperty>() as TmProperty).Agility = 1;
            (this.GetComponent<TmProperty>() as TmProperty).Hr = 0.0;
            (this.GetComponent<TmProperty>() as TmProperty).Cr = 0.0;
            (this.GetComponent<TmProperty>() as TmProperty).Sp = 0.0;
            (this.GetComponent<TmProperty>() as TmProperty).StaminaRate = 0.0;
            (this.GetComponent<TmProperty>() as TmProperty).BrainsRate = 0.0;
            (this.GetComponent<TmProperty>() as TmProperty).PowerRate = 0.0;
            (this.GetComponent<TmProperty>() as TmProperty).AgilityRate = 0.0;
        }
    }
}
