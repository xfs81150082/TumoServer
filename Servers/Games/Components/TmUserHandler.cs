using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Tumo;

namespace Servers
{
    public class TmUserHandler : TmComponent
    {
        public override void OnTransferParameter(TmParameter parameter)
        {
            ElevenCode elevenCode = parameter.ElevenCode;
            switch (elevenCode)
            {
                case (ElevenCode.Login):
                    Console.WriteLine(TmTimerTool.CurrentTime() + " TmUser: " + elevenCode);
                    CheckLoginPassword(parameter);
                    break;
            }
        }

        public TmUser User;
        public List<TmSoulerDB> TmSoulerDbs;
        public static event EventHandler<TmParameter> OnGetTmUserItemEvent;
        public static event EventHandler<TmParameter> OnGetTmEngineertemEvent;

        private void CheckLoginPassword(TmParameter parameter)
        {
            TmUser user1 = TmParameterTool.GetJsonValue<TmUser>(parameter, parameter.ElevenCode.ToString());
            OnGetTmUserItemEvent(this, parameter);
            if (this.User != null)
            {
                if (User.Password == user1.Password)
                {
                    parameter.Parameters.Clear();
                    TmParameterTool.AddJsonParameter(parameter, parameter.ElevenCode.ToString(), this.User);
                    OnGetTmEngineertemEvent(this, parameter);

                    Console.WriteLine(TmTimerTool.CurrentTime() + " 41this.TmSoulerDbs:" + this.TmSoulerDbs.Count);

                    if (this.TmSoulerDbs != null)
                    {
                        TmParameter response = TmParameterTool.ToJsonParameter<List<TmSoulerDB>>(TenCode.TmUserController, ElevenCode.Login, ElevenCode.Login.ToString(), this.TmSoulerDbs);
                        response.EcsId = parameter.EcsId;
                        TmNetTcp.Instance.Send(response);
                    }
                }
                else
                {
                    Console.WriteLine("密码不正确");
                }
            }
            else
            {
                Console.WriteLine("帐号不存在");
            }
        }




    }
}
