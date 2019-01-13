using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Tumo
{
    public class TmServerCDItem : CoolDownItem
    {
        public override void TmAwake()
        {
            ValTime = 4000;
        }
        public TmServerCDItem(string key)
        {
            this.Key = key;
            TmAsyncTcpServer.Instance.CDItems.Add(Key, this);
            Console.WriteLine(TmTimer.GetCurrentTime() + " 创建心跳包 TmServerCDItem.");
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
                Console.WriteLine(TmTimer.GetCurrentTime() + " CdCount: " + CdCount + "/" + CoolDown.MaxCdCount);
            }
            CdCount += 1;
            if (CdCount >= CoolDown.MaxCdCount)
            {
                Console.WriteLine(TmTimer.GetCurrentTime() + " TmServerCDItem Colseed. TPeers Count: " + TmAsyncTcpServer.Instance.TPeers.Count);
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
                mvc.EcsId = Key;
                TmAsyncTcpServer.Instance.SendMvc(mvc);
            }
            Console.WriteLine(TmTimer.GetCurrentTime() + " CdCount: " + CdCount + "-" + CoolDown.MaxCdCount);
        }


    }
}
