using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Tumo
{
    public class TmClientCDItem : TmCoolDownItem
    {
        public override void TmAwake()
        {
            ValTime = 4000;
        }

        public TmClientCDItem(string key)
        {
            this.Key = key;
            TmAsyncTcpClient.Instance.CDItem = this;
            Console.WriteLine(TmTimer.GetCurrentTime() + " 创建心跳包 TmClientCDItem.");
        }

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
                Console.WriteLine(TmTimer.GetCurrentTime() + " 当前 CDItem is Colseed." );
                this.Dispose();
            }
            else
            {
                //发送回应的心跳检测
                MvcParameter mvc = MvcTool.ToParameter(EightCode.Node, NineCode.Sender, TenCode.Peer, ElevenCode.HeartBeat);
                mvc.EcsId = Key;
                TmAsyncTcpClient.Instance.SendMvc(mvc);
            }
            Console.WriteLine(TmTimer.GetCurrentTime() + " CdCount: " + CdCount + "-" + CoolDown.MaxCdCount);
        }

        public override void TmDispose()
        {
            Console.WriteLine(TmTimer.GetCurrentTime() + " IsConnecting: " + TmAsyncTcpClient.Instance.IsConnecting);
            TmComponent tmc;
            TmEcsDictionary.Components.TryGetValue(Key, out tmc);
            if (tmc != null)
            {
                tmc.Dispose();            ///删除掉心跳包对应的TClient
            }
            TmAsyncTcpClient.Instance.IsConnecting = false;
            Console.WriteLine(TmTimer.GetCurrentTime() + " IsConnecting: " + TmAsyncTcpClient.Instance.IsConnecting);
        }


    }
}
