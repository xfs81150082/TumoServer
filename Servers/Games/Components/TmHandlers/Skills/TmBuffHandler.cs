using System;
using System.Collections.Generic;
using Tumo;
namespace Servers
{
    class TmBuffHandler : TmEntity
    {
        public override void OnTransferParameter(object obj, TmParameter parameter)
        {
            ElevenCode elevenCode = parameter.ElevenCode;
            switch (elevenCode)
            {
                case (ElevenCode.Get):
                    Console.WriteLine(TmTimerTool.CurrentTime() + " TmBuffHandler: " + elevenCode);
                    GetSkill(parameter);
                    break;
                case (ElevenCode.GetSkills):
                    Console.WriteLine(TmTimerTool.CurrentTime() + " TmBuffHandler: " + elevenCode);
                    GetSkillsByRolerId(parameter);
                    break;
                case (ElevenCode.Save):
                    Console.WriteLine(TmTimerTool.CurrentTime() + " TmBuffHandler: " + elevenCode);
                    break;
                case (ElevenCode.None):
                    break;
                default:
                    break;
            }
        }
        internal Dictionary<int, TmSkill> Skills { get; set; } = new Dictionary<int, TmSkill>();
        internal Dictionary<int, Dictionary<int, TmSkillDB>> Buffs { get; set; } = new Dictionary<int, Dictionary<int, TmSkillDB>>();
        private void GetSkill(TmParameter parameter)
        {
            bool yes = false;
            int count = 0;
            while (!yes)
            {
                if (Skills.Count>0)
                {
                    TmParameter response = TmParameterTool.ToJsonParameter<Dictionary<int, TmSkill>>(TenCode.Buff, ElevenCode.Get, ElevenCode.Get.ToString(), Skills);
                    response.EcsId = parameter.EcsId;
                    TmTcpSocket.Instance.Send(response);
                    yes = true;
                }
                else
                {
                    TmMysqlHandler.Instance.GetComponent<TmBuffMysql>().OnTransferParameter(this, parameter);
                    Console.WriteLine(TmTimerTool.CurrentTime() + " this.Skills:" + this.Skills.Count);
                    count += 1;
                }
                if (count > 4)
                {
                    yes = true;
                    break;
                }
            }
        }
        private void GetSkillsByRolerId(TmParameter parameter)
        {
            int rolerid = TmParameterTool.GetJsonValue<int>(parameter, ElevenCode.EngineerLogin.ToString());
            Dictionary<int, TmSkillDB> skillDBs;
            bool yes = false;
            int count = 0;
            while (!yes)
            {
                yes = Buffs.TryGetValue(rolerid, out skillDBs);
                if (yes)
                {
                    TmParameter response = TmParameterTool.ToJsonParameter<Dictionary<int, TmSkillDB>>(TenCode.Buff, ElevenCode.GetSkills, ElevenCode.GetSkills.ToString(), skillDBs);
                    TmParameterTool.AddJsonParameter(response, "RolerId", rolerid);
                    response.EcsId = parameter.EcsId;
                    TmTcpSocket.Instance.Send(response);
                    yes = true;
                    break;
                }
                else
                {
                    TmMysqlHandler.Instance.GetComponent<TmBuffMysql>().OnTransferParameter(this, parameter);
                    Console.WriteLine(TmTimerTool.CurrentTime() + " this.Buffs:" + this.Buffs.Count);
                    count += 1;
                }
                if (count > 4)
                {
                    yes = true;
                    break;
                }
            }
        }


    }
}
