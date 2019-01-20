using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Tumo.Models
{
    public class TmTask
    {
        private int id;
        private string name2;
        private string iocn;
        private int levelUpLimit = 5;                         //等级上级 
        private AssignmentType assignmentType;
        private int cion;
        private string does;
        private int teacherId = 161013;

        public TmTask()
        {

        }

        public int Id { get => id; set => id = value; }
        public string Name { get => name2; set => name2 = value; }
        public string Iocn { get => iocn; set => iocn = value; }
        public int LevelUpLimit { get => levelUpLimit; set => levelUpLimit = value; }
        public AssignmentType AssignmentType { get => assignmentType; set => assignmentType = value; }
        public int Cion { get => cion; set => cion = value; }
        public string Does { get => does; set => does = value; }
        public int TeacherId { get => teacherId; set => teacherId = value; }
    }
}
