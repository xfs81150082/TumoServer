﻿using Tumo;
using Servers.Chats;
using Servers.Games;
using Servers.Logins;
using Servers.Sences.Nodes;
using Servers.Sences.Rolers;
using Servers.Wars;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Servers
{
    public class TmGate : TmEntity
    {
        private static TmGate _instance;
        public static TmGate Instance { get => _instance; }
        public Dictionary<string, GateBase> Gates = new Dictionary<string, GateBase>();
        public TmGate()
        {
            _instance = this;
            RegisteHandlers();
        }

        public void Init() { }

        //这个方法用来处理TPeer参数Mvc，并让结果给客户端响应（当客户端发起请求时调用）
        public override void OnTransferParameter(TmParameter parameter)
        {
            //创建一个空的处理程序（gate）
            TmComponent gate;
            //根据操作代码（EightCode），从字典中取出处理程序
            Components.TryGetValue(parameter.NineCode.ToString(), out gate);
            if (gate != null)
            {
                gate.OnTransferParameter(parameter);
            }
            else
            {
                Console.WriteLine("寻找Gate失败，通过EightCode:" + parameter.EightCode);
            }
        }
   
        void RegisteHandlers()
        {
            new TumoLogin();
            new TumoRoler();
            new TumoNode();
            //new TumoGame();
            //new TumoWar();
            //new TumoChat();
        }

    }
}
