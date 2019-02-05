using System;
using System.Collections.Generic;
using Tumo;
namespace Servers
{
    class TmBuffHandler : TmComponent
    {
        public override void OnTransferParameter(object obj, TmParameter parameter)
        {
            ElevenCode elevenCode = parameter.ElevenCode;
            switch (elevenCode)
            {
                case (ElevenCode.GetSkills):
                    Console.WriteLine(TmTimerTool.CurrentTime() + " TmBuffHandler: " + elevenCode);
                    GetSkillsByRolerId(parameter);
                    break;
                case (ElevenCode.GetSkill):
                    Console.WriteLine(TmTimerTool.CurrentTime() + " TmBuffHandler: " + elevenCode);
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
        internal TmSkillDB Buff;
        internal Dictionary<int, Dictionary<int, TmSkillDB>> Buffs { get; set; }
        private void GetSkillsByRolerId(TmParameter parameter)
        {
            int rolerid = TmParameterTool.GetJsonValue<int>(parameter, ElevenCode.GetSkills.ToString());
            Dictionary<int, TmSkillDB> skillDBs;
            bool yes = false;
            while (!yes)
            {
                yes = Buffs.TryGetValue(rolerid, out skillDBs);
                if (yes)
                {
                    TmParameter response = TmParameterTool.ToJsonParameter<Dictionary<int, TmSkillDB>>(TenCode.Buff, ElevenCode.GetSkills, ElevenCode.GetSkills.ToString(), skillDBs);
                    response.EcsId = parameter.EcsId;
                    TmTcpSocket.Instance.Send(response);
                    break;
                }
                else
                {
                    TmMysqlHandler.Instance.GetComponent<TmBuffMysql>().OnTransferParameter(this, parameter);
                    Console.WriteLine(TmTimerTool.CurrentTime() + " this.Buffs:" + this.Buffs.Count);
                }
            }
        }


    }
}
