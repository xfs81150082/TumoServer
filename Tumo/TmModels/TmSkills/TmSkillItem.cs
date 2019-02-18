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
            (this.GetComponent<TmName>() as TmName).Name = (this.GetComponent<TmSkillDB>() as TmSkillDB).Name;
            (this.GetComponent<TmName>() as TmName).Id = (this.GetComponent<TmSkillDB>() as TmSkillDB).Id;
            (this.GetComponent<TmName>() as TmName).ParentId = (this.GetComponent<TmSkillDB>() as TmSkillDB).RolerId;
            (this.GetComponent<TmChangeType>() as TmChangeType).Exp = (this.GetComponent<TmSkillDB>() as TmSkillDB).Exp;
            (this.GetComponent<TmChangeType>() as TmChangeType).Level = (this.GetComponent<TmSkillDB>() as TmSkillDB).Level;
        }
    }
}
