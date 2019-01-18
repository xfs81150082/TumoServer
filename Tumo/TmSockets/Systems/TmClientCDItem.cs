using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Tumo
{
    public class TmClientCDItem : TmCoolDown
    {
        public TClient Client { get; set; }
        public override void TmAwake()
        {
            ValTime = 4000;
        }
        public TmClientCDItem(TClient client)
        {
            this.Client = client;
            this.Key = client.EcsId;
            Console.WriteLine(TmTimerTool.GetCurrentTime() + " 创建一个心跳包 TmClientCDItem.");
        }
        public TmClientCDItem() {  }
        public override void TmUpdate()
        {
            UpdateCDCount();
        }
        void UpdateCDCount()
        {
            if (CdCount <= MaxCdCount)
            {
                Console.WriteLine(TmTimerTool.GetCurrentTime() + " CdCount: " + CdCount + "-" + MaxCdCount);
            }
            CdCount += 1;
            if (CdCount >= MaxCdCount)
            {
                Console.WriteLine(TmTimerTool.GetCurrentTime() + " 当前 TmClientCDItem is Colseed.");
                this.End = true;
                if (Client != null)
                {
                    Client.Dispose();
                }
                this.Dispose();
            }
            else
            {
                //发送回应的心跳检测
                TmRequest mvc = TmTransferTool.ToParameter(EightCode.Node, NineCode.Sender, TenCode.Peer, ElevenCode.HeartBeat);
                mvc.EcsId = Key;
                TmAsyncTcpClient.Instance.SendMvc(mvc);
            }
            Console.WriteLine(TmTimerTool.GetCurrentTime() + " CdCount: " + CdCount + "-" + MaxCdCount);
        }

        public override void TmDispose()
        {
            base.TmDispose();
            Console.WriteLine(TmTimerTool.GetCurrentTime() + " EcsId:" + EcsId + " TmClientCDItem释放资源.Key:" +Key);
        }

     
    }
}
