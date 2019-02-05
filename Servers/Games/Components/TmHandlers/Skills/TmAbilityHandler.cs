using System;
using System.Collections.Generic;
using Tumo;
namespace Servers
{
    class TmAbilityHandler : TmComponent
    {
        public override void OnTransferParameter(object obj, TmParameter parameter)
        {
            ElevenCode elevenCode = parameter.ElevenCode;
            switch (elevenCode)
            {
                case (ElevenCode.GetSkills):
                    Console.WriteLine(TmTimerTool.CurrentTime() + " TmAbilityHandler: " + elevenCode);
                    GetSkillsByRolerId(parameter);
                    break;
                case (ElevenCode.GetSkill):
                    Console.WriteLine(TmTimerTool.CurrentTime() + " TmAbilityHandler: " + elevenCode);
                    break;
                case (ElevenCode.Save):
                    Console.WriteLine(TmTimerTool.CurrentTime() + " TmAbilityHandler: " + elevenCode);
                    break;
                case (ElevenCode.None):
                    break;
                default:
                    break;
            }
        }
        internal Dictionary<int, Dictionary<int, TmSkillDB>> Abilities { get; set; }
        private void GetSkillsByRolerId(TmParameter parameter)
        {
            int rolerid = TmParameterTool.GetJsonValue<int>(parameter, ElevenCode.GetSkills.ToString());
            Dictionary<int, TmSkillDB> skillDBs = null;
            bool yes = false;
            while (!yes)
            {
                if (Abilities.Count > 0)
                {
                    yes = Abilities.TryGetValue(rolerid, out skillDBs);
                }
                if (yes)
                {
                    TmParameter response = TmParameterTool.ToJsonParameter<Dictionary<int, TmSkillDB>>(TenCode.Ability, ElevenCode.GetSkills, ElevenCode.GetSkills.ToString(), skillDBs);
                    response.EcsId = parameter.EcsId;
                    TmTcpSocket.Instance.Send(response);
                    break;
                }
                else
                {
                    TmMysqlHandler.Instance.GetComponent<TmAbilityMysql>().OnTransferParameter(this, parameter);
                    Console.WriteLine(TmTimerTool.CurrentTime() + " this.Abilities:" + this.Abilities.Count);
                }
            }
        }


    }
}
