using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Tumo
{
    public class TmSessionCDItem : TmCoolDown
    {
        public TmAsyncTcpSession Session { get; set; }
        public bool IsServer { get; set; } = true;
        public override void TmAwake()
        {
            ValTime = 4000;
        }
        public TmSessionCDItem() { }
        public TmSessionCDItem(int time) { this.ValTime = time; }
        public TmSessionCDItem(string key) { this.Key = key; }
        public TmSessionCDItem(bool isServer) { IsServer = isServer; }
        public override void TmUpdate()
        {
            UpdateCDCount();
        }
        void UpdateCDCount()
        {            
            CdCount += 1;
            if (CdCount >= MaxCdCount)
            {
                Console.WriteLine(TmTimerTool.CurrentTime() + " TmSessionCDItem Colsed. TPeers:{0} " ,TmOutTcp.Instance.TPeers.Count);
                this.End = true;
                if (Session != null)
                {
                    Session.Dispose();
                }
                this.Dispose();
            }
            else
            {
                //发送心跳检测（并等待签到，签到入口在EngineerNode）
                TmParameter mvc = TmTransferTool.ToParameter(EightCode.Node, NineCode.Sender, TenCode.Peer, ElevenCode.HeartBeat);
                mvc.EcsId = Key;
                TmOutTcp.Instance.SendMvc(mvc);              
            }
            Console.WriteLine(TmTimerTool.CurrentTime() + " CdCount:{0}-{1} ", CdCount, MaxCdCount);
        }
        public override void TmDispose()
        {
            base.TmDispose();
            Console.WriteLine(TmTimerTool.GetCurrentTime() + " TmSessionCDItem释放资源, EcsId:{0} Key:{1}", EcsId, Key);
        }      
    }
}
