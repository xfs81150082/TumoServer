using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TumoTest.PathFinding
{
    class Map
    {
        /// <summary>
        /// 字段：地图长
        /// </summary>
        internal int LenX;
        /// <summary>
        /// 字段：地图宽
        /// </summary>
        internal int LenY;
        /// <summary>
        /// 字段：用网格节点描述的地图
        /// </summary>
        internal Grid[,] simplemap;
        /// <summary>
        /// 构造方法：初始化地图
        /// </summary>
        ///<param name="x">地图长
        ///<param name="y">地图宽
        public Map(int x, int y)
        {
            LenX = x;
            LenY = y;
            simplemap = new Grid[LenY, LenX];
            for (int i = 0; i < LenY; i++)
                for (int j = 0; j < LenX; j++)
                {
                    simplemap[i, j] = new Grid() { X = j, Y = i };
                }
        }
        private Grid startGrid;
        /// <summary>
        /// 属性：地图起点
        /// </summary>
        internal Grid StartGrid
        {
            get { return startGrid; }
            set
            {
                if (value.LandAttribute != 0)
                {
                    startGrid = value;
                    startGrid.GCostAttribute = 0;
                    startGrid.fatherGrid = null;
                    startGrid.PathAttribute = true;
                    simplemap[startGrid.Y, startGrid.X] = startGrid;
                }
                else startGrid = null;
            }
        }
        private Grid endGrid;
        /// <summary>
        /// 属性：地图终点
        /// </summary>
        internal Grid EndGrid
        {
            get { return endGrid; }
            set
            {
                endGrid = value;
                endGrid.PathAttribute = true;
                simplemap[endGrid.Y, endGrid.X] = endGrid;
            }
        }
        /// <summary>
        /// 方法：对所有网格的地形属性进行初始化设置从而生成一张地图
        /// </summary>
        ///<param name="grid">当前节点
        ///<param name="landform">地形选项
        internal void MapGridSet(Grid grid, byte landform)
        {
            if (landform > landtypes) return;
            else grid.LandAttribute = landform;
        }
        /// <summary>
        /// 字段：地形总数
        /// </summary>
        private int landtypes = Enum.GetValues(typeof(LandFormEnum)).Length - 1;


    }
}
