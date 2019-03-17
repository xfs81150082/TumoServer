using System;
using System.Collections.Generic;
using Tumo;
namespace Servers
{
    class TmBookerCDSystem : TmSystem
    {
        public override void TmAwake()
        {
            base.TmAwake();
            ValTime = 4000;
            AddComponent(new TmBooker());
            AddComponent(new TmCoolDown());
        }     
        public override void TmUpdate()
        {
            foreach (TmEntity entity in GetTmEntities())
            {
                UpdateCDTime(entity);
            }
        }
        void UpdateCDTime(TmEntity entity)
        {
            TmCoolDown cd = entity.GetComponent<TmCoolDown>() as TmCoolDown;
            cd.CdTime += ValTime;
            if (cd.CdTime >= cd.MaxCdTime)
            {
                Console.WriteLine(TmTimerTool.CurrentTime() + " TmBookercd Colsed. Booker Id{0} 刷新。 ", TmTcpSocket.Instance.TPeers.Count);
                cd.End = true;
                TmSoulerDB soulerDB = entity.GetComponent<TmSoulerDB>() as TmSoulerDB;
                //发送心跳检测（并等待签到，签到入口在TmAsyncTcpSession里）
                TmParameter parameter = TmParameterTool.ToJsonParameter(TenCode.Booker, ElevenCode.GetRoler, ElevenCode.GetRoler.ToString(), (entity.GetComponent<TmSoulerDB>() as TmSoulerDB));
                //parameter.Key = cd.Key;
                TmTcpSocket.Instance.SendAll(parameter);
                (entity.Parent as TmBookerHandler).SpawnCDs.Remove(entity.EcsId);
                entity.Dispose();
            }
            Console.WriteLine(TmTimerTool.CurrentTime() + " CdTime:{0}-{1} ", cd.CdTime, cd.MaxCdTime);
        }
    }
}