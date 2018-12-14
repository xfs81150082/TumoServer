using Tumo;
using Servers.Gates;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Servers.Chats
{
    class TumoChat : GateBase
    {
        public override string Code => NineCode.Chat.ToString();
        private static TumoChat _instance;
        public static TumoChat Instance { get => _instance; }
        public Dictionary<string, ChatBase> Chats = new Dictionary<string, ChatBase>();

        public TumoChat()
        {
            _instance = this;
            Registes();
        }

        public void Init() { }

        //这个方法用来处理参数Mvc，并让结果给客户端响应（当客户端发起请求时调用）
        public override void OnTransferParameter(MvcParameter mvc)
        {
            //创建一个空的处理程序（handler）
            ChatBase chat;
            //根据操作代码（TenCode），从字典中取出处理程序
            Chats.TryGetValue(mvc.TenCode.ToString(), out chat);
            if (chat != null)
            {
                chat.OnTransferParameter(mvc);
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
