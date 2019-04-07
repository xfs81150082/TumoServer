using Tumo;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Collections;

namespace Servers
{
    class TmTeacherMysql : TmSoulerdbMysql
    {
        public override void TmAwake()
        {
            DatabaseFormName = "teacheritem";
        }

        public TmTeacherMysql()
        {
            GetSoulerDBs();
        }
        bool isYes = false;
        private void GetSoulerDBs()
        {
            Dictionary<int, TmSoulerDB> dbs = GetTmSoulerDBsDict();
            if (dbs.Count > 0 && !isYes)
            {
                TmObjects.Teachers = dbs;
                isYes = true;
                Console.WriteLine(TmTimerTool.CurrentTime() + " TmTeacherMysql-Teachers: " + TmObjects.Teachers.Count);
            }
            else
            {
                Console.WriteLine(TmTimerTool.CurrentTime() + " 没有角色");
            }
        }

     

    }
}