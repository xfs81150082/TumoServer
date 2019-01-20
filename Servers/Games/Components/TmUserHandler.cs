using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
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
        public static event EventHandler<TmParameter> OnGetTmUserItemEvent;

        private void CheckLoginPassword(TmParameter parameter)
        {
            OnGetTmUserItemEvent(this, parameter);
            Console.WriteLine(TmTimerTool.CurrentTime() + "parameter:" + parameter.Username);
            Console.WriteLine(TmTimerTool.CurrentTime() + " User:" + this.User.Username);
            TmUser user2 = this.User;
            if (user2 != null)
            {
                if (user2.Password == parameter.Password)
                {
                    parameter.TenCode = TenCode.TmEngineer;
                    parameter.ElevenCode = ElevenCode.Login;
                    parameter.Parameters.Add(parameter.ElevenCode.ToString(), user2);



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
