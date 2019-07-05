using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
namespace Tumo
{
    public class TmSession : TmComponent
    {
        public bool IsLogin { get; set; } = false;
        public int bookersChange { get; set; } = -1;
        public int teachersChange { get; set; } = -1;
        public int engineersChange { get; set; } = -1;
        public int inventorysChange { get; set; } = -1;
        public int skillsChange { get; set; } = -1;
        public List<TmInventoryDB> InventoryDBs { get; set; }
        public List<TmSkillDB> SkillDBs { get; set; }
        public Dictionary<int, TmSoulerDB> Engineers { get; set; }
        public TmSoulerDB Engineer { get; set; }
    }
}
