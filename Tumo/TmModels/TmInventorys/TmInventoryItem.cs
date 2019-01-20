using System;
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
            AddComponent(new TmAttribute());
            AddComponent(new TmInventoryAdd());            
            AddComponent(new TmChangeType());
        }
        public TmInventoryItem() { }
        public TmInventoryItem(TmInventoryDB itemDB)
        {
            if (GetComponent<TmInventoryDB>() != null)
            {
                TmInventoryDB tem = GetComponent<TmInventoryDB>() as TmInventoryDB;
                tem = itemDB;
            }
        }
        //public InventoryItem(Inventory inventory)
        //{
        //    this.Inventory = inventory;
        //    UpdateItem();
        //}
   
        //public InventoryItemDB CreatInventoryItemDB()
        //{
        //    UpdateItem();//属性初始化
        //    inventoryItemDB.Id = Id;
        //    inventoryItemDB.Name = Name;
        //    inventoryItemDB.InventoryId = Inventory.Id;
        //    inventoryItemDB.Place = Place;
        //    inventoryItemDB.EquipQuality = EquipQuality;
        //    inventoryItemDB.Count = Count;
        //    inventoryItemDB.Level = Level;
        //    inventoryItemDB.Durability = Durability;
        //    inventoryItemDB.Pice = Pice;
        //    return inventoryItemDB;
        //}
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
