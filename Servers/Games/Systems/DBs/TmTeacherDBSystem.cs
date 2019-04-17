using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Tumo;
namespace Servers
{
    class TmTeacherDBSystem : TmSystem
    {
        public override void TmAwake()
        {
            ValTime = 4000;
            AddComponent(new TmSession());
        }
        public override void TmUpdate()
        {
            foreach (TmEntity entity in GetTmEntities())
            {
                SetTeachers(entity);
            }
        }
        
        #region Teachers 每4秒刷新一下，如果死亡重新生成，否则不变      
        void SetTeachers(TmEntity entity)
        {
            TmSession session = entity.GetComponent<TmSession>();
            if (TmObjects.Teachers.Count > 0 && session.IsLogin)
            {
                TmParameter response = TmParameterTool.ToJsonParameter(TenCode.Teacher, ElevenCode.SetSoulerDBs, ElevenCode.SetSoulerDBs.ToString(), TmObjects.Teachers);
                response.Keys.Add(entity.EcsId);
                TmTcpSocket.Instance.Send(response);
                Console.WriteLine(TmTimerTool.CurrentTime() + " TmTeacherDBSystem-Teachers: " + TmObjects.Teachers.Count);
            }
        }
        #endregion

    }
}
