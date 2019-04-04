using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
namespace Tumo
{
    class TmInventoryInit : TmComponent
    {
        public override void TmAwake()
        {
            TmSoulerInfo();
        }
        void TmSoulerInfo()
        {
            TmObjects.Inventorys = GetTmSoulers();
        }
        Dictionary<int, TmInventory> GetTmSoulers()
        {
            Dictionary<int, TmInventory> soulers = new Dictionary<int, TmInventory>();
            TmInventory souler11101 = GetTmSouler("武器", 11101, "man1001", "InventoryItemUI", "Icon_Player01", 30, "是最--的装备", RoleType.Booker, EquipType.Break, InfoType.Bp, Quality.Green, 4);
            soulers.Add(souler11101.Id, souler11101);
            TmInventory souler11102 = GetTmSouler("头盔", 11102, "man1002", "InventoryItemUI", "Icon_Player01", 30, "是最--的装备", RoleType.Booker, EquipType.Water, InfoType.Bp, Quality.Green, 4);
            soulers.Add(souler11102.Id, souler11102);
            TmInventory souler11103 = GetTmSouler("衣服", 11103, "man1001", "InventoryItemUI", "Icon_Player01", 30, "是最--的装备", RoleType.Booker, EquipType.Break, InfoType.Bp, Quality.Green, 4);
            soulers.Add(souler11103.Id, souler11103);
            TmInventory souler11104 = GetTmSouler("鞋子", 11104, "man1002", "InventoryItemUI", "Icon_Player01", 30, "是最--的装备", RoleType.Booker, EquipType.Water, InfoType.Bp, Quality.Green, 4);
            soulers.Add(souler11104.Id, souler11104);
            TmInventory souler11105 = GetTmSouler("项链", 11105, "man1001", "InventoryItemUI", "Icon_Player01", 30, "是最--的装备", RoleType.Booker, EquipType.Break, InfoType.Bp, Quality.Green, 4);
            soulers.Add(souler11105.Id, souler11105);
            TmInventory souler11106 = GetTmSouler("手镯", 11106, "man1002", "InventoryItemUI", "Icon_Player01", 30, "是最--的装备", RoleType.Booker, EquipType.Water, InfoType.Bp, Quality.Green, 4);
            soulers.Add(souler11106.Id, souler11106);
            TmInventory souler11107 = GetTmSouler("戒指", 11107, "man1001", "InventoryItemUI", "Icon_Player01", 30, "是最--的装备", RoleType.Booker, EquipType.Break, InfoType.Bp, Quality.Green, 4);
            soulers.Add(souler11107.Id, souler11107);
            TmInventory souler11108 = GetTmSouler("翅膀", 11108, "man1002", "InventoryItemUI", "Icon_Player01", 30, "是最--的装备", RoleType.Booker, EquipType.Water, InfoType.Bp, Quality.Green, 4);
            soulers.Add(souler11108.Id, souler11108);
            TmInventory souler12101 = GetTmSouler("武器", 12101, "girl1001", "InventoryItemUI", "Icon_Player01", 30, "是最--的装备", RoleType.Booker, EquipType.Break, InfoType.Bp, Quality.Green, 4);
            soulers.Add(souler12101.Id, souler12101);
            TmInventory souler12102 = GetTmSouler("头盔", 12102, "girl1001", "InventoryItemUI", "Icon_Player01", 30, "是最--的装备", RoleType.Booker, EquipType.Water, InfoType.Bp, Quality.Green, 4);
            soulers.Add(souler12102.Id, souler12102);
            TmInventory souler12103 = GetTmSouler("衣服", 12103, "girl1001", "InventoryItemUI", "Icon_Player01", 30, "是最--的装备", RoleType.Booker, EquipType.Break, InfoType.Bp, Quality.Green, 4);
            soulers.Add(souler12103.Id, souler12103);
            TmInventory souler12104 = GetTmSouler("鞋子", 12104, "girl1001", "InventoryItemUI", "Icon_Player01", 30, "是最--的装备", RoleType.Booker, EquipType.Water, InfoType.Bp, Quality.Green, 4);
            soulers.Add(souler12104.Id, souler12104);
            TmInventory souler12105 = GetTmSouler("项链", 12105, "girl1001", "InventoryItemUI", "Icon_Player01", 30, "是最--的装备", RoleType.Booker, EquipType.Break, InfoType.Bp, Quality.Green, 4);
            soulers.Add(souler12105.Id, souler12105);
            TmInventory souler12106 = GetTmSouler("手镯", 12106, "girl1001", "InventoryItemUI", "Icon_Player01", 30, "是最--的装备", RoleType.Booker, EquipType.Water, InfoType.Bp, Quality.Green, 4);
            soulers.Add(souler12106.Id, souler12106);
            TmInventory souler12107 = GetTmSouler("戒指", 12107, "girl1001", "InventoryItemUI", "Icon_Player01", 30, "是最--的装备", RoleType.Booker, EquipType.Break, InfoType.Bp, Quality.Green, 4);
            soulers.Add(souler12107.Id, souler12107);
            TmInventory souler12108 = GetTmSouler("翅膀", 12108, "girl1001", "InventoryItemUI", "Icon_Player01", 30, "是最--的装备", RoleType.Booker, EquipType.Water, InfoType.Bp, Quality.Green, 4);
            soulers.Add(souler12108.Id, souler12108);
            TmInventory souler14101 = GetTmSouler("面包", 14101, "bread", "InventoryItemUI", "Icon_Player01", 30, "这是一个恢复血量的面包。", RoleType.Booker, EquipType.Break, InfoType.Bp, Quality.Green, 4);
            soulers.Add(souler14101.Id, souler14101);
            TmInventory souler14102 = GetTmSouler("矿泉水", 14102, "water", "InventoryItemUI", "Icon_Player01", 30, "这是一个恢复法术值的矿泉水。", RoleType.Booker, EquipType.Water, InfoType.Bp, Quality.Green, 4);
            soulers.Add(souler14102.Id, souler14102);
            TmInventory souler14103 = GetTmSouler("宝箱", 14103, "box", "InventoryItemUI", "Icon_Player01", 30, "这是一个黄金宝箱，里面有宝物。", RoleType.Booker, EquipType.Water, InfoType.Bp, Quality.Green, 4);
            soulers.Add(souler14103.Id, souler14103);
            return soulers;
        }
        TmInventory GetTmSouler(string name, int id, string icon, string avatarname, string chater, int leveluplimit, string does, RoleType roleType, EquipType equipType, InfoType infoType, Quality quality, int maxcoldtime)
        {
            TmInventory souler = new TmInventory();
            souler.Name = name;
            souler.Id = id;
            souler.Icon = icon;
            souler.AvatarName = avatarname;
            souler.Chater = chater;
            souler.Does = does;
            souler.RoleType = roleType;
            souler.EquipType = equipType;
            souler.InfoType = infoType;
            souler.Quality = quality;
            souler.MaxColdTime = maxcoldtime;
            return souler;
        }

    }
}
