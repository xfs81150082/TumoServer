using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using Tumo;
namespace Servers
{
    class TmEngineerMysql : TmSoulerdbMysql
    {
        public override void TmAwake()
        {
            base.TmAwake();
            DatabaseFormName = "engineeritem";
        }
        public override void OnTransferParameter(object sender, TmParameter parameter)
        {
            ElevenCode elevenCode = parameter.ElevenCode;
            switch (elevenCode)
            {
                case (ElevenCode.Get):
                    Console.WriteLine(TmTimerTool.CurrentTime() + " TmEngineerMysql: " + elevenCode);
                    GetSouler(sender, parameter);
                    break;
                case (ElevenCode.GetRolers):
                    Console.WriteLine(TmTimerTool.CurrentTime() + " TmEngineerMysql: " + elevenCode);
                    GetRolersByUersId(sender, parameter);
                    break;
                case (ElevenCode.EngineerLogin):
                    Console.WriteLine(TmTimerTool.CurrentTime() + " TmEngineerMysql: " + elevenCode);
                    GetdbofEngineerLogin(sender, parameter);
                    break;
                case (ElevenCode.None):
                    break;
                default:
                    break;
            }
        }
        void GetRolersByUersId(object sender, TmParameter parameter)
        {
            int userId = TmParameterTool.GetValue<int>(parameter, ElevenCode.UserLogin.ToString());
            Console.WriteLine(TmTimerTool.CurrentTime() + " TmEngineerMysql,userId:" + userId);
            List<TmSoulerDB> dbs = GetTmSoulerdbsByUserId(userId);
            Console.WriteLine(TmTimerTool.CurrentTime() + " dbs:" + dbs.Count);
            if (dbs.Count > 0)
            {
                //(sender as TmEngineerHandler).Engineers = dbs;
                (sender as TmEngineerHandler).EngineerDbs.Add(userId, dbs);
            }
            else
            {
                Console.WriteLine(TmTimerTool.CurrentTime() + " 没有角色");
            }
        }
        void GetdbofEngineerLogin(object sender, TmParameter parameter)
        {
            int rolerId = TmParameterTool.GetJsonValue<int>(parameter, ElevenCode.EngineerLogin.ToString());
            Console.WriteLine(TmTimerTool.CurrentTime() + " TmEngineerMysql,rolerId:" + rolerId);
            TmSoulerDB db = GetTmSoulerdbById(rolerId);
            Console.WriteLine(TmTimerTool.CurrentTime() + " db:" + db.Name);
            if (db != null)
            {
                //(sender as TmEngineerHandler).Engineer = db;
                (sender as TmEngineerHandler).Engineers.Add(rolerId, db);
            }
            else
            {
                Console.WriteLine(TmTimerTool.CurrentTime() + " 没有角色");
            }
        }
        void GetSouler(object sender, TmParameter parameter)
        {
            Dictionary<int, TmSouler> soulers = GetTmSoulers();
            Console.WriteLine(TmTimerTool.CurrentTime() + " soulers:" + soulers.Count);
            if (soulers.Count > 0)
            {
                (sender as TmEngineerHandler).Soulers = soulers;
            }
            else
            {
                Console.WriteLine(TmTimerTool.CurrentTime() + " 没有角色");
            }
        }

    }
}