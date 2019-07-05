using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Tumo;
namespace Tumo
{
    public class TmGridManager : TmComponent
    {
        private Dictionary<string, TmGridMap> GridMaps = new Dictionary<string, TmGridMap>();
        void Add(string key, TmGridMap map)
        {
            TmGridMap tem;
            GridMaps.TryGetValue(key, out tem);
            if (tem == null)
            {
                GridMaps.Add(key, map);
            }
        }
        TmGridMap Get(string key)
        {
            TmGridMap map = null;
            GridMaps.TryGetValue(key, out map);
            return map;
        }
        void Remove(string key)
        {
            TmGridMap tem;
            GridMaps.TryGetValue(key, out tem);
            if (tem != null)
            {
                GridMaps.Remove(key);
            }
        }
    }
}