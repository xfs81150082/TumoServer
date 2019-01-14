using ClientExample.Sences.Rolers.Controllers;
using ClientExample.Sences.Rolers.Senders;
using Tumo;
using Tumo.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ClientExample.Sences.Rolers
{
    class TumoRoler : ConnectBase
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
            RolerBase node;
            //根据操作代码（NineCode），从字典中取出处理程序
            Rolers.TryGetValue(mvc.NineCode.ToString(), out node);
            if (node != null)
            {
                node.OnTransferParameter(mvc);
            }
            else
            {
                Console.WriteLine("寻找Roler失败，通过NineCode:" + mvc.NineCode);
            }
        }

        void Registes()
        {
            new RolerInfo();
            new TumoRolerController();
            new TumoRolerSender();
        }

    }
}
