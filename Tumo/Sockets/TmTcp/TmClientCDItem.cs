using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Tumo
{
    public class TmClientCDItem : CoolDownItem
    {
        public TmClientCDItem(string key)
        {
            ValTime = 4000;
            this.Key = key;
            TmAsyncTcpClient.Instance.CDItem = this;
            Console.WriteLine("创建心跳 TmClientCDItem.");
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
                //删除掉心跳包对应的TClient
                TmAsyncTcpClient.Instance.TClient.OnDisconnect();
                TmAsyncTcpClient.Instance.TClient = null;
                TmAsyncTcpClient.Instance.IsConnecting = false;
                Console.WriteLine(TmTimer.GetCurrentTime() + " 当前CDItem Colseed." );
                Close();
            }
            else
            {
                //发送心跳检测（并等待签到，签到入口在EngineerNode）
                MvcParameter mvc = MvcTool.ToParameter(EightCode.Node, NineCode.Sender, TenCode.Peer, ElevenCode.HeartBeat);
                TmAsyncTcpClient.Instance.SendMvc(mvc);
            }
            Console.WriteLine(TmTimer.GetCurrentTime() + " CdCount: " + CdCount + "-" + CoolDown.MaxCdCount);
        }

    }
}
