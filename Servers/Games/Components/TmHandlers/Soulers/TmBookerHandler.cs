using System;
using System.Collections.Generic;
using Tumo;
namespace Servers
{
    public class TmBookerHandler : TmEntity
    {      
        public override void OnTransferParameter(object obj , TmParameter parameter)
        {
            ElevenCode elevenCode = parameter.ElevenCode;
            switch (elevenCode)
            {
                case (ElevenCode.GetRolers):
                    Console.WriteLine(TmTimerTool.CurrentTime() + " TmBookerHandler: " + elevenCode);
                    GetRolersByRolerId(parameter);
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
        internal List<TmSoulerDB> Bookers { get; set; }
        public Dictionary<string, TmMonster> SpawnCDs = new Dictionary<string, TmMonster>();
        void GetRolersByRolerId(TmParameter parameter)
        {
            bool yes = false;
            int count = 0;
            while (!yes)
            {
                if (this.Bookers != null)
                {
                    TmParameter response = TmParameterTool.ToJsonParameter<List<TmSoulerDB>>(TenCode.Booker, ElevenCode.GetRolers, ElevenCode.GetRolers.ToString(), this.Bookers);
                    response.Keys.Add(parameter.Keys[0]); 
                    TmTcpSocket.Instance.Send(response);
                    yes = true;
                }
                else
                {
                    TmMysqlHandler.Instance.GetComponent<TmBookerMysql>().OnTransferParameter(this, parameter);
                    Console.WriteLine(TmTimerTool.CurrentTime() + " Bookers:" + Bookers.Count);
                    count += 1;
                }
                if (count > 4)
                {
                    yes = true;
                    break;
                }
            }
        }  
        void DiethHandler(TmParameter parameter)
        {
            TmSoulerDB soulerDB = TmParameterTool.GetJsonValue<TmSoulerDB>(parameter, ElevenCode.Die.ToString());
            TmMonster monster = new TmMonster(this);
            monster.AddComponent(soulerDB);
            //(monster.GetComponent<TmCoolDown>() as TmCoolDown).Key = parameter.Key;
            SpawnCDs.Add(monster.EcsId, monster);

            parameter.ElevenCode = ElevenCode.RolerRemove;
            foreach(var tem in TmTcpSocket.Instance.TPeers.Keys)
            {
                parameter.Keys.Add(tem);
            }
            TmTcpSocket.Instance.Send(parameter);
        }

    }
}