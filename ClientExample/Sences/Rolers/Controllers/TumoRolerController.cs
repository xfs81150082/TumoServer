using ClientExample.Sences.Rolers;
using Tumo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ClientExample.Sences.Rolers.Controllers
{
    class TumoRolerController : RolerBase
    {
        private static TumoRolerController _instance;
        public static TumoRolerController Instance { get => _instance; }

        public override string Code => NineCode.Controller.ToString();

        public Dictionary<string, RolerControllerBase> Controllers = new Dictionary<string, RolerControllerBase>();

        public TumoRolerController()
        {
            _instance = this;
            Registes();
        }

        public void Init() { }

        //这个方法用来处理参数Mvc，并让结果给客户端响应（当客户端发起请求时调用）
        public override void OnTransferParameter(TmRequest mvc)
        {
            //创建一个空的处理程序（handler）
            RolerControllerBase node;
            //根据操作代码（TenCode），从字典中取出处理程序
            Controllers.TryGetValue(mvc.TenCode.ToString(), out node);
            if (node != null)
            {
                node.OnTransferParameter(mvc);
            }
            else
            {
                Console.WriteLine("寻找MeasurementNode失败，通过TenCode:" + mvc.TenCode);
            }
        }

        void Registes()
        {
            new BookerRoler();
            new TeacherRoler();
            new EngineerRoler();

        }

       
    }
}
