using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tumo;
namespace Servers
{
    class TmSkillDBSystem : TmSystem
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
                SetSkillDBs(entity);
            }
        }
        void SetSkillDBs(TmEntity entity)
        {
            TmSession session = entity.GetComponent<TmSession>();
            if (session.skillsChange != session.SkillDBs.Count && session.SkillDBs.Count > 0 && session.IsLogin)
            {
                TmParameter response = TmParameterTool.ToJsonParameter(TenCode.Ability, ElevenCode.SetSkillDBs, ElevenCode.SetSkillDBs.ToString(), session.SkillDBs);
                response.Keys.Add(entity.EcsId);
                TmTcpSocket.Instance.Send(response);
                session.skillsChange = session.SkillDBs.Count;
                Console.WriteLine(TmTimerTool.CurrentTime() + " TmSkillDBSystem-session.SkillDBs: " + session.SkillDBs.Count);
            }
        }


    }
}
