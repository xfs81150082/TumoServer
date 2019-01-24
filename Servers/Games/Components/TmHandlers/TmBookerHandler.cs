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
                case (ElevenCode.GetRolers):
                    Console.WriteLine(TmTimerTool.CurrentTime() + " TmBookerHandler: " + elevenCode);
                    GetRolers(parameter);
                    break;
                case (ElevenCode.Die):
                    Console.WriteLine(TmTimerTool.CurrentTime() + " TmBookerHandler: " + elevenCode);
                    DiethHandler(parameter);
                    break;
                case (ElevenCode.None):
                    break;
                default:
                    break;
            }
        }
        internal List<TmSoulerDB> Bookers;
        internal Dictionary<int, Monster> SpawnMonsters = new Dictionary<int, Monster>();
        internal TmSoulerDB booker { get; set; }
        void GetRolers(TmParameter parameter)
        {
            TmMysqlHandler.Instance.GetComponent<TmBookerMysql>().OnTransferParameter(this, parameter);
            Console.WriteLine(TmTimerTool.CurrentTime() + " Bookers:" + Bookers.Count);
            if (this.Bookers != null)
            {
                TmParameter response = TmParameterTool.ToJsonParameter<List<TmSoulerDB>>(TenCode.Booker, ElevenCode.GetRolers, ElevenCode.GetRolers.ToString(), this.Bookers);
                response.EcsId = parameter.EcsId;
                TmTcpSocket.Instance.Send(response);
            }
        }     
        void DiethHandler(TmParameter parameter)
        {
            int rolerId = TmParameterTool.GetJsonValue<int>(parameter, ElevenCode.GetRoler.ToString());
            ///ToTo
            Monster monster = new Monster();
            TmSoulerDB soulerDB = monster.GetComponent<TmSoulerDB>() as TmSoulerDB;
            soulerDB = new TmSoulerDB();
            (monster.GetComponent<TmCoolDown>() as TmCoolDown).MaxCdTime = 14;
            ///ToTo
        }

    }
}
