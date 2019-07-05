using System;
using System.Collections.Generic;
using Tumo;
namespace Tumo
{
    public class TmGridMap : TmComponent
    {
        public int Id { get; set; }
        public string senceName { get; set; }
        public double withSize { get; set; }
        public double lentgSize { get; set; }
        public double gridSize { get; set; }
        public int raw { get; set; }
        public int column { get; set; }
        public TmGrid[,] grids { get; set; }
        public List<TmGrid> gridList { get; set; }
        public List<TmObstacle> obstacles { get; set; }
    }
}
