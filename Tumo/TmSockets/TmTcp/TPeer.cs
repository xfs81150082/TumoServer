using Tumo.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;

namespace Tumo
{
    public class TPeer : TmAsyncTcpSession
    {
        public override void OnConnect()
        {
            ///显示与客户端连接
            Console.WriteLine("{0} 客户端{1}连接成功", TmTimerTool.CurrentTime() , Socket.RemoteEndPoint);
            TmAsyncTcpSession tpeer = null;
            bool yes1 = TmOutTcp.Instance.TPeers.TryGetValue(this.EcsId, out tpeer);
            if (yes1 != true)
            {
                ///tpeers已经加入字典
                TmOutTcp.Instance.TPeers.Add(this.EcsId, this);
                Console.WriteLine(TmTimerTool.CurrentTime() + " ComponentId: " + this.EcsId + " 已经加入字典");
            }
            ///显示客户端群中的客户端数量
            Console.WriteLine(TmTimerTool.CurrentTime() + " TPeers Count: " + TmAsyncTcpServer.Instance.TPeers.Count);
        }     
        public override void TmDispose()
        {
            base.TmDispose();
            ///从peers字典中删除
            TmAsyncTcpSession tpeer;
            TmOutTcp.Instance.TPeers.TryGetValue(EcsId, out tpeer);
            if (tpeer != null)
            {
                //删除掉心跳包群中对应的peer
                TmOutTcp.Instance.TPeers.Remove(EcsId);
            }            ///显示客户端群中的客户端数量
            Console.WriteLine(TmTimerTool.CurrentTime() + " 一个客户端:已经中断连接" + " TPeers: " + TmAsyncTcpServer.Instance.TPeers.Count);
        }
    }
}