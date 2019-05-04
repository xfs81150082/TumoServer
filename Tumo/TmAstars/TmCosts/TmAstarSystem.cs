using System;
namespace Tumo
{
    class TmAstarSystem : TmSystem
    {
        public override void BeginInit()
        {
            ValTime = 400;
        }
        public override void TmAwake()
        {
            AddComponent(new TmAstarComponent());
            AddComponent(new TmSouler());
        }
        public override void TmUpdate()
        {
            foreach (TmEntity tem in GetTmEntities())
            {
                FindPaths(tem);
            }
        }
        TmAstar Astar { get; set; } = new TmAstar();
        void FindPaths(TmEntity entity)
        {
            TmAstarComponent path = entity.GetComponent<TmAstarComponent>();
            if (!path.isCan) return;
            if (entity.GetComponent<TmSouler>().RoleType == RoleType.Engineer || path.IsKey) return;
            if (path.start != null && path.goal != null && path.grids != null && path.grids.Length > 0)
            {               
                path.paths = Astar.FindPath(path.start, path.goal, path.grids);
                path.start = null;

                path.lastGoal = new TmGrid(path.goal);
                path.isPath = true;
            }
        }

    }
}