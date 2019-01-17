using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Tumo.Models
{
    [Serializable]
    public class SkillItem : AttributeValue
    {
        public int Id { get => id; set => id = value; }
        public string Name { get => name2; set => name2 = value; }
        public SkillItemDB SkillItemDB
        {
            get
            {
                return skillItemDB;
            }
        }
        public Skill Skill
        {
            get
            {
                return skill;
            }

            set
            {
                skill = value;
            }
        }
        public int RolerId { get => rolerId; set => rolerId = value; }
        public int Level { get => level; set => level = value; }
        public RoleType RoleType
        {
            get
            {
                return roleType;
            }

            set
            {
                roleType = value;
            }
        }
        public SkillPlace SkillPlace
        {
            get
            {
                return skillPlace;
            }

            set
            {
                skillPlace = value;
            }
        }

        public SkillItem()
        {
            UpdateItem();
        }
        public SkillItem(Skill skill)
        {
            this.skill = skill;
            UpdateItem();
        }
        public SkillItem(SkillItemDB itemDB)
        {
            this.skillItemDB = itemDB;
            this.Id = itemDB.Id;
            this.Name = itemDB.Name;
            this.Level = itemDB.Level;
            this.roleType = itemDB.RoleType;
            this.skillPlace = itemDB.SkillPlace;
            UpdateItem();
        }
        public SkillItemDB CreatSkillItemDB()
        {
            skillItemDB.Id = Id;
            skillItemDB.Name = Name;
            skillItemDB.Level = Level;
            skillItemDB.SkillId = Skill.Id;
            skillItemDB.RoleType = RoleType;
            skillItemDB.SkillPlace = SkillPlace;
            return skillItemDB;
        }
        public void UpdateItem(int level)
        {
            this.Level = level;
            this.Bp = Skill.Bp * Level;
        }
        public void UpdateItem()
        {
            this.Bp = Skill.Bp * Level;
        }
        private int id = 100001;
        private string name2 = "tumo";
        private SkillItemDB skillItemDB;
        private Skill skill = new Skill();
        private int rolerId = 100001;
        private int level = 0;
        private RoleType roleType = RoleType.CostEngineer;
        private SkillPlace skillPlace = SkillPlace.Sky;
    }
}
