using System;
using System.Collections.Generic;
using Tumo;
namespace Servers
{
    class TmSoulerDBSystem : TmSystem
    {
        //public override void TmAwake()
        //{
        //    ValTime = 4000;
        //    AddComponent(new TmSession());
        //}
        //public override void TmUpdate()
        //{
        //    foreach (TmEntity entity in GetTmEntities())
        //    {
        //        SetEngineers(entity);
        //        SetBookers(entity);
        //        SetTeachers(entity);
        //    }
        //}

        #region Engineer
        void SetEngineers(TmEntity entity)
        {
            TmSession session = entity.GetComponent<TmSession>();
            session.Engineers = GetEngineersByMyself(session.Engineer, TmObjects.Engineers);
            session.Engineers.Remove(session.Engineer.Id);
            Console.WriteLine(TmTimerTool.CurrentTime() + " TmSoulerDBSystem-session.Engineers: Id: " + session.Engineer.Id +" Count: "+ session.Engineers.Count);
            Console.WriteLine(TmTimerTool.CurrentTime() + " TmSoulerDBSystem-TmObjects.Engineers: Id: " + session.Engineer.Id + " TmObjects.Engineers.Count: " + TmObjects.Engineers.Count);
            if (session.engineersChange != session.Engineers.Count && session.IsLogin)
            {
                TmParameter response = TmParameterTool.ToJsonParameter(TenCode.Engineer, ElevenCode.SetSoulerDBs, ElevenCode.SetSoulerDBs.ToString(), session.Engineers);
                response.Keys.Add(entity.EcsId);
                TmTcpSocket.Instance.Send(response);
                session.engineersChange = session.Engineers.Count;
            }
        }
        Dictionary<int, TmSoulerDB> GetEngineersByMyself(TmSoulerDB soulerDB, Dictionary<int, TmSoulerDB> soulerDBs)
        {
            Dictionary<int, TmSoulerDB> dbs = new Dictionary<int, TmSoulerDB>();
            List<TmSoulerDB> list = new List<TmSoulerDB>(soulerDBs.Values);
            for (int i = 0; i < list.Count; i++)
            {
                double xx = Math.Abs(soulerDB.px - list[i].px);
                double zz = Math.Abs(soulerDB.pz - list[i].pz);
                if (xx < 100 && zz < 100)
                {
                    dbs.Add(list[i].Id, list[i]);
                }
            }

            dbs.Remove(soulerDB.Id);
            return dbs;
        }
        #endregion

        #region Bookers + Teachers 每4秒刷新一下，如果死亡重新生成，否则不变
        void SetBookers(TmEntity entity)
        {
            TmSession session = entity.GetComponent<TmSession>();
            if (TmObjects.Bookers.Count > 0 && session.IsLogin)
            {
                TmParameter response = TmParameterTool.ToJsonParameter(TenCode.Booker, ElevenCode.SetSoulerDBs, ElevenCode.SetSoulerDBs.ToString(), TmObjects.Bookers);
                response.Keys.Add(entity.EcsId);
                TmTcpSocket.Instance.Send(response);
            }
        }
        void SetTeachers(TmEntity entity)
        {
            TmSession session = entity.GetComponent<TmSession>();
            if (TmObjects.Teachers.Count > 0 && session.IsLogin)
            {
                TmParameter response = TmParameterTool.ToJsonParameter(TenCode.Teacher, ElevenCode.SetSoulerDBs, ElevenCode.SetSoulerDBs.ToString(), TmObjects.Teachers);
                response.Keys.Add(entity.EcsId);
                TmTcpSocket.Instance.Send(response);
            }
        }
        #endregion

        #region old : Bookers + Teachers , 一次性给客户端
        //void SetBookers(TmEntity entity)
        //{
        //    TmSession session = entity.GetComponent<TmSession>();
        //    if (session.bookersChange != TmObjects.Bookers.Count && TmObjects.Bookers.Count > 0 && session.IsLogin)
        //    {
        //        TmParameter response = TmParameterTool.ToJsonParameter(TenCode.Booker, ElevenCode.SetSoulerDBs, ElevenCode.SetSoulerDBs.ToString(), TmObjects.Bookers);
        //        response.Keys.Add(entity.EcsId);
        //        TmTcpSocket.Instance.Send(response);
        //        session.bookersChange = TmObjects.Bookers.Count;
        //    }
        //}
        //void SetTeachers(TmEntity entity)
        //{
        //    TmSession session = entity.GetComponent<TmSession>();
        //    if (session.teachersChange != TmObjects.Teachers.Count && TmObjects.Teachers.Count > 0 && session.IsLogin)
        //    {
        //        TmParameter response = TmParameterTool.ToJsonParameter(TenCode.Teacher, ElevenCode.SetSoulerDBs, ElevenCode.SetSoulerDBs.ToString(), TmObjects.Teachers);
        //        response.Keys.Add(entity.EcsId);
        //        TmTcpSocket.Instance.Send(response);
        //        session.teachersChange = TmObjects.Teachers.Count;
        //    }
        //}
        #endregion

    }
}