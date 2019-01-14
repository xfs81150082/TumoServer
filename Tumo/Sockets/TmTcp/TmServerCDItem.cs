using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Tumo
{
    public class TmServerCDItem : TmCoolDown
    {
        public TPeer Peer { get; set; }
        public override void TmAwake()
        {
            ValTime = 4000;
        }    
        public TmServerCDItem(TPeer peer)
        {
            this.Peer = peer;
            this.Key = peer.EcsId;
            Console.WriteLine(TmTimer.GetCurrentTime() + " 创建一个心跳包 TmServerCDItem.");
        }
        public TmServerCDItem()   { }
        public override void TmUpdate()
        {
            UpdateCDCount();
        }
        void UpdateCDCount()
        {
            if (CdCount <= MaxCdCount)
            {
                Console.WriteLine(TmTimer.GetCurrentTime() + " CdCount: " + CdCount + "-" + MaxCdCount);
            }
            CdCount += 1;
            if (CdCount >= MaxCdCount)
            {
                Console.WriteLine(TmTimer.GetCurrentTime() + " TmServerCDItem is Colsed. TPeers Count: " + TmAsyncTcpServer.Instance.TPeers.Count);
                this.End = true;
                if (Peer != null)
                {
                    Peer.Dispose();
                }
                this.Dispose();
            }
            else
            {
                //发送心跳检测（并等待签到，签到入口在EngineerNode）
                MvcParameter mvc = MvcTool.ToParameter(EightCode.Node, NineCode.Sender, TenCode.Peer, ElevenCode.HeartBeat);
                mvc.EcsId = Key;
                TmAsyncTcpServer.Instance.SendMvc(mvc);
            }
            Console.WriteLine(TmTimer.GetCurrentTime() + " CdCount: " + CdCount + "-" + MaxCdCount);
        }

        public override void TmDispose()
        {
            base.TmDispose();
            Console.WriteLine(TmTimer.GetCurrentTime() + " EcsId:" + EcsId + " TmServerCDItem释放资源。 Key:" + Key);
        }

    }
}
