using System;
using System.Collections.Generic;
namespace Tumo
{
    public class TmDictionaryComponent : TmComponent
    {
        public Dictionary<string, TmComponent> Components = new Dictionary<string, TmComponent>();
    }
}
