using Tumo;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
namespace Servers
{
    class TmInbornMysql : TmSkilldbMysql
    {
        public override void TmAwake()
        {
            base.TmAwake();
            DatabaseFormName = "inbornitem";
        }
        public override void OnTransferParameter(object sender, TmParameter parameter)
        {
            ElevenCode elevenCode = parameter.ElevenCode;
            switch (elevenCode)
            {
                case (ElevenCode.Login):
                    Console.WriteLine(TmTimerTool.CurrentTime() + " TmInbornMysql: " + elevenCode);
                    GetDbsByRolerId(sender, parameter);
                    break;
                case (ElevenCode.None):
                    break;
                default:
                    break;
            }
        }
        void GetDbsByRolerId(object sender, TmParameter parameter)
        {
            Console.WriteLine(TmTimerTool.CurrentTime() + " TmInbornMysql,Rolerid:" + (parameter.Parameters[parameter.ElevenCode.ToString()] as TmUser).Id);
            List<TmSkillDB> dbs = GetSkilldbsByRolerId((parameter.Parameters[parameter.ElevenCode.ToString()] as TmUser).Id);
            if (dbs.Count > 0)
            {
                (sender as TmEngineerHandler).Abilitis = dbs;
            }
            else
            {
                Console.WriteLine(TmTimerTool.CurrentTime() + " 没有角色");
            }
        }



    }
}
