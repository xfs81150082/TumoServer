using System;
using UnityEngine;

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
                CheckSession(entity);
            }
        }
        void CheckSession(TmEntity entity)
        {
            TmCoolDown cd = entity.GetComponent<TmCoolDown>();
            if (!cd.Counting)
            {
                entity.Dispose();
                if (!cd.IsServer && TmTcpSocket.Instance.TClient == null)
                {
                    TmTcpSocket.Instance.StartConnect();
                }
            }
            else
            {
                //发送心跳检测（并等待签到，签到入口在TmTcpSession里，双向发向即：客户端向服务端发送，服务端向客户端发送）
                TmParameter mvc = TmParameterTool.ToParameter(TenCode.EessionCD, ElevenCode.Login);
                mvc.Keys.Add(entity.EcsId);
                TmTcpSocket.Instance.Send(mvc);
            }
            Console.WriteLine(TmTimerTool.CurrentTime() + " CdCount:{0}-{1} ", cd.CdCount, cd.MaxCdCount);
            Debug.Log(TmTimerTool.CurrentTime() + " CdCount:" + cd.CdCount + "-" + cd.MaxCdCount);
        }
    }
}
