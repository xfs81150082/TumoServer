using Tumo;
using Tumo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Servers.Logins.Senders
{
    class TumoLoginSender : LoginBase
    {
        public override string Code => NineCode.Sender.ToString();

        public static TumoLoginSender Instance { get => _instance; }
        private static TumoLoginSender _instance;
        public Dictionary<string, LoginSenderBase> Logins = new Dictionary<string, LoginSenderBase>();

        public TumoLoginSender()
        {
            _instance = this;
            Reisters();
        }

        public override void OnTransferParameter(MvcParameter mvc)
        {
            //创建一个空的处理程序（handler）
            LoginSenderBase controller;
            //根据操作代码（OneCode），从字典中取出处理程序
            Logins.TryGetValue(mvc.TenCode.ToString(), out controller);
            if (controller != null)
            {
                controller.OnTransferParameter(mvc);
            }
            else
            {
                Console.WriteLine("寻找LoginSender失败，通过NineCode:" + mvc.NineCode);
            }
        }

        private void Reisters()
        {
            new UserLogin();
            new EngineerLogin();

        }


    }
}
