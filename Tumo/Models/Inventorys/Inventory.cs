using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Tumo.Models
{
    [Serializable]
    public class Inventory : Attribute
    {
        public InventoryType InventoryType { get => inventoryType; set => inventoryType = value; }
        public EquipType EquipType { get => equipType; set => equipType = value; }
        public InfoType InfoType { get => infoType; set => infoType = value; }

        public Inventory() { }
        private InventoryType inventoryType = InventoryType.Equip;    //物品类型(装备、物品、箱子)
        private EquipType equipType = EquipType.Weapon;               //装备类型（帽子，衣，鞋子，武器，项链。。。等）  
        private InfoType infoType = InfoType.Bp;                      //作用类型，表示作用在那个属性之上
    }
}
