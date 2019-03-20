using System.Collections;
namespace Tumo
{
    public class TmAstarPath : TmComponent
    {
        public TmGrid start { get; set; }
        public TmGrid goal { get; set; }
        public TmGrid lastGoal { get; set; }
        public TmGrid[,] grids { get; set; }
        public ArrayList paths { get; set; }
        public int time = 1;
        public bool isCan { get; set; } = true;
        public bool isPath { get; set; } = false;
        public bool IsKey { get; set; } = false;
    }
}
