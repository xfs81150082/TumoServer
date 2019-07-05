using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Tumo;
namespace Servers
{
    class TmBookerDBSystem : TmSystem
    {
        public override void TmAwake()
        {
            ValTime = 40000;
            AddComponent(new TmSession());
        }
        public override void TmUpdate()
        {
            foreach (TmEntity entity in GetTmEntities())
            {
                SetBookers(entity);
            }
        }
        
        #region Bookers 每4秒刷新一下，如果死亡重新生成，否则不变
        void SetBookers(TmEntity entity)
        {
            TmSession session = entity.GetComponent<TmSession>();
            if (TmObjects.Bookers.Count > 0 && session.IsLogin)
            {
                TmParameter response = TmParameterTool.ToJsonParameter(TenCode.Booker, ElevenCode.SetSoulerDBs, ElevenCode.SetSoulerDBs.ToString(), TmObjects.Bookers);
                response.Keys.Add(entity.EcsId);
                TmTcpSocket.Instance.Send(response);
                Console.WriteLine(TmTimerTool.CurrentTime() + " TmBookerDBSystem-Bookers: " + TmObjects.Bookers.Count);
            }
        }
        #endregion

    }
}
