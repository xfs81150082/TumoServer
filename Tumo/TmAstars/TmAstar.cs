using System;
using System.Collections;
namespace Tumo
{
    public static class TmAstar
    {
        private static TmPriorityQueue closedList, openList;
        public static ArrayList FindPath(TmGrid start, TmGrid goal, TmGrid[,] grids)
        {
            openList = new TmPriorityQueue();
            closedList = new TmPriorityQueue();
            openList.Add(start);
            start.G = 0.0;
            start.H = Math.Abs(goal.x - start.x) + Math.Abs(goal.z - start.z);
            start.F = start.G + start.H;
            TmGrid grid = null;
            while (openList.Length != 0)
            {
                grid = openList.First();
                if (grid.x == goal.x && grid.z == goal.z)
                {
                    return CalculatePath(grid);
                }
                ArrayList neighbours = GetNeighbours(grid, grids);
                for(int i = 0; i < neighbours.Count; i++)
                {
                    TmGrid neighGrid = (TmGrid)neighbours[i];
                    if (!closedList.Contains(neighGrid))
                    {
                        double costG = GetCostG(neighGrid, grid);
                        double costH = Math.Abs(goal.x - neighGrid.x) + Math.Abs(goal.z - neighGrid.z);
                        neighGrid.G = grid.G + costG;
                        neighGrid.H = costH;
                        neighGrid.F = neighGrid.G + neighGrid.H;
                        neighGrid.parent = grid;
                        if (!openList.Contains(neighGrid))
                        {
                            openList.Add(neighGrid);
                        }
                    }
                }
                closedList.Add(grid);
                openList.Remove(grid);
            }
            if (grid.x != goal.x && grid.z != goal.z)
            {
                Console.WriteLine("Goal Not Find.");
                return null;
            }
            return CalculatePath(grid);
        }
        private static ArrayList CalculatePath(TmGrid goal)
        {
            ArrayList list = new ArrayList();
            while (goal != null)
            {
                list.Add(goal);
                goal = goal.parent;
            }
            list.Reverse();
            return list;
        }
        private static double GetCostG(TmGrid myself, TmGrid neighour)
        {
            double cost = 1.0;
            if (myself.x != neighour.x && myself.z != neighour.z)
            {
                cost = 1.4;
            }
            return cost;
        }
        private static double GetCostH(TmGrid myself, TmGrid goal)
        {
            double cost = 0.0;
            double xx = Math.Abs(goal.x - myself.x);
            double yy = Math.Abs(goal.z - myself.z);
            double sqlxx = Math.Pow(xx, 2);
            double sqlyy = Math.Pow(yy, 2);
            cost = Math.Pow((sqlxx + sqlyy), 0.5);
            return cost;
        }
        private static ArrayList GetNeighbours(TmGrid grid, TmGrid[,] grids)
        {
            ArrayList list = new ArrayList();
            int row = grid.z;
            int column = grid.x;
            AssignNeighbour(row - 1, column - 1, list, grids);    //左上
            AssignNeighbour(row - 1, column, list, grids);        //左上
            AssignNeighbour(row - 1, column + 1, list, grids);    //左上
            AssignNeighbour(row, column - 1, list, grids);        //左上
            AssignNeighbour(row, column + 1, list, grids);        //左上
            AssignNeighbour(row + 1, column - 1, list, grids);    //左上
            AssignNeighbour(row + 1, column, list, grids);        //左上
            AssignNeighbour(row + 1, column + 1, list, grids);    //左上
            return list;
        }
        private static void AssignNeighbour(int row, int column, ArrayList neighbours , TmGrid[,] grids)
        {
            if (row > -1 && column > -1 && row < grids.GetLength(0) && column < grids.GetLength(1))
            {
                TmGrid grid = grids[row, column];
                if (!grid.bObstacle)
                {
                    neighbours.Add(grid);
                }
            }
        }  
        
    }
}