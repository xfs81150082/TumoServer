﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Tumo
{
    [Serializable]
    public class TmSkillDB : TmComponent
    {  
        public TmSkillDB() { }
        public int Id { get; set; } = 151011;
        public string Name { get; set; } = "tumo";
        public int SkillId { get; set; } = 11101;
        public int RolerId { get; set; } = 100001;
        public int Exp { get; set; } = 0;
        public int Level { get; set; } = 10;
        public RoleType RoleType { get; set; } = RoleType.Engineer;
        public int Place { get; set; } = 0;
    }
}
