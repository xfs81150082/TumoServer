using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Tumo
{
    public class TmServerCDItem : TmCoolDownItem
    {
        public override void TmAwake()
        {
            ValTime = 4000;
        }
        public TmServerCDItem(string tpeerEcsId)
        {
            this.Key = tpeerEcsId;
            TmAsyncTcpServer.Instance.CDItems.Add(Key, this);
            Console.WriteLine(TmTimer.GetCurrentTime() + " 创建一个心跳包 TmServerCDItem.");
        }
        public TmServerCDItem()   { }
        public override void TmUpdate()
        {
            UpdateCDCount();
        }
        void UpdateCDCount()
        {
            if (CdCount <= CoolDown.MaxCdCount)
            {
                Console.WriteLine(TmTimer.GetCurrentTime() + " CdCount: " + CdCount + "-" + CoolDown.MaxCdCount);
            }
            CdCount += 1;
            if (CdCount >= CoolDown.MaxCdCount)
            {
                Console.WriteLine(TmTimer.GetCurrentTime() + " TmServerCDItem Colseed. TPeers Count: " + TmAsyncTcpServer.Instance.TPeers.Count);
                this.Dispose();
            }
            else
            {
                //发送心跳检测（并等待签到，签到入口在EngineerNode）
                MvcParameter mvc = MvcTool.ToParameter(EightCode.Node, NineCode.Sender, TenCode.Peer, ElevenCode.HeartBeat);
                mvc.EcsId = Key;
                TmAsyncTcpServer.Instance.SendMvc(mvc);
            }
            Console.WriteLine(TmTimer.GetCurrentTime() + " CdCount: " + CdCount + "-" + CoolDown.MaxCdCount);
        }

        public override void TmDispose()
        {
            TmAsyncTcpServer.Instance.CDItems.Remove(Key);
            TPeer tpeer;
            TmAsyncTcpServer.Instance.TPeers.TryGetValue(Key, out tpeer);
            if (tpeer != null)
            {
                //删除掉心跳包群中对应的peer
                TmAsyncTcpServer.Instance.TPeers.Remove(Key);
                tpeer.Dispose();
            }
            Console.WriteLine(TmTimer.GetCurrentTime() + " TmServerCDItem TmDispose: " + Key);
        }

    }
}
