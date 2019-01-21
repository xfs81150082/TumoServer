using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Tumo
{
    [Serializable]
    public class TmParameter : TmDictionaryParameter
    {
        public string Key { get; set; }
    }
}
