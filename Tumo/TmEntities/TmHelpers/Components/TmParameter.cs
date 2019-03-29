using System;
using System.Collections.Generic;
namespace Tumo
{
    [Serializable]
    public class TmParameter : TmDictionaryParameter
    {
        public List<string> Keys { get; set; } = new List<string>();
    }
}
