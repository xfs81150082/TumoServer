using Tumo;
using Tumo.Models;
using Tumo;
using Tumo;
using Servers;
using Servers.Sences.Nodes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Timers;

namespace Servers.Sences.Models
{
    public class PeerCDItem : CoolDownItem
    {
        public PeerCDItem() { }
      
        public override void TmAwake()
        {
            ValTime = 4000;
        }

        public override void TmUpdate(ElapsedEventArgs time)
        {
            UpdateCDCount();
        }

        void UpdateCDCount()
        {
            Console.WriteLine(TmServerHelper.Instance.GetCurrentTime() + " PeerCDItem: " + CdCount  + "/" + CoolDown.MaxCdCount);
            CdCount += 1;
            if (CdCount >= CoolDown.MaxCdCount)
            {
                Console.WriteLine(TmServerHelper.Instance.GetCurrentTime() + " PeerCDItem Colseed. TcpPeers: " + TmServerHelper.Instance.TcpPeers.Count);
                Close();
                TPeer peer;
                TmServerHelper.Instance.TcpPeers.TryGetValue(Key, out peer);
                if (peer != null)
                {
                    //删除掉心跳包群中对应的peer
                    peer.OnDisconnect();
                }
            }
            else
            {
                //发送心跳检测（并等待签到，签到入口在EngineerNode）
                MvcParameter mvc = MvcTool.ToParameter(EightCode.Node, NineCode.Sender, TenCode.Peer, ElevenCode.HeartBeat);
                mvc.Endpoint = Key;
                TumoNode.Instance.OnTransferParameter(mvc);
            }
            Console.WriteLine(TmServerHelper.Instance.GetCurrentTime() + " PeerCDItem: " + CdCount + "/" + CoolDown.MaxCdCount);
        }
               

    }
}
