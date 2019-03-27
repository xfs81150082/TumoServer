﻿using System;
namespace Tumo
{
    class TmSessionSystem : TmSystem
    {
        public override void TmAwake()
        {
            ValTime = 4000;
            AddComponent(new TmSession());
            AddComponent(new TmCoolDown());
        }
        public override void TmUpdate()
        {
            foreach (TmEntity entity in GetTmEntities())
            {
                UpdateCDCount(entity);
            }
        }
        void UpdateCDCount(TmEntity entity)
        {
            TmCoolDown cd = entity.GetComponent<TmCoolDown>();
            ////cd.CdCount += 1;
            ////if (cd.CdCount >= cd.MaxCdCount)
            ////{
            ////    Console.WriteLine(TmTimerTool.CurrentTime() + " TmSessionCDItem Colsed. TPeers:{0} ", TmTcpSocket.Instance.TPeers.Count);
            ////    cd.End = true;
            ////    if (cd.Parent != null)
            ////    {
            ////        cd.Parent.Dispose();
            ////    }
            ////    this.Dispose();
            ////}
            ////else
            ////{
            ////    //发送心跳检测（并等待签到，签到入口在TmAsyncTcpSession里）
            ////    TmParameter mvc = TmParameterTool.ToParameter(TenCode.EessionCD, ElevenCode.Login);
            ////    mvc.EcsId = cd.Key;
            ////    TmTcpSocket.Instance.Send(mvc);
            ////}
            if (!cd.Counting)
            {
                Console.WriteLine(TmTimerTool.CurrentTime() + " TmSessionCDItem Colsed. TPeers:{0} ", TmTcpSocket.Instance.TPeers.Count);
                cd.Counting = true;
                if (cd.Parent != null)
                {
                    cd.Parent.Dispose();
                }
                this.Dispose();
            }
            else
            {
                //发送心跳检测（并等待签到，签到入口在TmAsyncTcpSession里）
                TmParameter mvc = TmParameterTool.ToParameter(TenCode.EessionCD, ElevenCode.Login);
                mvc.EcsId = cd.Key;
                TmTcpSocket.Instance.Send(mvc);
            }
            Console.WriteLine(TmTimerTool.CurrentTime() + " CdCount:{0}-{1} ", cd.CdCount, cd.MaxCdCount);
        }
    }
}
