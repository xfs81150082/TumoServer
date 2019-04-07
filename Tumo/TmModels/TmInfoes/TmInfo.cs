using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace Tumo
{
    public static class TmInfo
    {
        public static ArrayList GameObjects { get; set; } = new ArrayList();
        public static ArrayList SpawnRoler { get; set; } = new ArrayList();                                           //SoulerItem　生产角色临时　数组列表
        public static Dictionary<string, GameObject> GoDict = new Dictionary<string, GameObject>();
        public static Dictionary<int, TmSoulerItem> SoulerItems = new Dictionary<int, TmSoulerItem>();
        public static TmSoulerItem Engineer { get; set; }
        public static GameObject Player { get; set; }
        public static GameObject Target { get; set; }
        public static Dictionary<int, GameObject> Monsters { get; set; } = new Dictionary<int, GameObject>();    //角色数组列表,战斗时用于遍历计算目标
        public static Dictionary<int, GameObject> Npcers { get; set; } = new Dictionary<int, GameObject>();
        public static Dictionary<int, GameObject> Players { get; set; } = new Dictionary<int, GameObject>();
        public static GameObject Minmap { get; set; }
        public static List<GameObject> HpBars = new List<GameObject>();
        public static Dictionary<int, TmSkillItem> Buffs = new Dictionary<int, TmSkillItem>();
        public static Dictionary<int, TmSkillItem> Abilities = new Dictionary<int, TmSkillItem>();
        public static List<TmInventoryItem> Knapsacks = new List<TmInventoryItem>();
        public static List<TmInventoryItem> Smithys = new List<TmInventoryItem>();
    }
}