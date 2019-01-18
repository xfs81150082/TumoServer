using Tumo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Servers.Games.Handlers
{
    class TumoGameHandler : GameBase
    {
        public override string Code => NineCode.Game.ToString();
        private static TumoGameHandler _instance;
        public static TumoGameHandler Instance { get => _instance; }
        public Dictionary<string, GameHandlerBase> Handlers = new Dictionary<string, GameHandlerBase>();

        public TumoGameHandler()
        {
            _instance = this;
            Registes();
        }

        public void Init() { }

        //这个方法用来处理参数Mvc，并让结果给客户端响应（当客户端发起请求时调用）
        public override void OnTransferParameter(TmRequest mvc)
        {
            //创建一个空的处理程序（handler）
            GameHandlerBase game;
            //根据操作代码（TenCode），从字典中取出处理程序
            Handlers.TryGetValue(mvc.TenCode.ToString(), out game);
            if (game != null)
            {
                game.OnTransferParameter(mvc);
            }
            else
            {
                Console.WriteLine("寻找Handler失败，通过TenCode:" + mvc.TenCode);
            }
        }

        void Registes()
        {
            //new EngineerGame();

        }
    }
}
