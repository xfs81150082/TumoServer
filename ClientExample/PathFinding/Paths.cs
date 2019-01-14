using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClientExample.PathFinding
{
    class Paths
    {
        List<Grid> openList = new List<Grid>();
        List<Grid> closeList = new List<Grid>();
        /// <summary>
        /// 方法：判断当前节点是否在指定列表中，是则返回true
        /// </summary>
        ///<param name="x">坐标x
        ///<param name="y">坐标y
        ///<param name="list">列表
        /// <returns>Bool：在指定列表中则返回true</returns>
        protected bool IsInList(int x, int y, List<Grid> list)
        {
            foreach (Grid g in list)
            {
                if (g.X == x && g.Y == y) return true;
            }
            return false;
        }
        /// <summary>
        /// 方法：从指定列表里获取指定节点
        /// </summary>
        ///<param name="grid">节点
        ///<param name="list">列表
        /// <returns>Grid：返回指定节点</returns>
        protected Grid GetGridFromList(Grid grid, List<Grid> list)
        {
            foreach (Grid g in list)
            {
                if (g.X == grid.X && g.Y == grid.Y) return g;
            }
            return null;
        }
        /// <summary>
        /// 方法：计算G耗费
        /// </summary>
        ///<param name="x">坐标x
        ///<param name="y">坐标y
        ///<param name="sg">起点
        /// <returns>Int：G值</returns>
        protected int GetGridCostG(int x, int y, Grid sg)
        {
            if (sg.fatherGrid != null)
                return (sg.X == x || sg.Y == y) ? sg.fatherGrid.GCostAttribute + 10 : sg.fatherGrid.GCostAttribute + 14;
            else return 0;
        }
        /// <summary>
        /// 方法：计算H耗费
        /// </summary>
        ///<param name="x">坐标x
        ///<param name="y">坐标y
        ///<param name="eg">终点
        /// <returns>Int：H值</returns>
        protected int GetGridCostH(int x, int y, Grid eg)
        {
            return Math.Abs(x - eg.X) + Math.Abs(y - eg.Y);
        }
        /// <summary>
        /// 方法：从指定列表中获取F值最小的节点
        /// </summary>
        ///<param name="list">列表
        /// <returns>Grid：F值最小的节点</returns>
        protected Grid GetMinFFromList(List<Grid> list)
        {
            if (list.Count == 0) return null;
            int tmpF = list[0].GCostAttribute + list[0].HCostAttribute;
            foreach (Grid g in list)
            {
                if (g.GCostAttribute + g.HCostAttribute < tmpF)
                    return g;
            }
            return list[0];
        }
        /// <summary>
        /// 方法：检查当前节点周边的节点
        /// </summary>
        ///<param name="sg">当前节点
        ///<param name="eg">终点
        ///<param name="map">Map类的实例
        protected void CheckAround(Grid sg, Grid eg, Map map)
        {
            int gridmapRow = map.LenY;//获取地图的行数
            int gridmapCol = map.LenX;//获取地图的列数
            Grid[,] gridmap = map.simplemap;
            for (int i = sg.X - 1; i < sg.X + 2; i++)
                for (int j = sg.Y - 1; j < sg.Y + 2; j++)
                {
                    if (i < 0 || i > gridmapCol - 1 || j < 0 || j > gridmapRow - 1) continue;
                    if (gridmap[j, i].LandAttribute == 0 || IsInList(i, j, closeList) || (i == sg.X && j == sg.Y)) continue;
                    gridmap[j, i].HCostAttribute = GetGridCostH(i, j, eg);
                    if (!IsInList(i, j, openList))
                    {
                        gridmap[j, i].fatherGrid = sg;
                        gridmap[j, i].GCostAttribute = GetGridCostG(i, j, sg);
                        openList.Add(gridmap[j, i]);
                    }
                    else if (gridmap[j, i].GCostAttribute > GetGridCostG(i, j, sg))
                    {
                        gridmap[j, i].GCostAttribute = GetGridCostG(i, j, sg);
                        gridmap[j, i].fatherGrid = sg;
                    }
                }
        }
        /// <summary>
        /// 方法：寻路算法
        /// </summary>
        ///<param name="sg">起点
        ///<param name="eg">终点
        ///<param name="map">Map类的实例
        internal void Find(Grid sg, Grid eg, Map map)
        {
            openList.Add(sg);
            while (!IsInList(eg.X, eg.Y, openList) || openList.Count == 0)
            {
                Grid g = GetMinFFromList(openList);
                if (g != null)
                {
                    openList.Remove(g);
                    closeList.Add(g);
                    CheckAround(g, eg, map);
                }
                else return;
            }
            Grid tmpg = GetGridFromList(eg, openList);
            Save(tmpg);
        }
        /// <summary>
        /// 方法：保存路径
        /// </summary>
        ///<param name="g">节点
        internal void Save(Grid g)
        {
            while (g.fatherGrid != null)
            {
                g.PathAttribute = true;
                g = g.fatherGrid;
            }
        }

    }
}
