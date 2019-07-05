using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace Tumo
{
    public static class TmObjects
    {
        public static ArrayList Entities { get; set; } = new ArrayList();                                                      //服务器 类 实例集合
        public static Dictionary<string, TmComponent> Components { get; set; } = new Dictionary<string, TmComponent>();
        public static Dictionary<int, TmSouler> Soulers { get; set; } = new Dictionary<int, TmSouler>();
        public static Dictionary<int, TmSkill> Skills { get; set; } = new Dictionary<int, TmSkill>();
        public static Dictionary<int, TmInventory> Inventorys { get; set; } = new Dictionary<int, TmInventory>();
        public static Dictionary<int, List<TmInventoryDB>> InventoryDBs = new Dictionary<int, List<TmInventoryDB>>();
        public static Dictionary<int, List<TmSkillDB>> SkillDBs { get; set; } = new Dictionary<int, List<TmSkillDB>>();
        public static Dictionary<int, TmSoulerDB> Bookers { get; set; } = new Dictionary<int, TmSoulerDB>();
        public static Dictionary<int, TmSoulerDB> Teachers { get; set; } = new Dictionary<int, TmSoulerDB>();
        public static Dictionary<int, TmSoulerDB> Engineers { get; set; } = new Dictionary<int, TmSoulerDB>();
        public static Dictionary<int, TmStatus> OutRolerStatuses { get; set; } = new Dictionary<int, TmStatus>();
        public static Dictionary<int, TmStatus> InRolerStatuses { get; set; } = new Dictionary<int, TmStatus>();
        public static Dictionary<int, TmStatus> OutEngineerStatuses { get; set; } = new Dictionary<int, TmStatus>();
        public static Dictionary<int, TmStatus> InEngineerStatuses { get; set; } = new Dictionary<int, TmStatus>();
        public static TmSoulerDB Engineer { get; set; }
        public static TmGrid[,] Grids { get; set; }
        public static Dictionary<int, TmGridMap> GridMaps { get; set; } = new Dictionary<int, TmGridMap>();
    }
}
