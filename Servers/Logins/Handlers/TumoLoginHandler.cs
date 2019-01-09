using Tumo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Servers.Logins.Handlers
{
    class TumoLoginHandler : LoginBase
    {
        public override string Code => NineCode.Handler.ToString();
        private static TumoLoginHandler _instance;
        public static TumoLoginHandler Instance { get => _instance; }
        public Dictionary<string, HandlerBase> Handlers = new Dictionary<string, HandlerBase>();

        public TumoLoginHandler()
        {
            _instance = this;
            Registes();
        }

        public void Init() { }

        //这个方法用来处理参数Mvc，并让结果给客户端响应（当客户端发起请求时调用）
        public override void OnTransferParameter(MvcParameter mvc)
        {
            //创建一个空的处理程序（handler）
            HandlerBase handler;
            //根据操作代码（TenCode），从字典中取出处理程序
            Handlers.TryGetValue(mvc.TenCode.ToString(), out handler);
            if (handler != null)
            {
                handler.OnTransferParameter(mvc);
            }
            else
            {
                Console.WriteLine("寻找Handler失败，通过TenCode:" + mvc.TenCode);
            }
        }

        void Registes()
        {
            new EngineerLogin();
            new RegisterLogin();
        }
    }
}
