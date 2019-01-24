using System;
using System.Collections.Generic;
using Tumo;
namespace Servers
{
    public class TmBookerHandler : TmComponent
    {
        public override void OnTransferParameter(object obj , TmParameter parameter)
        {
            ElevenCode elevenCode = parameter.ElevenCode;
            switch (elevenCode)
            {
                case (ElevenCode.EngineerLogin):
                    Console.WriteLine(TmTimerTool.CurrentTime() + " TmBookerHandler: " + elevenCode);
                    EngineerLogin(parameter);
                    break;
                case (ElevenCode.None):
                    break;
                default:
                    break;
            }
        }
        internal List<TmSoulerDB> Bookers;
        internal List<TmInventoryDB> Dresseds;
        internal List<TmSkillDB> Abilitis;
        internal List<TmSkillDB> Buffs;
        internal List<TmSkillDB> Inborns;
        private void EngineerLogin(TmParameter parameter)
        {
            TmMysqlHandlers.Instance.GetComponent<TmBookerMysql>().OnTransferParameter(this, parameter);
            Console.WriteLine(TmTimerTool.CurrentTime() + " Bookers:" + Bookers.Count);
            SenderBookersToClient(parameter);
        }
        void SenderBookersToClient(TmParameter parameter)
        {
            TmParameterTool.AddJsonParameter<List<TmSoulerDB>>(parameter, "Bookers", Bookers);
            parameter.TenCode = TenCode.Booker;
            TmTcpSocket.Instance.Send(parameter);
        } 

    }
}
