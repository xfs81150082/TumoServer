using System;
using System.Collections.Generic;
using Tumo;
namespace Servers
{
    public class TmEngineerHandler : TmComponent
    {
        public override void OnTransferParameter(object obj , TmParameter parameter)
        {
            ElevenCode elevenCode = parameter.ElevenCode;
            switch (elevenCode)
            {
                case (ElevenCode.Login):
                    Console.WriteLine(TmTimerTool.CurrentTime() + " TmEngineerHandler: " + elevenCode);
                    EngineerLogin(parameter);
                    break;
                case (ElevenCode.None):
                    break;
                default:
                    break;
            }
        }
        internal List<TmSoulerDB> Bookers;
        internal List<TmSoulerDB> Teachers;
        internal List<TmInventoryDB> Knapsacks;
        internal List<TmInventoryDB> Dresseds;
        internal List<TmInventoryDB> Smithys;
        internal List<TmInventoryDB> Terrains;
        internal List<TmSkillDB> Abilitis;
        internal List<TmSkillDB> Buffs;
        internal List<TmSkillDB> Inborns;
        private void EngineerLogin(TmParameter parameter)
        {
            int rolerId = TmParameterTool.GetJsonValue<int>(parameter, parameter.ElevenCode.ToString());
            Console.WriteLine(TmTimerTool.CurrentTime() + " rolerId:" + rolerId);
            TmMysqlHandler.Instance.GetComponent<TmBookerMysql>().OnTransferParameter(this, parameter);
            TmMysqlHandler.Instance.GetComponent<TmTeacherMysql>().OnTransferParameter(this, parameter);
            Console.WriteLine(TmTimerTool.CurrentTime() + " Bookers:" + Bookers.Count);
            Console.WriteLine(TmTimerTool.CurrentTime() + " Teachers:" + Teachers.Count);
            SenderBookersAndTeachersToClient(parameter);
        }
        void SenderBookersAndTeachersToClient(TmParameter parameter)
        {
            TmParameterTool.AddJsonParameter<List<TmSoulerDB>>(parameter, "Bookers", Bookers);
            TmParameterTool.AddJsonParameter<List<TmSoulerDB>>(parameter, "Teachers", Teachers);
            parameter.TenCode = TenCode.TmEngineerController;
            TmTcpSocket.Instance.Send(parameter);
        } 

    }
}
