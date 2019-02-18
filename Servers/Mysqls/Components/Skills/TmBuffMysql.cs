using Tumo;
using Tumo.Models;
using MySql.Data.MySqlClient;
using Servers;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
namespace Servers
{
    class TmBuffMysql : TmSkilldbMysql
    {
        public override void TmAwake()
        {
            base.TmAwake();
            DatabaseFormName = "buffitem";
        }
        public override void OnTransferParameter(object sender, TmParameter parameter)
        {
            ElevenCode elevenCode = parameter.ElevenCode;
            switch (elevenCode)
            {
                case (ElevenCode.GetSkills):
                    Console.WriteLine(TmTimerTool.CurrentTime() + " TmBuffMysql: " + elevenCode);
                    GetDbsByRolerId(sender, parameter);
                    break;
                case (ElevenCode.Get):
                    Console.WriteLine(TmTimerTool.CurrentTime() + " TmBuffMysql: " + elevenCode);
                    GetSkill(sender, parameter);
                    break;
                case (ElevenCode.None):
                    break;
                default:
                    break;
            }
        }
        void GetSkill(object sender, TmParameter parameter)
        {
            Dictionary<int, TmSkill> skills = GetSkills();
            Console.WriteLine(TmTimerTool.CurrentTime() + " skills:" + skills.Count);
            if (skills!=null)
            {
                (sender as TmBuffHandler).Skills = skills;
            }
            else
            {
                Console.WriteLine(TmTimerTool.CurrentTime() + " 没有角色");
            }
        }
        void GetDbsByRolerId(object sender, TmParameter parameter)
        {
            int rolerid = TmParameterTool.GetJsonValue<int>(parameter, ElevenCode.EngineerLogin.ToString());
            Dictionary<int, TmSkillDB> dbs = GetSkilldbsByRolerId(rolerid);
            Console.WriteLine(TmTimerTool.CurrentTime() + " dbs:" + dbs.Count);
            if (dbs.Count > 0)
            {
                (sender as TmBuffHandler).Buffs.Add(rolerid, dbs);
            }
            else
            {
                Console.WriteLine(TmTimerTool.CurrentTime() + " 没有角色");
            }
        }

    }
}
