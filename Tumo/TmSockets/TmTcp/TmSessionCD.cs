using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Tumo
{
    public class TmSessionCD : TmCoolDown
    {
        public TmTcpSession Session { get; set; }
        public bool IsServer { get; set; } = true;
        public override void TmAwake()
        {
            ValTime = 4000;
        }
        public TmSessionCD() { }
        public TmSessionCD(int time) { this.ValTime = time; }
        public TmSessionCD(string key) { this.Key = key; }
        public TmSessionCD(bool isServer) { IsServer = isServer; }
        public override void TmUpdate()
        {
            UpdateCDCount();
        }
        void UpdateCDCount()
        {            
            CdCount += 1;
            if (CdCount >= MaxCdCount)
            {
                Console.WriteLine(TmTimerTool.CurrentTime() + " TmSessionCDItem Colsed. TPeers:{0} " ,TmNetTcp.Instance.TPeers.Count);
                this.End = true;
                if (Session != null)
                {
                    Session.Dispose();
                }
                this.Dispose();
            }
            else
            {
                //发送心跳检测（并等待签到，签到入口在TmAsyncTcpSession里）
                TmParameter mvc = TmTransferTool.ToJsonParameter(TenCode.TmEessionCD, ElevenCode.Login);
                mvc.EcsId = Key;
                TmNetTcp.Instance.SendMvc(mvc);              
            }
            Console.WriteLine(TmTimerTool.CurrentTime() + " CdCount:{0}-{1} ", CdCount, MaxCdCount);
        }
        public override void TmDispose()
        {
            base.TmDispose();
            Console.WriteLine(TmTimerTool.CurrentTime() + " TmSessionCDItem释放资源, EcsId:{0} Key:{1}", EcsId, Key);
        }      
    }
}
