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
        public TPeer() { }
        public override void TmAwake()  {    }
        public override void TmUpdate()  {    }
        public override void OnTransferParameter(string mvcString)
        {
            ///将字符串string,用json反序列化转换成MvcParameter参数
            MvcParameter mvc = MvcTool.ToObject<MvcParameter>(mvcString);
            mvc.EcsId = this.EcsId;
            if (mvc.ElevenCode == ElevenCode.HeartBeat)
            {
                TmAsyncTcpServer.Instance.CoolDownItemSignIn(mvc);
            }
            else if (mvc.ElevenCode == ElevenCode.RemoveHeartBeat)
            {
                TmAsyncTcpServer.Instance.RemoveCoolDownItem(mvc);
            }
            else
            {
                TmAsyncTcpServer.Instance.RecvParameters.Enqueue(mvc);
            }
        }
        public override void OnConnect()
        {
            ///显示与客户端连接
            Console.WriteLine("{0} 客户端{1}连接成功", TmTimer.GetCurrentTime() , Socket.RemoteEndPoint);
            new TmServerCDItem(this.EcsId);
            TPeer tpeer = null;
            bool yes1 = TmAsyncTcpServer.Instance.TPeers.TryGetValue(this.EcsId, out tpeer);
            if (yes1 != true)
            {
                ///tpeers已经加入字典
                TmAsyncTcpServer.Instance.TPeers.Add(this.EcsId, this);
                Console.WriteLine(TmTimer.GetCurrentTime() + " ComponentId: " + this.EcsId + " 已经加入字典");
            }
            ///显示客户端群中的客户端数量
            Console.WriteLine(TmTimer.GetCurrentTime() + " TPeers Count: " + TmAsyncTcpServer.Instance.TPeers.Count);
        }
        public override void OnDisconnect()
        {
            ///关闭PeerCD
            MvcParameter mvc = MvcTool.ToParameter(EightCode.Node, NineCode.Handler, TenCode.Engineer, ElevenCode.RemoveHeartBeat);
            mvc.EcsId = this.EcsId;
            TmAsyncTcpServer.Instance.RecvParameters.Enqueue(mvc);
            if (TmAsyncTcpServer.Instance.TPeers.Count > 0)
            {
                TPeer temSession = null;
                bool yes1 = TmAsyncTcpServer.Instance.TPeers.TryGetValue(this.EcsId, out temSession);
                if (yes1)
                {
                    ///从peers字典中删除
                    TmAsyncTcpServer.Instance.TPeers.Remove(this.EcsId);
                    Close();
                }
                Console.WriteLine(TmTimer.GetCurrentTime() + " 一个客户端:已经中断连接");
            }
            ///显示客户端群中的客户端数量
            Console.WriteLine(TmTimer.GetCurrentTime() + " TPeers Count: " + TmAsyncTcpServer.Instance.TPeers.Count);
            if (isClose == false)
            {
                isClose = true;
                ///关闭之前先Shutdown
                Socket.Shutdown(SocketShutdown.Both);
                Socket.Close();
                Socket = null;
                IsRunning = false;
            }
        }

    }
}