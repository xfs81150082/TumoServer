using Tumo;
using Servers.Gates;
using Servers.Sences.Nodes;
using Servers.Sences.Rolers.Handlers;
using Servers.Sences.Rolers.Mysqlers;
using Servers.Sences.Rolers.Senders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Servers.Sences.Rolers
{
    class TumoRoler : GateBase
    { 
        private static TumoRoler _instance;
        public static TumoRoler Instance { get => _instance; }

        public override string Code => EightCode.Roler.ToString();

        public Dictionary<string, RolerBase> Rolers = new Dictionary<string, RolerBase>();

        public TumoRoler()
        {
            _instance = this;
            Registes();
        }

        public void Init() { }

        //这个方法用来处理参数Mvc，并让结果给客户端响应（当客户端发起请求时调用）
        public override void OnTransferParameter(MvcParameter mvc)
        {
            //创建一个空的处理程序（handler）
            RolerBase roler;
            //根据操作代码（TenCode），从字典中取出处理程序
            Rolers.TryGetValue(mvc.NineCode.ToString(), out roler);
            if (roler != null)
            {
                roler.OnTransferParameter(mvc);
            }
            else
            {
                Console.WriteLine("寻找Roler失败，通过NineCode:" + mvc.NineCode);
            }
        }

        void Registes()
        {
            new RolerInfo();
            new TumoRolerSender();
            new TumoRolerMysql();
            new TumoRolerHandler();
        }

    }
}
