using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Tumo;

namespace Servers
{
    class TmUserHandler : TmComponent
    {
        public override void OnTransferParameter(object obj, TmParameter parameter)
        {
            ElevenCode elevenCode = parameter.ElevenCode;
            switch (elevenCode)
            {
                case (ElevenCode.Login):
                    Console.WriteLine(TmTimerTool.CurrentTime() + " TmUser: " + elevenCode);
                    CheckUserLoginPassword(parameter);
                    break;
                case (ElevenCode.None):
                    break;
                default:
                    break;
            }
        }
        internal TmUser User;
        internal List<TmSoulerDB> Engineers;
        private void CheckUserLoginPassword(TmParameter parameter)
        {
            TmUser user1 = TmParameterTool.GetJsonValue<TmUser>(parameter, parameter.ElevenCode.ToString());
            TmMysqlHandler.Instance.GetComponent<TmUserMysql>().OnTransferParameter(this, parameter);
            Console.WriteLine(TmTimerTool.CurrentTime() + " user1:" + user1.Username + " user1:" + this.User.Password);
            Console.WriteLine(TmTimerTool.CurrentTime() + " this.User:" + user1.Username + " this.User:" + this.User.Password + " this.User.Phone:" + this.User.Phone);
            if (this.User != null)
            {
                if (User.Password == user1.Password)
                {
                    TmParameterTool.AddParameter(parameter, parameter.ElevenCode.ToString(), this.User);
                    TmMysqlHandler.Instance.GetComponent<TmEngineerMysql>().OnTransferParameter(this, parameter);
                    Console.WriteLine(TmTimerTool.CurrentTime() + " this.Engineers:" + this.Engineers.Count);
                    if (this.Engineers != null)
                    {
                        TmParameter response = TmParameterTool.ToJsonParameter<List<TmSoulerDB>>(TenCode.TmUserController, ElevenCode.Login, ElevenCode.Login.ToString(), this.Engineers);
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