using Tumo;
using Servers.Gates;
using Servers.Logins.Handlers;
using Servers.Logins.Mysqlers;
using Servers.Logins.Senders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Servers.Logins
{
    class TumoLogin : GateBase
    {
        public override string Code => EightCode.Login.ToString();
        private static TumoLogin _instance;
        public static TumoLogin Instance { get => _instance; }
        public Dictionary<string, LoginBase> Logins = new Dictionary<string, LoginBase>();

        public TumoLogin()
        {
            _instance = this;
            Registes();
        }
        public override void OnTransferParameter(MvcParameter mvc)
        {
            //创建一个空的处理程序（handler）
            LoginBase user;
            //根据操作代码（TenCode），从字典中取出处理程序
            Logins.TryGetValue(mvc.NineCode.ToString(), out user);
            if (user != null)
            {
                user.OnTransferParameter(mvc);
            }
            else
            {
                Console.WriteLine("寻找Login失败，通过NineCode:" + mvc.NineCode);
            }
        }

        void Registes()
        {
            new TumoLoginSender();
            new TumoLoginMysql();
            new TumoLoginHandler();

        }

    }
}
