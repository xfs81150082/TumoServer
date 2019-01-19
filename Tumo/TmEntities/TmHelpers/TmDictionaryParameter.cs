using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Tumo
{
    public class TmDictionaryParameter : TmComponent
    {
        public EightCode EightCode { get; set; }
        public NineCode NineCode { get; set; }
        public TenCode TenCode { get; set; }
        public ElevenCode ElevenCode { get; set; }
        public TwelveCode TwelveCode { get; set; }
        public Dictionary<string, object> Parameters { get; set; } = new Dictionary<string, object>();
        public TmDictionaryParameter() { }               
    }
}
