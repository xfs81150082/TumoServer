using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Tumo.Models
{
    [Serializable]
    public class Soul : Attribute
    {
        public RoleType RoleType { get => roleType; set => roleType = value; }
        public Grade Grade { get => grade; set => grade = value; }
        public Profession Profession { get => profession; set => profession = value; }

        public Soul() { }
        private RoleType roleType = RoleType.CostEngineer;     //种族和职业
        private Grade grade = Grade.Standard;
        private Profession profession = Profession.Stamina;    //怪的类型，血，坦，DPS
    }
}
