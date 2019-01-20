using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Tumo.Models
{
    public class TmTaskItem : TmEntity
    {
        public override void TmAwake()
        {
            base.TmAwake();
            AddComponent(new TmName());
            AddComponent(new TmTask());
            AddComponent(new TmTaskItemDB());
        }
        public TmTaskItemDB TmTaskItemDB { get; set; }
        public int Id { get; set; }
        public int Rolerid { get; set; }
        public TmTask TmTask { get; set; }
        public TaskState TaskState { get; set; }
        public string UpdateTime { get; set; }      
    }
}
