using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Tumo;

namespace Servers
{
    public class TmUserHandler : TmComponent
    {
        public override void TmAwake()
        {
            base.TmAwake();
        }
        public TmUserHandler()
        {
            //OnGetTmUserItemEvent += new TmUserMysql().GetTmUserByName;
            //OnGetTmEngineertemEvent += new TmEngineerMysql().GetItemsByUser;
        }
        public override void TmDispose()
        {
            base.TmDispose();
            //OnGetTmUserItemEvent -= new TmUserMysql().GetTmUserByName;
            //OnGetTmEngineertemEvent += new TmEngineerMysql().GetItemsByUser;
        }
        public override void OnTransferParameter(object obj, TmParameter parameter)
        {
            ElevenCode elevenCode = parameter.ElevenCode;
            switch (elevenCode)
            {
                case (ElevenCode.Login):
                    Console.WriteLine(TmTimerTool.CurrentTime() + " TmUser: " + elevenCode);
                    CheckLoginPassword(parameter);
                    break;
                case (ElevenCode.None):
                    break;
                default:
                    break;
            }
        }
        public TmUser User;
        public List<TmSoulerDB> TmSoulerDbs;
        //public event EventHandler<TmParameter> OnGetTmUserItemEvent;
        //public event EventHandler<TmParameter> OnGetTmEngineertemEvent;
        private void CheckLoginPassword(TmParameter parameter)
        {
            TmUser user1 = TmParameterTool.GetJsonValue<TmUser>(parameter, parameter.ElevenCode.ToString());
            //OnGetTmUserItemEvent(this, parameter);
            new TmUserMysql().GetTmUserByName(this, parameter);
            if (this.User != null)
            {
                if (User.Password == user1.Password)
                {
                    parameter.Parameters.Clear();
                    TmParameterTool.AddJsonParameter(parameter, parameter.ElevenCode.ToString(), this.User);
                    //OnGetTmEngineertemEvent(this, parameter);
                    new TmEngineerMysql().GetItemsByUser(this, parameter);
                    Console.WriteLine(TmTimerTool.CurrentTime() + " this.TmSoulerDbs:" + this.TmSoulerDbs.Count);

                    if (this.TmSoulerDbs != null)
                    {
                        TmParameter response = TmParameterTool.ToJsonParameter<List<TmSoulerDB>>(TenCode.TmUserController, ElevenCode.Login, ElevenCode.Login.ToString(), this.TmSoulerDbs);
                        response.EcsId = parameter.EcsId;
                        TmTcpSocket.Instance.Send(response);
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