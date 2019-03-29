using System;
using System.Collections.Generic;
using Tumo;
namespace Servers
{
    class TmAbilityHandler : TmEntity
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
                case (ElevenCode.Save):
                    Console.WriteLine(TmTimerTool.CurrentTime() + " TmAbilityHandler: " + elevenCode);
                    break;
                case (ElevenCode.None):
                    break;
                default:
                    break;
            }
        }
        internal Dictionary<int, Dictionary<int, TmSkillDB>> Abilities { get; set; } = new Dictionary<int, Dictionary<int, TmSkillDB>>();
        private void GetSkillsByRolerId(TmParameter parameter)
        {
            int rolerid = TmParameterTool.GetJsonValue<int>(parameter, ElevenCode.EngineerLogin.ToString());
            Dictionary<int, TmSkillDB> skillDBs = new Dictionary<int, TmSkillDB>();
            bool yes = false;
            int count = 0;
            while (!yes)
            {
                if (Abilities.Count > 0)
                {
                    yes = Abilities.TryGetValue(rolerid, out skillDBs);
                }
                if (yes)
                {
                    TmParameter response = TmParameterTool.ToJsonParameter<Dictionary<int, TmSkillDB>>(TenCode.Ability, ElevenCode.GetSkills, ElevenCode.GetSkills.ToString(), skillDBs);
                    TmParameterTool.AddJsonParameter(response, "RolerId", rolerid);
                    response.Keys.Add(parameter.Keys[0]);
                    TmTcpSocket.Instance.Send(response);
                    yes = true;
                    break;
                }
                else
                {
                    TmMysqlHandler.Instance.GetComponent<TmAbilityMysql>().OnTransferParameter(this, parameter);
                    Console.WriteLine(TmTimerTool.CurrentTime() + " this.Abilities:" + this.Abilities.Count);
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
