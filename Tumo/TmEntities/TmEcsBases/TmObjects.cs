﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace Tumo
{
    public static class TmObjects
    {
        public static Dictionary<string, TmComponent> Components { get; set; } = new Dictionary<string, TmComponent>();
        public static ArrayList Entities { get; set; } = new ArrayList();                                                      //服务器 类 实例集合
        public static ArrayList GameObjects { get; set; } = new ArrayList();
        public static Dictionary<string, GameObject> GoDict = new Dictionary<string, GameObject>();
        public static ArrayList RolerSpawn { get; set; } = new ArrayList();
        public static Dictionary<int, TmSouler> Soulers { get; set; } = new Dictionary<int, TmSouler>();
        public static Dictionary<int, TmSkill> Skills { get; set; } = new Dictionary<int, TmSkill>();
        public static Dictionary<int, TmInventory> Inventorys { get; set; } = new Dictionary<int, TmInventory>();
        public static Dictionary<int, TmSoulerDB> Bookers { get; set; } = new Dictionary<int, TmSoulerDB>();
        public static Dictionary<int, TmSoulerDB> Teachers { get; set; } = new Dictionary<int, TmSoulerDB>();
        public static Dictionary<int, TmSoulerDB> Engineers { get; set; } = new Dictionary<int, TmSoulerDB>();
        public static TmSoulerDB Engineer { get; set; }
        public static List<TmInventoryDB> Knapsacks { get; set; } = new List<TmInventoryDB>();
        public static Dictionary<int, TmSkillDB> SkillDBs { get; set; } = new Dictionary<int, TmSkillDB>();
        public static TmGrid[,] Grids { get; set; }
        public static Dictionary<string, TmGridMap> GridMaps = new Dictionary<string, TmGridMap>();
    }
}
