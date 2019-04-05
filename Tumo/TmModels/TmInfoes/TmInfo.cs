using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace Tumo
{
    public static class TmInfo
    {
        public static GameObject Player { get; set; }
        public static GameObject Target { get; set; }
        public static List<GameObject> Monsters { get; set; } = new List<GameObject>();
        public static List<GameObject> Npcers { get; set; } = new List<GameObject>();
        public static List<GameObject> Players { get; set; } = new List<GameObject>();
        public static GameObject Minmap { get; set; }
        public static List<GameObject> HpBars = new List<GameObject>();
        public static ArrayList Whites { get; set; } = new ArrayList();
        public static ArrayList Blacks { get; set; } = new ArrayList();
        public static List<TmSoulerItem> Rolers = new List<TmSoulerItem>();
        public static List<TmInventoryItem> Knapsacks = new List<TmInventoryItem>();
        public static List<TmInventoryItem> Smithys = new List<TmInventoryItem>();
        public static Dictionary<int, TmSkillItem> Buffs = new Dictionary<int, TmSkillItem>();
        public static Dictionary<int, TmSkillItem> Abilities = new Dictionary<int, TmSkillItem>();
    }
}