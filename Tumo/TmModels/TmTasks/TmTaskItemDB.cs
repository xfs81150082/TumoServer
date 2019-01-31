using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Tumo.Models
{
    public class TmTaskItemDB : TmComponent
    {
        public int Id { get; set; }
        public int RolerId { get; set; }
        public int TmTaskId { get; set; }
        public TaskState TaskState { get; set; }
        public string UpdateTime { get; set; }
    }
}
