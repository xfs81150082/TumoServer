using CommonBase.Eunms;
using CommonBase.Mvc;
using CommonBase.Tools;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;
using Servers.Gates;
using Servers.Sences.Rolers;

namespace Servers.Peers
{
    class PeerHelper
    {
        private static PeerHelper _instance;
        public static PeerHelper Instance { get => _instance; }
        public Dictionary<string, Peer> Peers = new Dictionary<string, Peer>();
        public Dictionary<int, List<Peer>> SyncPeers = new Dictionary<int, List<Peer>>();//更新时对比用的

        public PeerHelper() { _instance = this; }

        //根据Username或Id或Endpoint得到Peer     
        public Peer GetPeer(string endpoint_id_name)
        {
            Peer peer;
            Peers.TryGetValue(endpoint_id_name, out peer);
            if (peer != null)
            {
                return peer;
            }
            else
            {
                foreach (var peer2 in Peers.Values)
                {
                    if (peer2.Player.SoulItem.Id.ToString() == endpoint_id_name)
                    {
                        return peer2;
                    }
                    else if (peer2.User.Username.ToString() == endpoint_id_name)
                    {
                        return peer2;
                    }
                }
            }
            return null;
        }
        //与服务器连接时调用
        public void OnConnected(Peer peer)
        {
            Socket socket = peer.Socket;
            //客户端网络结点号//获取客户端的IP和端口号  
            string remoteEndPoint = socket.RemoteEndPoint.ToString();
            //显示与客户端连接情况
            Console.WriteLine("成功与" + remoteEndPoint + "客户端建立连接！\t\n");
            Peer peer1 = null;
            bool yes1 = Peers.TryGetValue(socket.RemoteEndPoint.ToString(), out peer1);
            if (yes1 != true)
            {
                //peers已经加入字典
                Peers.Add(socket.RemoteEndPoint.ToString(), peer);
                Console.WriteLine(GetCurrentTime() + ":" + "Peer:" + socket.RemoteEndPoint + "...已经加入字典");
            }
            //显示客户端群中的客户端数量
            Console.WriteLine(GetCurrentTime() + ". Peers Count:" + Peers.Count);
        }
        //与服务器断开时调用
        public void OnDisconnect(Peer peer)
        {
            Socket socket = peer.Socket;
            if (Peers.Count > 0)
            {
                Console.WriteLine(GetCurrentTime() + ":" + "一个客户端:已经中断连接");
                Peer peer1 = null;
                bool yes1 = Peers.TryGetValue(socket.RemoteEndPoint.ToString(), out peer1);
                if (yes1)
                {
                    //从peers字典中删除
                    Peers.Remove(socket.RemoteEndPoint.ToString());
                }
            }            
            //显示客户端群中的客户端数量
            Console.WriteLine(GetCurrentTime() + " Peers:" + Peers.Count);
            //删除更新比对的peers字典列表
            if (SyncPeers.Count > 0)
            {
                List<int> list = new List<int>(SyncPeers.Keys);
                for (int i=0;i<list.Count;i++ )
                {
                    if (SyncPeers[list[i]].Contains(peer))
                    {
                        //从peers字典中删除
                        SyncPeers[list[i]].Remove(peer);
                    }
                    if (SyncPeers[list[i]].Count == 0)
                    {
                        SyncPeers.Remove(list[i]);
                    }
                }
            }
            if (RolerInfo.Instance.Players.Count > 0)
            {
                //删除角色字典中的实例Player
                RolerInfo.Instance.Players.Remove(peer.Player.SoulItem.Id);
            }
            //删除掉心跳包群中对应的peer
            MvcParameter mvc = MvcTool.ToParameter(EightCode.Node, NineCode.Handler, TenCode.Engineer, ElevenCode.RemoveHeartBeat);
            mvc.Endpoint = socket.RemoteEndPoint.ToString();
            TumoGate.Instance.OnTransferParameter(mvc);            
            //关闭之前accept出来的和客户端进行通信的套接字
            socket.Close();
        }
        //获得服务器当前时间
        public DateTime GetCurrentTime()
        {
            DateTime cuurentTime = new DateTime();
            cuurentTime = DateTime.Now;
            return cuurentTime;
        }

    }
}
