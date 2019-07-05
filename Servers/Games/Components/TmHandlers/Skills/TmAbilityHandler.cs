using System;
using System.Collections.Generic;
using System.Linq;
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
        internal Dictionary<int, List<TmSkillDB>> Abilities { get; set; } = new Dictionary<int, List<TmSkillDB>>();
        private void GetSkillsByRolerId(TmParameter parameter)
        {
            int rolerid = TmParameterTool.GetJsonValue<int>(parameter, ElevenCode.EngineerLogin.ToString());
            List<TmSkillDB> skillDBs = new List<TmSkillDB>();
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
                    if (TmTcpSocket.Instance.TPeers[parameter.Keys[0]] != null)
                    {
                        TmTcpSocket.Instance.TPeers[parameter.Keys[0]].GetComponent<TmSession>().SkillDBs = skillDBs;  //给TmTcpSession赋值Engineer-SoulerDB
                    }
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
