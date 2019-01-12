using Tumo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Servers.Wars
{
    class TumoWar : GateBase
    {
        public override string Code => NineCode.War.ToString();
        private static TumoWar _instance;
        public static TumoWar Instance { get => _instance; }
        public Dictionary<string, WarBase> Wars = new Dictionary<string, WarBase>();

        public TumoWar()
        {
            _instance = this;
            Registes();
        }

        public void Init() { }

        //这个方法用来处理参数Mvc，并让结果给客户端响应（当客户端发起请求时调用）
        public override void OnTransferParameter(MvcParameter mvc)
        {
            //创建一个空的处理程序（handler）
            WarBase war;
            //根据操作代码（TenCode），从字典中取出处理程序
            Wars.TryGetValue(mvc.TenCode.ToString(), out war);
            if (war != null)
            {
                war.OnTransferParameter(mvc);
            }
            else
            {
                Console.WriteLine("寻找Handler失败，通过TenCode:" + mvc.TenCode);
            }
        }

        void Registes()
        {
    


        }
    }
}
