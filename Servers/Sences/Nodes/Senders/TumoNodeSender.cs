using Tumo;
using Servers.Sences.Nodes.Senders.Souls;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Servers.Sences.Nodes.Senders
{
    class TumoNodeSender : NodeBase
    {
        private static TumoNodeSender _instance;
        public static TumoNodeSender Instance { get => _instance; }

        public override string Code => NineCode.Sender.ToString();

        public Dictionary<string, NodeSenderBase> NodeSenders = new Dictionary<string, NodeSenderBase>();

        public TumoNodeSender()
        {
            _instance = this;
            Registes();
        }

        public void Init() { }

        //这个方法用来处理参数Mvc，并让结果给客户端响应（当客户端发起请求时调用）
        public override void OnTransferParameter(TmRequest mvc)
        {
            //创建一个空的处理程序（handler）
            NodeSenderBase sender;
            //根据操作代码（TenCode），从字典中取出处理程序
            NodeSenders.TryGetValue(mvc.TenCode.ToString(), out sender);
            if (sender != null)
            {
                sender.OnTransferParameter(mvc);
            }
            else
            {
                Console.WriteLine("寻找NodeSenders失败，通过TenCode:" + mvc.TenCode);
            }
        }

        void Registes()
        {
            new PeerNodeSender();
            new TeacherSender();
            new BookerSender();
            new EngineerSender();

        }

    }
}
