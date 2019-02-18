﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Tumo
{
    [Serializable]
    public class TmInventoryItem : TmEntity
    {
        public override void TmAwake()
        {
            base.TmAwake();
            AddComponent(new TmName());
            AddComponent(new TmInventory());
            AddComponent(new TmInventoryDB());
            AddComponent(new TmChangeType());
            AddComponent(new TmProperty());
        }
        public TmInventoryItem() { }
        public TmInventoryItem(TmInventoryDB itemDB)
        {
            if (this.GetComponent<TmInventoryDB>() != null)
            {
                RemoveComponent<TmInventoryDB>();
            }
            AddComponent(itemDB);
            (this.GetComponent<TmName>() as TmName).Name = (this.GetComponent<TmInventoryDB>() as TmInventoryDB).Name;
            (this.GetComponent<TmName>() as TmName).Id = (this.GetComponent<TmInventoryDB>() as TmInventoryDB).Id;
            (this.GetComponent<TmName>() as TmName).ParentId = (this.GetComponent<TmInventoryDB>() as TmInventoryDB).RolerId;
            (this.GetComponent<TmChangeType>() as TmChangeType).Exp = (this.GetComponent<TmInventoryDB>() as TmInventoryDB).Exp;
            (this.GetComponent<TmChangeType>() as TmChangeType).Level = (this.GetComponent<TmInventoryDB>() as TmInventoryDB).Level;
        }

        //public void UpdateItem(int level)
        //{
        //    this.Level = level;
        //    UpdateItem();
        //}
        //public void UpdateItem()
        //{
        //    this.pice = (int)Math.Round(Durability / 10.0f, 0);
        //    switch (Inventory.InfoType)
        //    {
        //        case (InfoType.Brains):
        //            Stamina += (int)(Inventory.Stamina * (Level + 1));
        //            Brains += (int)(Inventory.Brains * (Level + 1));
        //            break;
        //        case (InfoType.Power):
        //            Stamina += (int)(Inventory.Stamina * (Level + 1));
        //            Power += (int)(Inventory.Power * (Level + 1));
        //            break;
        //        case (InfoType.Agility):
        //            Stamina += (int)(Inventory.Stamina * (Level + 1));
        //            Agility += (int)(Inventory.Agility * (Level + 1));
        //            break;
        //        case (InfoType.Bp):
        //            Stamina += (int)(Inventory.Stamina * (Level + 1) * 4);
        //            Bp += (int)(Inventory.Bp * (Level + 1));
        //            break;
        //        case (InfoType.Ap):
        //            Stamina += (int)(Inventory.Stamina * (Level + 1) * 4);
        //            Ap += (int)(Inventory.Ap * (Level + 1));
        //            break;
        //    }
        //}


    }
}
