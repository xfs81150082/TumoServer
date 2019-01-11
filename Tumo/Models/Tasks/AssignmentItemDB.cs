using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Tumo.Models
{
    public class AssignmentItemDB
    {
        private int id;
        private int rolerid;
        private int assignmentid ;
        private AssignmentState assignmentstate;
        private string updateTime;

        public AssignmentItemDB() { }

        public int Id { get => id; set => id = value; }
        public int Rolerid { get => rolerid; set => rolerid = value; }
        public int AssignmentId { get => assignmentid; set => assignmentid = value; }
        public AssignmentState AssignmentState { get => assignmentstate; set => assignmentstate = value; }
        public string UpdateTime { get => updateTime; set => updateTime = value; }
    }
}
