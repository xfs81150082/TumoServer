using Tumo;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
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
        private void GetSoulerDBs()
        {
            Dictionary<int, TmSoulerDB> dbdict = GetTmSoulerdbDict();
            if (dbdict.Count > 0)
            {
                TmObjects.Teachers = dbdict;
            Console.WriteLine(TmTimerTool.CurrentTime() + " TmObjects.Teachers: " + TmObjects.Teachers.Count);
            }
            else
            {
                Console.WriteLine(TmTimerTool.CurrentTime() + " 没有角色");
            }
        }

        //public override void OnTransferParameter(object sender, TmParameter parameter)
        //{
        //    ElevenCode elevenCode = parameter.ElevenCode;
        //    switch (elevenCode)
        //    {
        //        case (ElevenCode.GetRolers):
        //            //this.GetSoulerdbs(sender, parameter);
        //            break;
        //        case (ElevenCode.None):
        //            break;
        //        default:
        //            break;
        //    }
        //}
      
        //private void GetSoulerdbs(object sender, TmParameter parameter)
        //{
        //    List<TmSoulerDB> dbs = GetTmSoulerdbs();
        //    Console.WriteLine(TmTimerTool.CurrentTime() + " dbs:" + dbs.Count);
        //    if (dbs.Count > 0)
        //    {
        //        (sender as TmTeacherHandler).Teachers = dbs;
        //    }
        //    else
        //    {
        //        Console.WriteLine(TmTimerTool.CurrentTime() + " 没有角色");
        //    }
        //}
    }
}