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
                case (ElevenCode.Login):
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
            Console.WriteLine(TmTimerTool.CurrentTime() + " TmEngineerMysql,UserId:" + (parameter.Parameters[parameter.ElevenCode.ToString()] as TmUser).Id);
            //TmUser user = TmParameterTool.GetValue<TmUser>(parameter, parameter.ElevenCode.ToString());
            List<TmSoulerDB> dbs = GetTmSoulerdbsByUserId((parameter.Parameters[parameter.ElevenCode.ToString()] as TmUser).Id);
            if (dbs.Count > 0)
            {
                (sender as TmUserHandler).Engineers = dbs;
            }
            else
            {
                Console.WriteLine(TmTimerTool.CurrentTime() + " 没有角色");
            }
        }
    }
}