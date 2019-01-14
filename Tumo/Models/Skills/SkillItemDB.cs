using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Tumo.Models
{
    [Serializable]
    public class SkillItemDB
    {
        public int Id { get => id; set => id = value; }
        public string Name { get => name2; set => name2 = value; }
        public int SkillId { get => skillId; set => skillId = value; }
        public int RolerId { get => rolerId; set => rolerId = value; }
        public int Level { get => level; set => level = value; }
        public RoleType RoleType { get => roleType; set => roleType = value; }
        public SkillPlace SkillPlace { get => skillPlace; set => skillPlace = value; }

        public SkillItemDB() { }
        private int id = 151011;
        private string name2 = "tumo";
        private int skillId = 11101;
        private int rolerId = 100001;
        private int level = 10;
        private RoleType roleType = RoleType.CostEngineer;
        private SkillPlace skillPlace = SkillPlace.Sky;
    }
}
