using Tumo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Servers.Sences.Rolers.Handlers
{
    class TumoRolerHandler : RolerBase
    {
        private static TumoRolerHandler _instance;
        public static TumoRolerHandler Instance { get => _instance; }

        public override string Code => NineCode.Handler.ToString();

        public Dictionary<string, RolerHandlerBase> RolerHandlers = new Dictionary<string, RolerHandlerBase>();

        public TumoRolerHandler()
        {
            _instance = this;
            Registes();
        }

        public void Init() { }

        //这个方法用来处理参数Mvc，并让结果给客户端响应（当客户端发起请求时调用）
        public override void OnTransferParameter(TmRequest mvc)
        {
            //创建一个空的处理程序（handler）
            RolerHandlerBase node;
            //根据操作代码（TenCode），从字典中取出处理程序
            RolerHandlers.TryGetValue(mvc.TenCode.ToString(), out node);
            if (node != null)
            {
                node.OnTransferParameter(mvc);
            }
            else
            {
                Console.WriteLine("寻找RolerHandler失败，通过TenCode:" + mvc.TenCode);
            }
        }

        void Registes()
        {
            new MonsterHandler();
            new NpcerHandler();
            new PlayerHandler();

        }

       
    }
}
