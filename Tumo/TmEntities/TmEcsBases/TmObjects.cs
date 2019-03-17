using System.Collections;
using System.Collections.Generic;
namespace Tumo
{
    public static class TmObjects
    {
        public static Dictionary<string, TmEcsBase> Ecses { get; set; } = new Dictionary<string, TmEcsBase>();
        public static Dictionary<string, TmEntity> Entities { get; set; } = new Dictionary<string, TmEntity>();
        public static Dictionary<string, TmComponent> Components { get; set; } = new Dictionary<string, TmComponent>();
        public static Dictionary<string, TmSystem> Systems { get; set; } = new Dictionary<string, TmSystem>();

        public static ArrayList Objects = new ArrayList();
        public static ArrayList Soulers = new ArrayList();
    }
}
