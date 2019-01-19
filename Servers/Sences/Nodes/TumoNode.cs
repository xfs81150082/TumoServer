using Tumo;
using Servers.Sences.Nodes.Handlers;
using Servers.Sences.Nodes.Mysqlers;
using Servers.Sences.Nodes.Senders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Servers.Sences.Nodes
{
    class TumoNode : GateBase
    {
        private static TumoNode _instance;
        public static TumoNode Instance { get => _instance; }

        public override string Code => EightCode.Node.ToString();

        public Dictionary<string, NodeBase> MeasurementNodes = new Dictionary<string, NodeBase>();

        public TumoNode()
        {
            _instance = this;
            Registes();
        }

        public void Init() { }

        //这个方法用来处理参数Mvc，并让结果给客户端响应（当客户端发起请求时调用）
        public override void OnTransferParameter(TmParameter mvc)
        {
            //创建一个空的处理程序（handler）
            NodeBase node;
            //根据操作代码（NineCode），从字典中取出处理程序
            MeasurementNodes.TryGetValue(mvc.NineCode.ToString(), out node);
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
            new NodeEvent();
            new NodeInfo();
            new NodeHelper();
            new TumoNodeHandler();
            new TumoNodeMysql();
            new TumoNodeSender();
        }

       
    }
}
