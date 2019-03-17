using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
namespace Tumo
{
    public class TmPriorityQueue
    {
        private ArrayList grids = new ArrayList();
        public int Length
        {
            get { return this.grids.Count; }
        }
        public bool Contains(object grid)
        {
            return this.grids.Contains(grid);
        }
        public TmGrid First()
        {
            if (this.grids.Count > 0)
            {
                return (TmGrid)this.grids[0];
            }
            return null;
        }
        public void Add(TmGrid grid)
        {
            this.grids.Add(grid);
            this.grids.Sort();
        }
        public void Remove(TmGrid grid)
        {
            this.grids.Remove(grid);
            this.grids.Sort();
        }

    }
}
