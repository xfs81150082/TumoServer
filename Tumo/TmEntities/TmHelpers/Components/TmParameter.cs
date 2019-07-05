using System;
using System.Collections.Generic;
namespace Tumo
{
    [Serializable]
    public class TmParameter
    {
        public List<string> Keys { get; set; } = new List<string>();
        public TenCode TenCode { get; set; }
        public ElevenCode ElevenCode { get; set; }
        public Dictionary<string, object> Parameters { get; set; } = new Dictionary<string, object>();

    }
}
