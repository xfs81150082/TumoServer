using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Tumo
{
    public static class TmEcsDictionary
    {
        public static Dictionary<string, TmEntity> Entities { get; set; } = new Dictionary<string, TmEntity>();
        public static Dictionary<string, TmComponent> Components { get; set; } = new Dictionary<string, TmComponent>();
        public static Dictionary<string, TmSystem> Systems { get; set; } = new Dictionary<string, TmSystem>();
    }
}
