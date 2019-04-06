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
        public static List<TmInventoryDB> InventoryDBs = new List<TmInventoryDB>();
        public static Dictionary<string, TmSkillDB> SkillDBs { get; set; } = new Dictionary<string, TmSkillDB>();
        public static Dictionary<string, TmGridMap> GridMaps { get; set; } = new Dictionary<string, TmGridMap>();
        public static TmGrid[,] Grids { get; set; }
        public static Dictionary<string, TmSoulerDB> Bookers { get; set; } = new Dictionary<string, TmSoulerDB>();
        public static Dictionary<string, TmSoulerDB> Teachers { get; set; } = new Dictionary<string, TmSoulerDB>();
        public static Dictionary<string, TmSoulerDB> Engineers { get; set; } = new Dictionary<string, TmSoulerDB>();
        public static TmSoulerDB Engineer { get; set; }
    }
}
