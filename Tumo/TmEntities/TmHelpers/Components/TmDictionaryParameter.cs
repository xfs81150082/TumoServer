using System;
using System.Collections.Generic;
namespace Tumo
{
    public class TmDictionaryParameter
    {
        public TenCode TenCode { get; set; }
        public ElevenCode ElevenCode { get; set; }
        public KeyCode KeyCode { get; set; }
        public Dictionary<string, object> Parameters { get; set; } = new Dictionary<string, object>();
    }
}
