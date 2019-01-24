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
                case (ElevenCode.UserLogin):
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
            Console.WriteLine(TmTimerTool.CurrentTime() + " to TmUserHandler 30 " + parameter.ElevenCode.ToString());
            string name = TmParameterTool.GetValue<string>(parameter, "Username");
            string word = TmParameterTool.GetValue<string>(parameter, "Password");
            Console.WriteLine(TmTimerTool.CurrentTime() + " Username:" + name + " Password:" + word);
            TmMysqlHandlers.Instance.GetComponent<TmUserMysql>().OnTransferParameter(this, parameter);
            Console.WriteLine(TmTimerTool.CurrentTime() + " this.User:" + this.User.Username + " this.User:" + this.User.Password + " this.User.Phone:" + this.User.Phone);
            if (this.User != null)
            {
                if (User.Password == word)
                {
                    TmParameterTool.AddParameter(parameter, parameter.ElevenCode.ToString(), this.User.Id);
                    Parent.GetComponent<TmEngineerHandler>().OnTransferParameter(this, parameter);                   
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