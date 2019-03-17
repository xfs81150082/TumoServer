using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tumo;
namespace Servers
{
    class ServerTest : TmSystem
    {
        public ServerTest()
        {
            //GetStartGoal();
            //GetGrids();

            ////TestPriorityQueue();
            //TestPaths();
        }

      
        TmPriorityQueue queue { get; set; }
        void TestPriorityQueue()
        {
            queue = new TmPriorityQueue();
            start.G = 10;
            start.H = 10;
            start.F = start.G + start.H;
            queue.Add(start);


            goal.G = 10;
            goal.H = 11;
            goal.F = goal.G + goal.H;
            queue.Add(goal);

            Console.WriteLine("queue.First().F : " + queue.First().F);

        }


        void TestPaths()
        {
            if (grids != null && grids.Length > 0)
            {
                if (start != null && goal != null)
                {
                    FindPath(start, goal, grids);
                }
            }

            if (Paths != null && Paths.Count > 0)
            {
                Console.WriteLine(Paths.Count);
                foreach (TmGrid grid in Paths)
                {
                    Console.WriteLine("(x,z): " + grid.x + " , " + grid.z);
                }
            }
        }
        ArrayList Paths { get; set; }
        void FindPath(TmGrid start,TmGrid goal,TmGrid[,] grids)
        {
            Paths = TmAstar.FindPath(start, goal, grids);
        }
        TmGrid[,] grids { get; set; }
        TmGrid start { get; set; }
        TmGrid goal { get; set; }
        int row = 100;
        int cilumn = 100;
        void GetStartGoal()
        {
            start = new TmGrid();
            start.x = 30;
            start.z = 30;            
            goal = new TmGrid();
            goal.x = 60;
            goal.z = 20;
        }
        void GetGrids()
        {
            grids = new TmGrid[100,100];
            for(int i = 0; i < grids.GetLength(0); i++)
            {
                for (int j = 0; j < grids.GetLength(1); j++)
                {
                    grids[i, j] = new TmGrid();
                    grids[i, j].x = j;
                    grids[i, j].z = i;
                    if (j == 40 && i < 50 && i > 10)
                    {
                        grids[i, j].bObstacle = true;
                    }
                }
            }
        }
    }
}