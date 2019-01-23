using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Tumo;

namespace Servers
{
     class TmUserHandler : TmComponent
    {
        public override void TmAwake()
        {
            base.TmAwake();
        }
        public TmUserHandler()
        {
        }
        public override void TmDispose()
        {
            base.TmDispose();
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
        private void CheckLoginPassword(TmParameter parameter)
        {
            TmUser user1 = TmParameterTool.GetJsonValue<TmUser>(parameter, parameter.ElevenCode.ToString());
            (TmMysqlHandler.Instance.GetComponent<TmUserMysql>() as TmUserMysql).GetTmUserByName(this, parameter);
            Console.WriteLine(TmTimerTool.CurrentTime() + " this.User:" + this.User.Phone);
            if (this.User != null)
            {
                if (User.Password == user1.Password)
                {
                    parameter.Parameters.Clear();
                    TmParameterTool.AddJsonParameter(parameter, parameter.ElevenCode.ToString(), this.User);
                    (TmMysqlHandler.Instance.GetComponent<TmEngineerMysql>() as TmEngineerMysql).GetItemsByUser(this, parameter);
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