using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using Tumo;

namespace Servers
{
    public class TmServerHelper
    {
        #region instance,dictionary
        private static TmServerHelper _instance;
        public static TmServerHelper Instance { get { return _instance; } }
        public TmServerHelper() { _instance = this; }


        //private Dictionary<string, TPeer> tcpPeers = new Dictionary<string, TPeer>();
        //private List<Socket> lineUpWait = new List<Socket>();
        //public Dictionary<string, TPeer> TcpPeers { get => tcpPeers; set => tcpPeers = value; }
        //public List<Socket> LineUpWait { get => lineUpWait; set => lineUpWait = value; }
        #endregion


        //根据Endpoint得到TPeer     
        public TPeer GetTcpPeer(string endpoint)
        {
            TPeer peer;
            TmAsyncTcpServer.Instance.TPeers.TryGetValue(endpoint, out peer);
            if (peer != null)
            {
                return peer;
            }
            else
            {
                Console.WriteLine(TmTimer.GetCurrentTime() + " 没有找到TPeer，用Endpoint:" + endpoint);
                return null;
            }
        }

        /////获得服务器当前时间
        //public string GetCurrentTime()
        //{
        //    string cuurentTime = "";
        //    cuurentTime = DateTime.Now.ToString("yyyyMMddHHmmss.ffff");
        //    return cuurentTime;
        //}

    }
}
