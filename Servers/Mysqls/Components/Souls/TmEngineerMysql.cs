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
                case (ElevenCode.UserLogin):
                    Console.WriteLine(TmTimerTool.CurrentTime() + " TmEngineerMysql: " + elevenCode);
                    GetDbsByEngineerLogin(sender, parameter);
                    break;
                case (ElevenCode.None):
                    break;
                default:
                    break;
            }
        }
        void GetDbsByEngineerLogin(object sender, TmParameter parameter)
        {
            int rolerId = TmParameterTool.GetValue<int>(parameter, parameter.ElevenCode.ToString());
            Console.WriteLine(TmTimerTool.CurrentTime() + " TmEngineerMysql,rolerId:" + rolerId);
            List<TmSoulerDB> dbs = GetTmSoulerdbsByUserId(rolerId);
            Console.WriteLine(TmTimerTool.CurrentTime() + " dbs:" + dbs.Count);
            if (dbs.Count > 0)
            {
                (sender as TmEngineerHandler).Engineers = dbs;
            }
            else
            {
                Console.WriteLine(TmTimerTool.CurrentTime() + " 没有角色");
            }
        }
    }
}