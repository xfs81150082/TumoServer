﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

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
            AddComponent(new TmAttribute());
        }
        public TmInventory()
        {
            (this.GetComponent<TmName>() as TmName).Id = 15101;
            (this.GetComponent<TmName>() as TmName).Name = "衣服";
            (this.GetComponent<TmLabel>() as TmLabel).Icon = "headimageboy";
            (this.GetComponent<TmLabel>() as TmLabel).AvatarName = "15101_AncientWarrior";
            (this.GetComponent<TmLabel>() as TmLabel).ChaterId = 111;
            (this.GetComponent<TmLabel>() as TmLabel).LevelUpLimit = 30;
            (this.GetComponent<TmLabel>() as TmLabel).Does = "reader.GetString(9)";
            (this.GetComponent<TmFixedType>() as TmFixedType).RoleType = (RoleType)1;
            (this.GetComponent<TmFixedType>() as TmFixedType).Quality = (Quality)1;
            (this.GetComponent<TmAttribute>() as TmAttribute).Stamina = 12;
            (this.GetComponent<TmAttribute>() as TmAttribute).Brains = 10;
            (this.GetComponent<TmAttribute>() as TmAttribute).Power = 14;
            (this.GetComponent<TmAttribute>() as TmAttribute).Agility = 10;
            (this.GetComponent<TmAttribute>() as TmAttribute).Hr = 0.8;
            (this.GetComponent<TmAttribute>() as TmAttribute).Cr = 0.2;
            (this.GetComponent<TmAttribute>() as TmAttribute).Sp = 2.0;
            (this.GetComponent<TmAttribute>() as TmAttribute).StaminaRate = 10.0;
            (this.GetComponent<TmAttribute>() as TmAttribute).BrainsRate = 1.0;
            (this.GetComponent<TmAttribute>() as TmAttribute).PowerRate = 1.0;
            (this.GetComponent<TmAttribute>() as TmAttribute).AgilityRate = 1.0;
        }
    }
}
