using System;
using System.Collections.Generic;
using Tumo;
namespace Servers
{
    public class TmEngineerHandler : TmEntity
    {
        public override void OnTransferParameter(object obj , TmParameter parameter)
        {
            ElevenCode elevenCode = parameter.ElevenCode;
            switch (elevenCode)
            {
                case (ElevenCode.Get):
                    Console.WriteLine(TmTimerTool.CurrentTime() + " TmEngineerHandler: " + elevenCode);
                    GetSoulers(parameter);
                    break;
                case (ElevenCode.GetRolers):
                    Console.WriteLine(TmTimerTool.CurrentTime() + " TmEngineerHandler: " + elevenCode);
                    GetRolersByUersId(parameter);
                    break;
                case (ElevenCode.EngineerLogin):
                    Console.WriteLine(TmTimerTool.CurrentTime() + " TmEngineerHandler: " + elevenCode);
                    EngineerLogin(parameter);
                    break;
                case (ElevenCode.StatusSync):
                    Console.WriteLine(TmTimerTool.CurrentTime() + " TmStatusSyncHandler: " + elevenCode);
                    Parent.GetComponent<TmStatusSyncHandler>().OnTransferParameter(this, parameter);
                    break;
                case (ElevenCode.None):
                    break;
                default:
                    break;
            }
        }
        internal Dictionary<int, TmSouler> Soulers { get; set; }                  //在线角色字典,ByRolerId
        internal Dictionary<int, TmSoulerDB> Engineers { get; set; } = new Dictionary<int, TmSoulerDB>();                      //在线角色字典,ByRolerId
        internal Dictionary<int, List<TmSoulerDB>> EngineerDbs { get; set; } = new Dictionary<int, List<TmSoulerDB>>();        //角色列表字典,ByUersId
        private void GetSoulers(TmParameter parameter)
        {
            if (Soulers == null)
            {
                TmMysqlHandler.Instance.GetComponent<TmEngineerMysql>().OnTransferParameter(this, parameter);
                Console.WriteLine(TmTimerTool.CurrentTime() + " this.Soulers:" + this.Soulers.Count);
            }
            TmParameter response = TmParameterTool.ToJsonParameter<Dictionary<int, TmSouler>>(TenCode.Engineer, ElevenCode.Get, ElevenCode.Get.ToString(), Soulers);
            response.EcsId = parameter.EcsId;
            TmTcpSocket.Instance.Send(response);
        }
        private void GetRolersByUersId(TmParameter parameter)
        {
            List<TmSoulerDB> Engineers = null;
            int userId = TmParameterTool.GetValue<int>(parameter, ElevenCode.UserLogin.ToString());
            bool yes = false;
            while (!yes)
            {
                if (EngineerDbs.Count > 0)
                {
                    yes = EngineerDbs.TryGetValue(userId, out Engineers);
                }
                if (yes)
                {
                    TmParameter response = TmParameterTool.ToJsonParameter<List<TmSoulerDB>>(TenCode.Engineer, ElevenCode.GetRolers, ElevenCode.GetRolers.ToString(), Engineers);
                    response.EcsId = parameter.EcsId;
                    TmTcpSocket.Instance.Send(response);
                    break;
                }
                else
                {
                    TmMysqlHandler.Instance.GetComponent<TmEngineerMysql>().OnTransferParameter(this, parameter);
                    Console.WriteLine(TmTimerTool.CurrentTime() + " this.EngineerDbs:" + EngineerDbs.Count);
                }
            }
        }
        private void EngineerLogin(TmParameter parameter)
        {
            TmSoulerDB Engineer = null;
            int rolerId = TmParameterTool.GetJsonValue<int>(parameter, parameter.ElevenCode.ToString());
            bool yes = false;
            while (!yes)
            {
                if (Engineers.Count > 0)
                {
                    yes = Engineers.TryGetValue(rolerId, out Engineer);
                }
                if (yes)
                {
                    TmParameter response = TmParameterTool.ToJsonParameter<TmSoulerDB>(TenCode.Engineer, ElevenCode.GetRoler, ElevenCode.GetRoler.ToString(), Engineer);
                    response.EcsId = parameter.EcsId;
                    TmTcpSocket.Instance.Send(response);
                    GetSoulersByRolerId(parameter);
                    GetSkillsByRolerId(parameter);
                    GetInventorysByRolerId(parameter);
                }
                else
                {
                    TmMysqlHandler.Instance.GetComponent<TmEngineerMysql>().OnTransferParameter(this, parameter);
                    Console.WriteLine(TmTimerTool.CurrentTime() + " Engineers:" + Engineers.Count);
                }
            }
        }    
        void GetSoulersByRolerId(TmParameter parameter)
        {
            parameter.ElevenCode = ElevenCode.GetRolers;
            Parent.GetComponent<TmBookerHandler>().OnTransferParameter(this, parameter);
            Parent.GetComponent<TmTeacherHandler>().OnTransferParameter(this, parameter);
        }
        void GetSkillsByRolerId(TmParameter parameter)
        {
            parameter.ElevenCode = ElevenCode.GetSkills;
            Console.WriteLine(TmTimerTool.CurrentTime() + " GetSkillsByRolerId:" + parameter.ElevenCode);
            Parent.GetComponent<TmAbilityHandler>().OnTransferParameter(this, parameter);
            Parent.GetComponent<TmBuffHandler>().OnTransferParameter(this, parameter);
            Parent.GetComponent<TmInbornHandler>().OnTransferParameter(this, parameter);
        }
        void GetInventorysByRolerId(TmParameter parameter)
        {
            parameter.ElevenCode = ElevenCode.GetInventorys;
            Console.WriteLine(TmTimerTool.CurrentTime() + " GetInventorysByRolerId:" + parameter.ElevenCode);
            Parent.GetComponent<TmDressedHandler>().OnTransferParameter(this, parameter);
            Parent.GetComponent<TmKnapsackHandler>().OnTransferParameter(this, parameter);
            Parent.GetComponent<TmSmityHandler>().OnTransferParameter(this, parameter);
        }


    }
}
