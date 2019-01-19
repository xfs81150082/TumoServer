using Tumo;
using Servers.Sences.Nodes.Senders.Souls;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Servers.Sences.Rolers.Senders
{
    class TumoRolerSender : RolerBase
    {
        private static TumoRolerSender _instance;
        public static TumoRolerSender Instance { get => _instance; }

        public override string Code => NineCode.Sender.ToString();

        public Dictionary<string, RolerSenderBase> RolerSenders = new Dictionary<string, RolerSenderBase>();

        public TumoRolerSender()
        {
            _instance = this;
            Registes();
        }

        public void Init() { }

        //这个方法用来处理参数Mvc，并让结果给客户端响应（当客户端发起请求时调用）
        public override void OnTransferParameter(TmParameter mvc)
        {
            //创建一个空的处理程序（handler）
            RolerSenderBase sender;
            //根据操作代码（TenCode），从字典中取出处理程序
            RolerSenders.TryGetValue(mvc.TenCode.ToString(), out sender);
            if (sender != null)
            {
                sender.OnTransferParameter(mvc);
            }
            else
            {
                Console.WriteLine("寻找RolerSenders失败，通过TenCode:" + mvc.TenCode);
            }
        }

        void Registes()
        {
            new EngineerSender();
            new BookerSender();
            new TeacherSender();
        }

       

    }
}
