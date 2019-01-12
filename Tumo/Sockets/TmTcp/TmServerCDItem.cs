using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Tumo
{
    public class TmServerCDItem : CoolDownItem
    {

        public string EndPoint { get; set; }

        public TmServerCDItem() { ValTime = 4000; }

        public override void TmUpdate()
        {
            UpdateCDCount();
        }

        void UpdateCDCount()
        {
            if (CdCount <= CoolDown.MaxCdCount)
            {
                Console.WriteLine(TmTimer.GetCurrentTime() + " CdCount: " + CdCount + "/" + CoolDown.MaxCdCount);
            }
            CdCount += 1;
            if (CdCount >= CoolDown.MaxCdCount)
            {
                Console.WriteLine(TmTimer.GetCurrentTime() + " PeerCDItem Colseed. TPeers Count: " + TmAsyncTcpServer.Instance.TPeers.Count);
                Close();
                TPeer tpeer;
                TmAsyncTcpServer.Instance.TPeers.TryGetValue(Key, out tpeer);
                if (tpeer != null)
                {
                    //删除掉心跳包群中对应的peer
                    tpeer.OnDisconnect();
                }
            }
            else
            {
                //发送心跳检测（并等待签到，签到入口在EngineerNode）
                MvcParameter mvc = MvcTool.ToParameter(EightCode.Node, NineCode.Sender, TenCode.Peer, ElevenCode.HeartBeat);
                mvc.Endpoint = Key;
                TmAsyncTcpServer.Instance.SendMvc(mvc);

                //TumoNode.Instance.OnTransferParameter(mvc);
            }
            Console.WriteLine(TmTimer.GetCurrentTime() + " CdCount: " + CdCount + "-" + CoolDown.MaxCdCount);
        }

    }
}
