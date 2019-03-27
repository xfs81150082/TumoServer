using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace Tumo
{
    public static class TmObjects
    {
        public static Dictionary<string, TmComponent> Components { get; set; } = new Dictionary<string, TmComponent>();
        public static ArrayList Entities { get; set; } = new ArrayList();                                                      //服务器 类 实例集合
        public static ArrayList GameObjects { get; set; } = new ArrayList();
        public static Dictionary<string, GameObject> Dict = new Dictionary<string, GameObject>();
        public static ArrayList Soulers { get; set; } = new ArrayList();
    }
}
