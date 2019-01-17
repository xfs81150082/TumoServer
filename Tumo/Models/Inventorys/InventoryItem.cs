using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Tumo.Models
{
    [Serializable]
    public class InventoryItem : AttributeValue
    {
        public int Id { get => id; set => id = value; }
        public string Name { get => name2; set => name2 = value; }
        public InventoryItemDB InventoryItemDB { get { return inventoryItemDB; } }
        public Inventory Inventory { get => inventory; set => inventory = value; }
        public EquipQuality EquipQuality { get => equipQuality; set => equipQuality = value; }
        public Place Place { get => place; set => place = value; }
        public int RolerId { get => rolerId; set => rolerId = value; }
        public int Level { get => level; set => level = value; }
        public int Count { get => count; set => count = value; }
        public int Durability { get => durability; set => durability = value; }
        public int Pice { get => pice; set => pice = value; }
        public int BagId { get => bagId; set => bagId = value; }

        public InventoryItem()
        {
            UpdateItem();
        }
        public InventoryItem(Inventory inventory)
        {
            this.Inventory = inventory;
            UpdateItem();
        }
        public InventoryItem(InventoryItemDB itemDB)
        {
            this.inventoryItemDB = itemDB;
            this.id = itemDB.Id;
            this.name2 = itemDB.Name;
            this.place = itemDB.Place;
            this.equipQuality = itemDB.EquipQuality;
            this.count = itemDB.Count;
            this.level = itemDB.Level;
            this.durability = itemDB.Durability;
            this.pice = itemDB.Pice;
            UpdateItem();//属性初始化   
        }
        public InventoryItemDB CreatInventoryItemDB()
        {
            UpdateItem();//属性初始化
            inventoryItemDB.Id = Id;
            inventoryItemDB.Name = Name;
            inventoryItemDB.InventoryId = Inventory.Id;
            inventoryItemDB.Place = Place;
            inventoryItemDB.EquipQuality = EquipQuality;
            inventoryItemDB.Count = Count;
            inventoryItemDB.Level = Level;
            inventoryItemDB.Durability = Durability;
            inventoryItemDB.Pice = Pice;
            return inventoryItemDB;
        }
        public void UpdateItem(int level)
        {
            this.Level = level;
            UpdateItem();
        }
        public void UpdateItem()
        {
            this.pice = (int)Math.Round(Durability / 10.0f, 0);
            switch (Inventory.InfoType)
            {
                case (InfoType.Brains):
                    Stamina += (int)(Inventory.Stamina * (Level + 1));
                    Brains += (int)(Inventory.Brains * (Level + 1));
                    break;
                case (InfoType.Power):
                    Stamina += (int)(Inventory.Stamina * (Level + 1));
                    Power += (int)(Inventory.Power * (Level + 1));
                    break;
                case (InfoType.Agility):
                    Stamina += (int)(Inventory.Stamina * (Level + 1));
                    Agility += (int)(Inventory.Agility * (Level + 1));
                    break;
                case (InfoType.Bp):
                    Stamina += (int)(Inventory.Stamina * (Level + 1) * 4);
                    Bp += (int)(Inventory.Bp * (Level + 1));
                    break;
                case (InfoType.Ap):
                    Stamina += (int)(Inventory.Stamina * (Level + 1) * 4);
                    Ap += (int)(Inventory.Ap * (Level + 1));
                    break;
            }
        }

        private int id = 1;
        private string name2 = "tumo";
        private InventoryItemDB inventoryItemDB;
        private Inventory inventory = new Inventory();
        private EquipQuality equipQuality = EquipQuality.Green;  //品质等级（白绿蓝紫橙）
        private Place place = Place.Terrain;
        private int rolerId = 100001;
        private int level = 0;
        private int count = 1;                                   //物品数量
        private int durability = 0;                              //装备耐久 = 2 * level
        private int pice = 0;                                 //物品价格 = durability * 0.1;
        private int bagId = 0;                                   //临时变量       
    }
}
