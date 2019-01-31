using System;
using System.Collections.Generic;
using Tumo;
namespace Servers.Games.Systems
{
    class TmBookercdSystem : TmSystem
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
            base.TmUpdate();
            foreach(var entity in GetTmEntities())
            {
                UpdateCDTime(entity);
            }
        }
        void UpdateCDTime(TmEntity entity)
        {
            TmCoolDown cd = entity.GetComponent<TmCoolDown>() as TmCoolDown;
            cd.CdTime += 1;
            if (cd.CdTime >= cd.MaxCdTime)
            {
                Console.WriteLine(TmTimerTool.CurrentTime() + " TmBookercd Colsed. Booker Id{0} 刷新。 ", TmTcpSocket.Instance.TPeers.Count);
                cd.End = true;
                if (cd.Parent != null)
                {
                    cd.Parent.Dispose();
                }
                this.Dispose();
            }
            else
            {
                //发送心跳检测（并等待签到，签到入口在TmAsyncTcpSession里）
                TmParameter parameter = TmParameterTool.ToJsonParameter(TenCode.Booker, ElevenCode.GetRoler, ElevenCode.GetRoler.ToString(), (Parent.GetComponent<TmSoulerDB>() as TmSoulerDB));
                parameter.EcsId = cd.Key;
                TmTcpSocket.Instance.Send(parameter);
            }
            Console.WriteLine(TmTimerTool.CurrentTime() + " CdCount:{0}-{1} ", cd.CdCount, cd.MaxCdCount);
        }
    }
}