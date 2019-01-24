using System;
using System.Collections.Generic;
using Tumo;
namespace Servers
{
    public class TmTeacherHandler : TmComponent
    {
        public override void OnTransferParameter(object obj , TmParameter parameter)
        {
            ElevenCode elevenCode = parameter.ElevenCode;
            switch (elevenCode)
            {
                case (ElevenCode.EngineerLogin):
                    Console.WriteLine(TmTimerTool.CurrentTime() + " TmTeacherHandler: " + elevenCode);
                    EngineerLogin(parameter);
                    break;
                case (ElevenCode.None):
                    break;
                default:
                    break;
            }
        }
        internal List<TmSoulerDB> Teachers;
        internal List<TmInventoryDB> Dresseds;
        internal List<TmInventoryDB> Smithys;
        internal List<TmSkillDB> Abilitis;
        internal List<TmSkillDB> Buffs;
        internal List<TmSkillDB> Inborns;
        private void EngineerLogin(TmParameter parameter)
        {
            TmMysqlHandlers.Instance.GetComponent<TmTeacherMysql>().OnTransferParameter(this, parameter);
            Console.WriteLine(TmTimerTool.CurrentTime() + " Teachers:" + Teachers.Count);
            SenderBookersAndTeachersToClient(parameter);
        }
        void SenderBookersAndTeachersToClient(TmParameter parameter)
        {
            TmParameterTool.AddJsonParameter<List<TmSoulerDB>>(parameter, "Teachers", Teachers);
            parameter.TenCode = TenCode.Teacher;
            TmTcpSocket.Instance.Send(parameter);
        } 
    }
}
