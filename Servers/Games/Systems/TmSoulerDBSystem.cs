using System;
using System.Collections.Generic;
using Tumo;
namespace Servers
{
    class TmSoulerDBSystem : TmSystem
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
                SetBookers(entity);
                SetTeachers(entity);
            }
        }
        void SetBookers(TmEntity entity)
        {
            TmSession session = entity.GetComponent<TmSession>();
            if (session.bookersChange != TmObjects.Bookers.Count)
            {
                TmParameter response = TmParameterTool.ToJsonParameter(TenCode.Booker, ElevenCode.SetSoulerDBs, ElevenCode.SetSoulerDBs.ToString(), TmObjects.Bookers);
                response.Keys.Add(entity.EcsId);
                TmTcpSocket.Instance.Send(response);
                session.bookersChange = TmObjects.Bookers.Count;
            }
        }
        void SetTeachers(TmEntity entity)
        {
            TmSession session = entity.GetComponent<TmSession>();
            if (session.teachersChange != TmObjects.Teachers.Count)
            {
                TmParameter response = TmParameterTool.ToJsonParameter(TenCode.Teacher, ElevenCode.SetSoulerDBs, ElevenCode.SetSoulerDBs.ToString(), TmObjects.Teachers);
                response.Keys.Add(entity.EcsId);
                TmTcpSocket.Instance.Send(response);
                session.teachersChange = TmObjects.Teachers.Count;
            }
        }

    }

}
