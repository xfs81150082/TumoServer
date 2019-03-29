using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using Tumo;
namespace ClientExample
{
    class SyncTest : TmSystem
    {        
        public override void TmAwake()
        {
            //GetGrids();
            //GetStartGoal();
        }
        public override void TmUpdate()
        {
            //ResTimeGet();
            //TestPaths();

            SyncGrid();
        }

        #region
        int time2 = 0;
        int resTime2 = 120;
        void SyncGrid()
        {
            time2 += 1;
            if (time2 > resTime2)
            {
                if (GetTms().Count > 0)
                {
                    TmStatus status = new TmStatus();
                    status.Paths = GetTms();
                    status.MyselfTmTransform = new TmTransform(10, 11, 12);
                    status.TargetTmTransform = new TmTransform(20, 21, 22);
                    Console.WriteLine("SyncTest-Send-status.Count33: " + status.Paths.Count);
                    TmParameter request = TmParameterTool.ToJsonParameter<TmStatus>(TenCode.StatusSync, ElevenCode.Roler, ElevenCode.Roler.ToString(), status);
                    TmTcpSocket.Instance.Send(request);
                    time2 = 0;
                }
            }
        }

        List<TmTransform> GetTms()
        {
            List<TmTransform> tms = new List<TmTransform>();
            tms.Add(new TmTransform(1, 2, 3));
            tms.Add(new TmTransform(3, 4, 5));
            tms.Add(new TmTransform(5, 6, 7));
            tms.Add(new TmTransform(7, 8, 9));
            return tms;
        }
        #endregion

        #region TestPaths
        Stopwatch TmTime = new Stopwatch();
        TmSoulerItem SoulerItem = new TmSoulerItem();
        ArrayList Paths { get; set; } = new ArrayList();
        bool iscan = true;
        void TestPaths()
        {           
            Paths = SoulerItem.GetComponent<TmAstarComponent>().paths;
            if (Paths != null && Paths.Count > 0 && iscan)
            {
                Console.WriteLine(Paths.Count);
                for (int i = 0; i < 5; i++) 
                {
                    TmGrid grid = (TmGrid)Paths[i];
                    Console.WriteLine("(x,z): " + grid.x + " , " + grid.z);
                }
                iscan = false;
            }            
        }
        #endregion

        #region Gets
        TmGrid[,] grids { get; set; }
        TmGrid start { get; set; }
        TmGrid goal { get; set; }
        int row = 100;
        int cilumn = 100;
        int time = 0;
        int resTime = 120;
        void ResTimeGet()
        {
            time += 1;
            if (time == resTime)
            {
                GetStartGoal2();
                SoulerItem.GetComponent<TmAstarComponent>().isCan = true;
                Console.WriteLine(TmTimerTool.CurrentTime() + " ServerTest53: " + SoulerItem.GetComponent<TmAstarComponent>().isCan);
            }

            if (time == resTime * 2)
            {
                GetStartGoal();
                SoulerItem.GetComponent<TmAstarComponent>().isCan = true;
                Console.WriteLine(TmTimerTool.CurrentTime() + " ServerTest59: " + SoulerItem.GetComponent<TmAstarComponent>().isCan);
                time = 0;
            }
        }
        void GetStartGoal()
        {
            start = new TmGrid();
            start.x = 30;
            start.z = 30;            
            goal = new TmGrid();
            goal.x = 60;
            goal.z = 20;
            UpdateStartGoal();
            iscan = true;
        }
        void GetStartGoal2()
        {
            start = new TmGrid();
            start.x = 20;
            start.z = 30;
            goal = new TmGrid();
            goal.x = 60;
            goal.z = 30;
            UpdateStartGoal();
            iscan = true;
        }
        void UpdateStartGoal()
        {
            SoulerItem.GetComponent<TmAstarComponent>().start = start;
            SoulerItem.GetComponent<TmAstarComponent>().goal = goal;
            SoulerItem.GetComponent<TmAstarComponent>().grids = grids;
            SoulerItem.GetComponent<TmSouler>().RoleType = RoleType.Booker;
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
        #endregion

    }
}