using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Tumo.Models
{
    public class AssignmentItem
    {

        public AssignmentItemDB AssignmentItemDB { get => assignmentItemDB; set => assignmentItemDB = value; }
        public int Id { get => id; set => id = value; }
        public int Rolerid { get => rolerid; set => rolerid = value; }
        public Assignment Assignment{ get => assignment; set => assignment = value; }
        public AssignmentState AssignmentState { get => assignmentState; set => assignmentState = value; }
        public string UpdateTime { get => updateTime; set => updateTime = value; }

        public AssignmentItem() { }
        public AssignmentItem(Assignment ass)
        {
            this.assignment = ass;
        }
        public AssignmentItem(AssignmentItemDB itemDB)
        {
            this.assignmentItemDB = itemDB;
            this.id = itemDB.Id;
            this.rolerid = itemDB.Rolerid;
            this.assignmentState = itemDB.AssignmentState;
        }
        public AssignmentItemDB CreatAssignmentItemDB()
        {
            this.assignmentItemDB.Id = Id;
            this.assignmentItemDB.Rolerid = Rolerid;
            this.assignmentItemDB.AssignmentId = Assignment.Id;
            this.assignmentItemDB.AssignmentState = AssignmentState;
            this.assignmentItemDB.UpdateTime = UpdateTime;
            return this.assignmentItemDB;
        }

        private AssignmentItemDB assignmentItemDB = new AssignmentItemDB();
        private int id;
        private int rolerid;
        private Assignment assignment = new Assignment();
        private AssignmentState assignmentState;
        private string updateTime;
    }
}
