using System;
namespace Tumo
{
    public enum GridType
    {
        Obstacle,
        Sky,
        Building,
    }
    public class TmGrid : IComparable
    {
        public int x { get; set; }
        public int z { get; set; }
        public double G { get; set; } ///G表示当前节点到起点移动的耗费
        public double H { get; set; } ///H表示当前节点到终点可能的移动耗费
        public double F { get; set; } ///F是两者之，F值越小
        public GridType type { get; set; } = GridType.Sky;
        public bool bObstacle = false;
        public TmGrid parent { get; set; }
        public TmGrid()
        {
            this.G = 0.0;
            this.H = 1.0;
            this.F = this.G + this.H;
            this.type = GridType.Sky;
            this.bObstacle = false;
            this.parent = null;
        }
        public TmGrid(TmGrid grid)
        {
            this.x = grid.x;
            this.z = grid.z;
            this.G = grid.G;
            this.H = grid.H;
            this.F = grid.F;
            this.type = grid.type;
            this.bObstacle = grid.bObstacle;
            this.parent = grid.parent;
        }
        public TmGrid(int x,int z)
        {
            this.x = x;
            this.z = z;
            this.G = 0.0;
            this.H = 1.0;
            this.F = this.G + this.H;
        }
        public void MarkAsObstacle()
        {
            this.bObstacle = true;
            this.type = GridType.Obstacle;
        }
        public int CompareTo(object obj)
        {
            TmGrid grid = (TmGrid)obj;
            if (this.F < grid.F)
            {
                return -1;
            }
            if (this.F > grid.F)
            {
                return 1;
            }
            return 0;
        }

    }
}