using ClientExample;
using ClientExample.Sences.Nodes.Controllers;
using ClientExample.Sences.Nodes.Senders;
using Tumo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ClientExample.Sences.Nodes
{
    class TumoNode : ConnectBase
    {
        private static TumoNode _instance;
        public static TumoNode Instance { get => _instance; }

        public override string Code => EightCode.Node.ToString();

        public Dictionary<string, NodeBase> Nodes = new Dictionary<string, NodeBase>();

        public TumoNode()
        {
            _instance = this;
            Registes();
        }

        public void Init() { }

        //这个方法用来处理参数Mvc，并让结果给客户端响应（当客户端发起请求时调用）
        public override void OnTransferParameter(TmRequest mvc)
        {
            //创建一个空的处理程序（handler）
            NodeBase node;
            //根据操作代码（TenCode），从字典中取出处理程序
            Nodes.TryGetValue(mvc.NineCode.ToString(), out node);
            if (node != null)
            {
                node.OnTransferParameter(mvc);
            }
            else
            {
                Console.WriteLine("寻找Node失败，通过NineCode:" + mvc.NineCode);
            }
        }

        void Registes()
        {
            new NodeInfo();
            new NodeHelper();
            new TumoNodeSender();
            new TumoNodeController();

        }

       
    }
}
