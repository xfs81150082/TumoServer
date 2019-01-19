﻿using Tumo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Servers.Games
{
    class TumoGame : GateBase
    {
        public override string Code => EightCode.Game.ToString();
        private static TumoGame _instance;
        public static TumoGame Instance { get => _instance; }
        public Dictionary<string, GameBase> Games = new Dictionary<string, GameBase>();

        public TumoGame()
        {
            _instance = this;
            Registes();
        }

        public void Init() { }

        //这个方法用来处理参数Mvc，并让结果给客户端响应（当客户端发起请求时调用）
        public override void OnTransferParameter(TmParameter mvc)
        {
            //创建一个空的处理程序（handler）
            GameBase game;
            //根据操作代码（TenCode），从字典中取出处理程序
            Games.TryGetValue(mvc.NineCode.ToString(), out game);
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