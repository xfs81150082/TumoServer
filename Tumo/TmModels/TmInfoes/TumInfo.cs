using System;
using System.Collections.Generic;
using UnityEngine;
namespace Tumo
{
    public static class TumInfo
    {
        public static GameObject Player { get; set; }
        public static GameObject Target { get; set; }
        public static List<GameObject> Monsters { get; set; } = new List<GameObject>();
    }
}