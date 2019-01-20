using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Tumo.Models
{
    public class TmTaskItem
    {

        public TmTaskItemDB AssignmentItemDB { get => assignmentItemDB; set => assignmentItemDB = value; }
        public int Id { get => id; set => id = value; }
        public int Rolerid { get => rolerid; set => rolerid = value; }
        public TmTask Assignment { get => assignment; set => assignment = value; }
        public AssignmentState AssignmentState { get => assignmentState; set => assignmentState = value; }
        public string UpdateTime { get => updateTime; set => updateTime = value; }

        public TmTaskItem() { }
        public TmTaskItem(TmTask ass)
        {
            this.assignment = ass;
        }
        public TmTaskItem(TmTaskItemDB itemDB)
        {
            this.assignmentItemDB = itemDB;
            this.id = itemDB.Id;
            this.rolerid = itemDB.Rolerid;
            this.assignmentState = itemDB.AssignmentState;
        }
        public TmTaskItemDB CreatAssignmentItemDB()
        {
            this.assignmentItemDB.Id = Id;
            this.assignmentItemDB.Rolerid = Rolerid;
            this.assignmentItemDB.AssignmentId = Assignment.Id;
            this.assignmentItemDB.AssignmentState = AssignmentState;
            this.assignmentItemDB.UpdateTime = UpdateTime;
            return this.assignmentItemDB;
        }

        private TmTaskItemDB assignmentItemDB = new TmTaskItemDB();
        private int id;
        private int rolerid;
        private TmTask assignment = new TmTask();
        private AssignmentState assignmentState;
        private string updateTime;
    }
}
