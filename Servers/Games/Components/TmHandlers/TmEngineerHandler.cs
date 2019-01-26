﻿using System;
using System.Collections.Generic;
using Tumo;
namespace Servers
{
    public class TmEngineerHandler : TmEntity
    {
        public override void TmAwake()
        {
            base.TmAwake();
            //AddComponent(new TmStatusSyncHandler());
        }
        public override void OnTransferParameter(object obj , TmParameter parameter)
        {
            ElevenCode elevenCode = parameter.ElevenCode;
            switch (elevenCode)
            {
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
                    this.GetComponent<TmStatusSyncHandler>().OnTransferParameter(this, parameter);
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
        private void GetRolersByUersId(TmParameter parameter)
        {
            TmMysqlHandler.Instance.GetComponent<TmEngineerMysql>().OnTransferParameter(this, parameter);
            Console.WriteLine(TmTimerTool.CurrentTime() + " this.Engineers:" + this.Engineers.Count);
            if (this.Engineers != null)
            {
                TmParameter response = TmParameterTool.ToJsonParameter<List<TmSoulerDB>>(TenCode.Engineer, ElevenCode.GetRolers, ElevenCode.GetRolers.ToString(), this.Engineers);
                response.EcsId = parameter.EcsId;
                TmTcpSocket.Instance.Send(response);
            }
        }
        private void EngineerLogin(TmParameter parameter)
        {
            int rolerId = TmParameterTool.GetJsonValue<int>(parameter, parameter.ElevenCode.ToString());
            Console.WriteLine(TmTimerTool.CurrentTime() + " rolerId:" + rolerId);
            parameter.ElevenCode = ElevenCode.GetRolers;
            Parent.GetComponent<TmBookerHandler>().OnTransferParameter(this, parameter);
            Parent.GetComponent<TmTeacherHandler>().OnTransferParameter(this, parameter);
        }

    }
}
