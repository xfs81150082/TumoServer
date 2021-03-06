﻿using System;
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
        internal Dictionary<int, TmSoulerDB> Engineers { get; set; } = new Dictionary<int, TmSoulerDB>();                      //在线角色字典,ByRolerId
        internal Dictionary<int, List<TmSoulerDB>> EngineerDbs { get; set; } = new Dictionary<int, List<TmSoulerDB>>();        //角色列表字典,ByUersId
        private void GetRolersByUersId(TmParameter parameter)
        {
            List<TmSoulerDB> Engineers = null;
            int userId = TmParameterTool.GetValue<int>(parameter, ElevenCode.UserLogin.ToString());
            bool yes = false;
            int count = 0;
            while (!yes)
            {
                if (EngineerDbs.Count > 0)
                {
                    yes = EngineerDbs.TryGetValue(userId, out Engineers);
                }
                if (yes)
                {
                    TmParameter response = TmParameterTool.ToJsonParameter<List<TmSoulerDB>>(TenCode.Engineer, ElevenCode.GetRolers, ElevenCode.GetRolers.ToString(), Engineers);
                    response.Keys.Add(parameter.Keys[0]);
                    TmTcpSocket.Instance.Send(response);
                    break;
                }
                else
                {
                    TmMysqlHandler.Instance.GetComponent<TmEngineerMysql>().OnTransferParameter(this, parameter);
                    Console.WriteLine(TmTimerTool.CurrentTime() + " this.EngineerDbs:" + EngineerDbs.Count);
                    count += 1;
                }
                if (count > 3)
                {
                    yes = true;
                }
            }
        }
        private void EngineerLogin(TmParameter parameter)
        {
            TmSoulerDB Engineer = null;
            int rolerId = TmParameterTool.GetJsonValue<int>(parameter, parameter.ElevenCode.ToString());
            bool yes = false;
            int count = 0;
            while (!yes)
            {
                if (Engineers.Count > 0)
                {
                    yes = Engineers.TryGetValue(rolerId, out Engineer);
                }
                if (yes)
                {                    
                    TmParameter response = TmParameterTool.ToJsonParameter<TmSoulerDB>(TenCode.Engineer, ElevenCode.GetRoler, ElevenCode.GetRoler.ToString(), Engineer);
                    response.Keys.Add(parameter.Keys[0]);
                    TmTcpSocket.Instance.Send(response);

                    TmSoulerDB tem;
                    TmObjects.Engineers.TryGetValue(Engineer.Id, out tem);
                    if (tem != null)
                    {
                        TmObjects.Engineers.Remove(Engineer.Id);
                    }
                    TmObjects.Engineers.Add(Engineer.Id, Engineer);  //将engineer 集中管理 放在 全局变量字典中，之前几行是检查有没有注册，如有先删除，再重新注册（因为数据更新了）。

                    if (TmTcpSocket.Instance.TPeers[parameter.Keys[0]] != null)
                    {
                        TmTcpSocket.Instance.TPeers[parameter.Keys[0]].GetComponent<TmSession>().Engineer = Engineer;  //给TmTcpSession赋值Engineer-SoulerDB
                        //TmTcpSocket.Instance.TPeers[parameter.Keys[0]].GetComponent<TmSession>().Engineers = GetEngineersByMyself(Engineer, TmObjects.Engineers);  //给TmTcpSession赋值Engineer-SoulerDB
                        TmTcpSocket.Instance.TPeers[parameter.Keys[0]].GetComponent<TmSession>().Engineers = TmObjects.Engineers;  //给TmTcpSession赋值Engineer-SoulerDB
                        TmTcpSocket.Instance.TPeers[parameter.Keys[0]].GetComponent<TmSession>().IsLogin = true;  //给TmTcpSession赋值Engineer-SoulerDB
                    }
                    GetInventorysByRolerId(parameter);
                    GetSkillsByRolerId(parameter);
                }
                else
                {
                    TmMysqlHandler.Instance.GetComponent<TmEngineerMysql>().OnTransferParameter(this, parameter);
                    Console.WriteLine(TmTimerTool.CurrentTime() + " Engineers:" + Engineers.Count);
                    count += 1;
                }
                if (count > 3)
                {
                    yes = true;
                }
            }
        }   
        Dictionary<int,TmSoulerDB> GetEngineersByMyself(TmSoulerDB soulerDB, Dictionary<int,TmSoulerDB> soulerDBs)
        {
            Dictionary<int, TmSoulerDB> dbs = new Dictionary<int, TmSoulerDB>();
            soulerDBs.Remove(soulerDB.Id);
            List<TmSoulerDB> list = new List<TmSoulerDB>(soulerDBs.Values);
            for(int i = 0; i < list.Count; i++)
            {
                double xx = Math.Abs(soulerDB.px - list[i].px);
                double zz = Math.Abs(soulerDB.pz - list[i].pz);
                if (xx < 100 && zz < 100)
                {
                    dbs.Add(list[i].Id, list[i]);
                }
            }       
            return dbs;
        }
        void GetSkillsByRolerId(TmParameter parameter)
        {
            parameter.ElevenCode = ElevenCode.GetSkills;
            Console.WriteLine(TmTimerTool.CurrentTime() + " GetSkillsByRolerId:" + parameter.ElevenCode);
            Parent.GetComponent<TmAbilityHandler>().OnTransferParameter(this, parameter);
        }
        void GetInventorysByRolerId(TmParameter parameter)
        {
            parameter.ElevenCode = ElevenCode.GetInventorys;
            Console.WriteLine(TmTimerTool.CurrentTime() + " GetInventorysByRolerId:" + parameter.ElevenCode);
            Parent.GetComponent<TmKnapsackHandler>().OnTransferParameter(this, parameter);
        }


    }
}
