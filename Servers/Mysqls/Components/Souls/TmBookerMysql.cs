using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Tumo;
namespace Servers
{
    class TmBookerMysql : TmSoulerdbMysql
    {
        public override void TmAwake()
        {
            DatabaseFormName = "bookeritem";
        }       
        public TmBookerMysql()
        {
            GetSoulerDBs();
        }
        bool isYes = false;
        private void GetSoulerDBs()
        {
            List<TmSoulerDB> dbs = GetTmSoulerDBs();
            if (dbs.Count > 0 && !isYes)
            {
                TmObjects.Bookers = dbs;
                isYes = true;
                Console.WriteLine(TmTimerTool.CurrentTime() + " TmBookerMysql-Bookers: " + TmObjects.Bookers.Count);
            }
            else
            {
                Console.WriteLine(TmTimerTool.CurrentTime() + " 没有角色");
            }
        }
             
    }
}