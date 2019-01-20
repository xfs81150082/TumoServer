using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Tumo
{
    [Serializable]
    public class TmSkillItem : TmEntity
    {
        public override void TmAwake()
        {
            base.TmAwake();
            AddComponent(new TmName());
            AddComponent(new TmAttribute());
            AddComponent(new TmChangeType());
            AddComponent(new TmSkill());
            AddComponent(new TmSkillDB());
            AddComponent(new TmSkillAdd());
        }
        public TmSkillItem() { }
        public TmSkillItem(TmSkillDB itemDB)
        {
            if (GetComponent<TmSkillDB>() != null)
            {
                TmSkillDB tem = GetComponent<TmSkillDB>() as TmSkillDB;
                tem = itemDB;
            }
        }
    }
}
