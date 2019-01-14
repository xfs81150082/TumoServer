using ClientExample.Logins.Controllers;
using ClientExample.Logins.Senders;
using ClientExample;
using Tumo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ClientExample.Logins
{
    class TumoLogin : ConnectBase
    {
        public override string Code => EightCode.Login.ToString();

        public static TumoLogin Instance { get => _instance; }
        private static TumoLogin _instance;
        public Dictionary<string, LoginBase> Logins = new Dictionary<string, LoginBase>();


        public TumoLogin()
        {
            _instance = this;
            Reisters();
        }

        public override void OnTransferParameter(MvcParameter mvc)
        {
            //创建一个空的处理程序（handler）
            LoginBase login;
            //根据操作代码（NineCode），从字典中取出处理程序
            Logins.TryGetValue(mvc.NineCode.ToString(), out login);
            if (login != null)
            {
                login.OnTransferParameter(mvc);
            }
            else
            {
                Console.WriteLine("寻找Logins失败，通过NineCode:" + mvc.NineCode);
            }
        }

        private void Reisters()
        {
            new TumoLoginSender();
            new TumoLoginController();

        }


    }
}
