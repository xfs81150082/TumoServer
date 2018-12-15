using ClientExample;
using Tumo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ClientExample.Games.Controllers
{
    class TumoGameController : GameBase
    {
        public override string Code => NineCode.Game.ToString();

        public static TumoGameController Instance { get => _instance; }
        private static TumoGameController _instance;
        public Dictionary<string, GameControllerBase> Controllers = new Dictionary<string, GameControllerBase>();


        public TumoGameController()
        {
            _instance = this;
            Reisters();
        }

        public override void OnTransferParameter(MvcParameter mvc)
        {
            //创建一个空的处理程序（handler）
            GameControllerBase controller;
            //根据操作代码（OneCode），从字典中取出处理程序
            Controllers.TryGetValue(mvc.TenCode.ToString(), out controller);
            if (controller != null)
            {
                controller.OnTransferParameter(mvc);
            }
            else
            {
                Console.WriteLine("寻找Games失败，通过NineCode:" + mvc.NineCode);
            }
        }

        private void Reisters()
        {
            new EngineerGame();
            new BookerGame();

        }


    }
}
