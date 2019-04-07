using System;
using System.Net.Sockets;
namespace Tumo
{
    public class TmPeer : TmTcpSession
    {
        public override void OnConnect()
        {
            ///显示与客户端连接
            Console.WriteLine("{0} 客户端{1}连接成功", TmTimerTool.CurrentTime() , Socket.RemoteEndPoint);
            TmTcpSession tpeer = null;
            bool yes1 = TmTcpSocket.Instance.TPeers.TryGetValue(this.EcsId, out tpeer);
            if (yes1 != true)
            {
                ///tpeers已经加入字典
                TmTcpSocket.Instance.TPeers.Add(this.EcsId, this);
                Console.WriteLine(TmTimerTool.CurrentTime() + " ComponentId: " + this.EcsId + " 已经加入字典");
            }
            ///显示客户端群中的客户端数量
            Console.WriteLine(TmTimerTool.CurrentTime() + " TPeers Count: " + TmTcpServer.Instance.TPeers.Count);
        }     
        public override void TmDispose()
        {
            base.TmDispose();
            ///从peers字典中删除
            TmTcpSession tpeer;
            TmTcpSocket.Instance.TPeers.TryGetValue(EcsId, out tpeer);
            if (tpeer != null)
            {
                //删除掉心跳包群中对应的peer
                TmTcpSocket.Instance.TPeers.Remove(EcsId);
            }            ///显示客户端群中的客户端数量
            if (this.GetComponent<TmSession>().Engineer != null)
            {
                TmSoulerDB soulerDB;
                TmObjects.Engineers.TryGetValue(this.GetComponent<TmSession>().Engineer.Id, out soulerDB);
                if (soulerDB != null)
                {
                    TmObjects.Engineers.Remove(this.GetComponent<TmSession>().Engineer.Id);
                }
            }
            Console.WriteLine(TmTimerTool.CurrentTime() + " 一个客户端:已经中断连接" + " TPeers: " + TmTcpServer.Instance.TPeers.Count);
            Console.WriteLine(TmTimerTool.CurrentTime() + " 一个角色:已经离线" + " Engineers: " + TmObjects.Engineers.Count);
        }
    }
}