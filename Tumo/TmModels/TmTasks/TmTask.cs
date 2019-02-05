using System;
using System.Collections.Generic;
namespace Tumo
{
    public class TmTask : TmEntity
    {
        public override void TmAwake()
        {
            base.TmAwake();
            AddComponent(new TmName());
            AddComponent(new TmLabel());
            AddComponent(new TmFixedType());
            AddComponent(new TmProperty());
        }
        public TmTask()
        {
            (this.GetComponent<TmName>() as TmName).Id = 15101;
            (this.GetComponent<TmName>() as TmName).Name = "德鲁伊";
            (this.GetComponent<TmLabel>() as TmLabel).Icon = "headimageboy";
            (this.GetComponent<TmLabel>() as TmLabel).AvatarName = "15101_AncientWarrior";
            (this.GetComponent<TmLabel>() as TmLabel).ChaterId = 111;
            (this.GetComponent<TmLabel>() as TmLabel).LevelUpLimit = 30;
            (this.GetComponent<TmLabel>() as TmLabel).Does = "reader.GetString(9)";
            (this.GetComponent<TmFixedType>() as TmFixedType).RoleType = (RoleType)1;
            (this.GetComponent<TmFixedType>() as TmFixedType).Quality = (Quality)1;
            (this.GetComponent<TmProperty>() as TmProperty).Stamina = 12;
            (this.GetComponent<TmProperty>() as TmProperty).Brains = 10;
            (this.GetComponent<TmProperty>() as TmProperty).Power = 14;
            (this.GetComponent<TmProperty>() as TmProperty).Agility = 10;
            (this.GetComponent<TmProperty>() as TmProperty).Hr = 0.8;
            (this.GetComponent<TmProperty>() as TmProperty).Cr = 0.2;
            (this.GetComponent<TmProperty>() as TmProperty).Sp = 2.0;
            (this.GetComponent<TmProperty>() as TmProperty).StaminaRate = 10.0;
            (this.GetComponent<TmProperty>() as TmProperty).BrainsRate = 1.0;
            (this.GetComponent<TmProperty>() as TmProperty).PowerRate = 1.0;
            (this.GetComponent<TmProperty>() as TmProperty).AgilityRate = 1.0;
        }
    }
}
