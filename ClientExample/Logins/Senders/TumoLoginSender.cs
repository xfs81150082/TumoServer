using Tumo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ClientExample.Logins.Senders
{
    class TumoLoginSender : LoginBase
    {
        public override string Code => NineCode.Sender.ToString();

        public static TumoLoginSender Instance { get => _instance; }
        private static TumoLoginSender _instance;
        public Dictionary<string, LoginSenderBase> Senders = new Dictionary<string, LoginSenderBase>();

        public TumoLoginSender()
        {
            _instance = this;
            Reisters();
        }

        public override void OnTransferParameter(TmRequest mvc)
        {
            //创建一个空的处理程序（handler）
            LoginSenderBase controller;
            //根据操作代码（OneCode），从字典中取出处理程序
            Senders.TryGetValue(mvc.TenCode.ToString(), out controller);
            if (controller != null)
            {
                controller.OnTransferParameter(mvc);
            }
            else
            {
                Console.WriteLine("寻找LoginSender失败，通过TenCode:" + mvc.TenCode);
            }
        }

        private void Reisters()
        {
            new UserLogin();
            new EngineerLogin();

        }


    }
}
