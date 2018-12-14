using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TumoTest.PathFinding
{
    class InitFinding
    {
        public InitFinding()
        {
            //初始化地图
            Map mapSample = new Map(20, 20);
            Grid sg = new Grid() { X = 0, Y = 4 };
            mapSample.StartGrid = sg;
            Grid eg = new Grid() { X = 9, Y = 5 };
            mapSample.EndGrid = eg;
            //设置障碍          
            for (int i = 2; i < 8; i++) mapSample.MapGridSet(mapSample.simplemap[i, 5], 0);
            mapSample.MapGridSet(mapSample.simplemap[2, 4], 0);
            mapSample.MapGridSet(mapSample.simplemap[7, 4], 0);
            //寻路
            Paths astarPath = new Paths();
            astarPath.Find(mapSample.StartGrid, mapSample.EndGrid, mapSample);
            //打印地图和路径
            foreach (Grid g in mapSample.simplemap)
            {
                if (g.X == mapSample.LenY - 1)
                    Console.WriteLine(Grid.Print(g));
                else
                    Console.Write(Grid.Print(g));
            }

        }

    }
}
