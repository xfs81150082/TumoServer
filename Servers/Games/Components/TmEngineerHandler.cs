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
                case (ElevenCode.UserLogin):
                    Console.WriteLine(TmTimerTool.CurrentTime() + " TmEngineerHandler: " + elevenCode);
                    UserLogin(parameter);
                    break;
                case (ElevenCode.EngineerLogin):
                    Console.WriteLine(TmTimerTool.CurrentTime() + " TmEngineerHandler: " + elevenCode);
                    EngineerLogin(parameter);
                    break;
                case (ElevenCode.None):
                    break;
                default:
                    break;
            }
        }
        internal List<TmSoulerDB> Engineers;
        internal List<TmInventoryDB> Knapsacks;
        internal List<TmInventoryDB> Dresseds;
        internal List<TmSkillDB> Abilitis;
        internal List<TmSkillDB> Buffs;
        internal List<TmSkillDB> Inborns;
        private void UserLogin(TmParameter parameter)
        {
            //int rolerId = TmParameterTool.GetValue<int>(parameter, parameter.ElevenCode.ToString());
            //Console.WriteLine(TmTimerTool.CurrentTime() + " rolerId:" + rolerId);
            TmMysqlHandlers.Instance.GetComponent<TmEngineerMysql>().OnTransferParameter(this, parameter);
            Console.WriteLine(TmTimerTool.CurrentTime() + " this.Engineers:" + this.Engineers.Count);
            if (this.Engineers != null)
            {
                TmParameter response = TmParameterTool.ToJsonParameter<List<TmSoulerDB>>(TenCode.Engineer, ElevenCode.UserLogin, ElevenCode.UserLogin.ToString(), this.Engineers);
                response.EcsId = parameter.EcsId;
                TmTcpSocket.Instance.Send(response);
            }
        }
        private void EngineerLogin(TmParameter parameter)
        {
            int rolerId = TmParameterTool.GetJsonValue<int>(parameter, parameter.ElevenCode.ToString());
            Console.WriteLine(TmTimerTool.CurrentTime() + " rolerId:" + rolerId);
            Parent.GetComponent<TmBookerHandler>().OnTransferParameter(this, parameter);
            Parent.GetComponent<TmTeacherHandler>().OnTransferParameter(this, parameter);
            //Console.WriteLine(TmTimerTool.CurrentTime() + " Bookers:" + Bookers.Count);
            //Console.WriteLine(TmTimerTool.CurrentTime() + " Teachers:" + Teachers.Count);
            //SenderBookersAndTeachersToClient(parameter);
        }
        //void SenderBookersAndTeachersToClient(TmParameter parameter)
        //{
        //    TmParameterTool.AddJsonParameter<List<TmSoulerDB>>(parameter, "Bookers", Bookers);
        //    TmParameterTool.AddJsonParameter<List<TmSoulerDB>>(parameter, "Teachers", Teachers);
        //    parameter.TenCode = TenCode.Engineer;
        //    TmTcpSocket.Instance.Send(parameter);
        //} 
    }
}
