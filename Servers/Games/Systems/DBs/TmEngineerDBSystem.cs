using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tumo;
namespace Servers
{
    class TmEngineerDBSystem : TmSystem
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
                SetEngineers(entity);
            }
        }

        #region Engineer
        void SetEngineers(TmEntity entity)
        {
            TmSession session = entity.GetComponent<TmSession>();
            session.Engineers = GetEngineersByMyself(session.Engineer, TmObjects.Engineers);
            session.Engineers.Remove(session.Engineer.Id);
            Console.WriteLine(TmTimerTool.CurrentTime() + " TmSoulerDBSystem-session: Id: " + session.Engineer.Id + " Engineers: " + session.Engineers.Count + "/" + TmObjects.Engineers.Count);
            //Console.WriteLine(TmTimerTool.CurrentTime() + " TmSoulerDBSystem-Engineers: Id: " + session.Engineer.Id + " Engineers: " + TmObjects.Engineers.Count);
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


    }
}