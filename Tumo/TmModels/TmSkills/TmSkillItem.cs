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
            AddComponent(new TmSkill());
            AddComponent(new TmSkillDB());
            AddComponent(new TmChangeType());
            AddComponent(new TmProperty());
        }
        public TmSkillItem() { }
        public TmSkillItem(TmSkillDB itemDB)
        {
            if (this.GetComponent<TmSkillDB>() != null)
            {
                RemoveComponent<TmSkillDB>();
            }
            AddComponent(itemDB);
        }
    }
}
