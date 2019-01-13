using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Timers;
using Tumo;
using Tumo.Models;
using Servers.Sences.Models;

namespace Servers.Sences.Nodes.Handlers
{
    class PeerNode : NodeHandlerBase
    {
        #region OnTransferParameter
        public override string Code => TenCode.Peer.ToString();
        public override void OnTransferParameter(MvcParameter mvc)
        {
            ElevenCode elevenCode = mvc.ElevenCode;
            switch (elevenCode)
            {
                case (ElevenCode.HeartBeat):
                    Console.WriteLine(TmTimer.GetCurrentTime() + " EngineerNode: " + elevenCode);
                    PeerSignIn(mvc);
                    break;
                case (ElevenCode.RemoveHeartBeat):
                    Console.WriteLine(TmTimer.GetCurrentTime() + " EngineerNode: " + elevenCode);
                    RemovePeerCDItem(mvc);
                    break;
                case (ElevenCode.Test):
                    Console.WriteLine(TmTimer.GetCurrentTime() + " EngineerNode: " + elevenCode);
                    break;
                case (ElevenCode.None):
                    Console.WriteLine(TmTimer.GetCurrentTime() + " EngineerNode: " + elevenCode);
                    break;
                default:
                    break;
            }
        }
        #endregion

        #region TmUpdate
        private int valTime = 4000;
        private int cdsCount = -1;
        //public Dictionary<string, PeerCDItem> PeerCDItems = new Dictionary<string, PeerCDItem>();            

        public override void TmAwake() { }

        public override void TmUpdate(ElapsedEventArgs time)
        {
            CheckPeersCD(time);
        }


        #endregion

        #region PeerCD
        void CheckPeersCD(ElapsedEventArgs ela)
        {
            if (TmAsyncTcpServer.Instance.TPeers.Count != cdsCount)
            {
                cdsCount = TmAsyncTcpServer.Instance.TPeers.Count;
                Console.WriteLine(TmTimer.GetCurrentTime() + " PeerCD:心跳包每" + valTime / 1000 + "秒钟心跳一次(秒针:" + ela.SignalTime.Second + ", 毫秒针:" + ela.SignalTime.Millisecond + ")");
                TmLog.WriteLine(TmTimer.GetCurrentTime() + " EngineerTimer每" + valTime / 1000 + "秒钟心跳一次(秒针:" + ela.SignalTime.Second + ",毫秒针:" + ela.SignalTime.Millisecond + ")");
                //初始化服务器PeersCD字典
                if (TmAsyncTcpServer.Instance.TPeers.Count > 0)
                {
                    List<string> list1 = new List<string>(TmAsyncTcpServer.Instance.TPeers.Keys);
                    for (int i = 0; i < list1.Count; i++)
                    {
                        TmCoolDownItem cd1;
                        //bool yes = PeerCDItems.TryGetValue(list1[i], out cd1);
                        bool yes = TmAsyncTcpServer.Instance.CDItems.TryGetValue(list1[i], out cd1);
                        if (yes == false)
                        {
                            TmServerCDItem cd2 = new TmServerCDItem();
                            cd2.CdCount = 0;
                            cd2.CoolDown.MaxCdCount = 4;
                            cd2.Key = list1[i];
                            //PeerCDItems.Add(list1[i], cd2);
                            TmAsyncTcpServer.Instance.CDItems.Add(list1[i], cd2);
                        }
                    }
                }
                else
                {
                    if (TmAsyncTcpServer.Instance.CDItems.Count > 0)
                    {
                        TmAsyncTcpServer.Instance.CDItems.Clear();
                    }
                }
                Console.WriteLine(TmTimer.GetCurrentTime() + " PeerCDItems: " + TmAsyncTcpServer.Instance.CDItems.Count + "-" + TmAsyncTcpServer.Instance.TPeers.Count);
            }
        }
        void PeerSignIn(MvcParameter mvc)
        {
            TmCoolDownItem cd;
            TmAsyncTcpServer.Instance.CDItems.TryGetValue(mvc.EcsId, out cd);
            if (cd != null)
            {
                cd.CdCount = 0;
            }
        }
        void RemovePeerCDItem(MvcParameter mvc)
        {
            if (TmAsyncTcpServer.Instance.CDItems.Count > 0)
            {
                TmCoolDownItem item;
                TmAsyncTcpServer.Instance.CDItems.TryGetValue(mvc.EcsId, out item);
                if (item != null)
                {
                    item.Dispose();
                    TmAsyncTcpServer.Instance.CDItems.Remove(mvc.EcsId);
                }
            }
        }
        #endregion
             

    }
}
