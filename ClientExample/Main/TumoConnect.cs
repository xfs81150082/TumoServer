using ClientExample.Games;
using ClientExample.Logins;
using ClientExample.Sences.Nodes;
using ClientExample.Sences.Rolers;
using Tumo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ClientExample
{
    public class TumoConnect
    {
        public static TumoConnect Instance { get => _instance; }
        private static TumoConnect _instance;
        public Dictionary<string, ConnectBase> Connects = new Dictionary<string, ConnectBase>();
        
        public TumoConnect()
        {
            _instance = this;
            Reisters();
        }

        public void OnTransferParameter(TmRequest mvc)
        {
            //创建一个空的处理程序（Views）
            ConnectBase connect;
            //根据操作代码（EightCode），从字典中取出处理程序
            Connects.TryGetValue(mvc.EightCode.ToString(), out connect);
            if (connect != null)
            {
                connect.OnTransferParameter(mvc);
            }
            else
            {
                Console.WriteLine("寻找connect失败，通过EightCode:" + mvc.EightCode);
            }
        }

        private void Reisters()
        {
            new TumoLogin();
            new TumoRoler();
            new TumoNode();
            new TumoGmae();

        }

    }
}
