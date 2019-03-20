using System.Collections;
using System.Collections.Generic;
namespace Tumo
{
    public static class TmObjects
    {
        public static ArrayList Entities { get; set; } = new ArrayList();      //服务器 类 实例集合
        public static Dictionary<string, TmComponent> Components { get; set; } = new Dictionary<string, TmComponent>();

        public static ArrayList GameObjects { get; set; } = new ArrayList();   //客户端 游戏物体 实例集合
        public static Dictionary<string, object> Uguies { get; set; } = new Dictionary<string, object>();
        public static ArrayList Soulers { get; set; } = new ArrayList();
    }
}
