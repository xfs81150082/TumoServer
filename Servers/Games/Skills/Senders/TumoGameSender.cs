using Tumo;
using Servers.Games;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Servers.Games.Senders.Games
{
    class TumoGameSender : GameBase
    {
        public override string Code => NineCode.Game.ToString();

        public static TumoGameSender Instance { get => _instance; }
        private static TumoGameSender _instance;
        public Dictionary<string, GameSenderBase> GameSenders = new Dictionary<string, GameSenderBase>();

        public TumoGameSender()
        {
            _instance = this;
            Reisters();
        }

        public override void OnTransferParameter(TmParameter mvc)
        {
            //创建一个空的处理程序（handler）
            GameSenderBase controller;
            //根据操作代码（OneCode），从字典中取出处理程序
            GameSenders.TryGetValue(mvc.TenCode.ToString(), out controller);
            if (controller != null)
            {
                controller.OnTransferParameter(mvc);
            }
            else
            {
                Console.WriteLine("寻找LoginSender失败，通过NineCode:" + mvc.NineCode);
            }
        }

        private void Reisters()
        {
            new BookerGame();
            new EngineerGame();

        }


    }
}
