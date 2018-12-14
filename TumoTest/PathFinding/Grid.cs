using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TumoTest.PathFinding
{
    class Grid
    {
        private int x;
        internal int X
        {
            get { return x; }
            set { x = value; }
        }
        private int y;
        internal int Y
        {
            get { return y; }
            set { y = value; }
        }

        private byte landAttribute = 1;
        /// <summary>
        /// 属性：描述地形,默认为平地，0表示该节点为障碍（不可通行）
        /// </summary>
        internal byte LandAttribute
        {
            get { return landAttribute; }
            set { landAttribute = value; }
        }

        private bool pathAttribute = false;
        /// <summary>
        /// 属性：是否为路径节点，是为true，默认为false
        /// </summary>
        internal bool PathAttribute
        {
            get { return pathAttribute; }
            set { pathAttribute = value; }
        }

        private int gCostAttribute;
        /// <summary>
        /// 属性：当前网格距离起点的移动耗费
        /// </summary>
        internal int GCostAttribute
        {
            get { return gCostAttribute; }
            set { gCostAttribute = value; }
        }

        private int hCostAttribute;
        /// <summary>
        /// 属性：当前网格距离终点的移动耗费
        /// </summary>
        internal int HCostAttribute
        {
            get { return hCostAttribute; }
            set { hCostAttribute = value; }
        }
        /// <summary>
        /// 字段：当前网格的父节点
        /// </summary>
        internal Grid fatherGrid;

        /// <summary>
        /// 方法：获得地形的符号表达
        /// </summary>
        ///<param name="g">当前节点
        /// <returns>String：地形的符号表达</returns>
        internal static string Print(Grid g)
        {
            if (g.PathAttribute) return "☆";
            else
            {
                switch (g.LandAttribute)
                {
                    case 0: return "■";
                    case 1: return "□";
                    case 2: return "▲";
                    default: return "○";
                }
            }
        }
    }

    /// <summary>
    /// 枚举：地形的集合
    /// </summary>
    enum LandFormEnum
    {
        Block = 0,
        Flatground = 1,
        Mountain = 2
    }


}
