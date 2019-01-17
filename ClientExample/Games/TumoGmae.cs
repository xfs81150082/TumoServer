using ClientExample.Games.Controllers;
using ClientExample;
using Tumo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ClientExample.Games
{
    class TumoGmae : ConnectBase
    {
        public override string Code => EightCode.Game.ToString();

        public static TumoGmae Instance { get => _instance; }
        private static TumoGmae _instance;
        public Dictionary<string, GameBase> Games = new Dictionary<string, GameBase>();


        public TumoGmae()
        {
            _instance = this;
            Reisters();
        }

        public override void OnTransferParameter(TmRequest mvc)
        {
            //创建一个空的处理程序（handler）
            GameBase controller;
            //根据操作代码（NineCode），从字典中取出处理程序
            Games.TryGetValue(mvc.NineCode.ToString(), out controller);
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
            new TumoGameController();

        }


    }
}
