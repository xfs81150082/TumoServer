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
            base.TmAwake();
            TmSoulerdbName = "teacheritem";
        }
    }
}