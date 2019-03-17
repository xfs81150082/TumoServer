using System.Collections;
using System.Collections.Generic;
namespace Tumo
{
    public static class TmObjects
    {
        public static ArrayList Entities = new ArrayList();
        public static Dictionary<string, TmComponent> Components { get; set; } = new Dictionary<string, TmComponent>();

        public static ArrayList Objects = new ArrayList();
        public static ArrayList Soulers = new ArrayList();
    }
}
