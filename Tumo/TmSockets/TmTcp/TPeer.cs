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
        private bool isClose { get; set; } = false;
        public TPeer()
        {
            CD = new TmServerCDItem();
            CD.Key = EcsId;
        }
        public override void OnTransferParameter(string mvcString)
        {
            ///将字符串string,用json反序列化转换成MvcParameter参数
            TmParameter mvc = TmJson.ToObject<TmParameter>(mvcString);
            mvc.EcsId = this.EcsId;
            if (mvc.ElevenCode == ElevenCode.HeartBeat)
            {
                CD.CdCount = 0;
            }           
            else
            {
                TmAsyncTcpServer.Instance.RecvParameters.Enqueue(mvc);
            }
        }
        public override void OnConnect()
        {
            ///显示与客户端连接
            Console.WriteLine("{0} 客户端{1}连接成功", TmTimerTool.GetCurrentTime() , Socket.RemoteEndPoint);
            TPeer tpeer = null;
            bool yes1 = TmAsyncTcpServer.Instance.TPeers.TryGetValue(this.EcsId, out tpeer);
            if (yes1 != true)
            {
                ///tpeers已经加入字典
                TmAsyncTcpServer.Instance.TPeers.Add(this.EcsId, this);
                Console.WriteLine(TmTimerTool.GetCurrentTime() + " ComponentId: " + this.EcsId + " 已经加入字典");
            }
            ///显示客户端群中的客户端数量
            Console.WriteLine(TmTimerTool.GetCurrentTime() + " TPeers Count: " + TmAsyncTcpServer.Instance.TPeers.Count);
        }
     
        public override void TmDispose()
        {
            base.TmDispose();
            ///从peers字典中删除
            TPeer tpeer;
            TmAsyncTcpServer.Instance.TPeers.TryGetValue(EcsId, out tpeer);
            if (tpeer != null)
            {
                //删除掉心跳包群中对应的peer
                TmAsyncTcpServer.Instance.TPeers.Remove(EcsId);
            }            ///显示客户端群中的客户端数量
            Console.WriteLine(TmTimerTool.GetCurrentTime() + " 一个客户端:已经中断连接" + " TPeers: " + TmAsyncTcpServer.Instance.TPeers.Count);
        }

    }
}