using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Tumo.Models
{
    [Serializable]
    public class InventoryItemDB
    {
        public int Id { get => id; set => id = value; }
        public string Name { get => name2; set => name2 = value; }
        public int InventoryId { get => inventoryId; set => inventoryId = value; }
        public EquipQuality EquipQuality { get => equipQuality; set => equipQuality = value; }
        public Place Place { get => place; set => place = value; }
        public int RolerId { get => rolerId; set => rolerId = value; }
        public int Level { get => level; set => level = value; }
        public int Count { get => count; set => count = value; }
        public int Durability { get => durability; set => durability = value; }
        public int Pice { get => pice; set => pice = value; }
        public string BuildTime { get => buildTime; set => buildTime = value; }

        public InventoryItemDB() { }
        private int id = 0;
        private string name2 = "物品";
        private int inventoryId = 0;
        private EquipQuality equipQuality = EquipQuality.White;  //品质等级（白绿蓝紫橙）        
        private Place place = Place.Terrain;
        private int rolerId = 100001;
        private int level = 0;
        private int count = 1;                                   //物品数量
        private int durability = 0;                              //装备耐久 = 2 * level
        private int pice = 0;                                    //物品价格 = durability * 0.1; 
        private string buildTime = "";
    }
}
