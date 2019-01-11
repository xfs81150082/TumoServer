using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Timers;
using ClientExample;
using ClientExample.Sences.Models;
using Tumo;
using Tumo.Models;

namespace ClientExample.Sences.Nodes.Controllers
{
    class PeerNode : NodeCotrollerBase
    {
        public override string Code => TenCode.Peer.ToString();
        public override void OnTransferParameter(MvcParameter mvc)
        {
            ElevenCode elevenCode = mvc.ElevenCode;
            switch (elevenCode)
            {
                case (ElevenCode.HeartBeat):
                    Console.WriteLine(TimerTool.GetCurrentTime() + " PeerNode: " + elevenCode);
                    mvc.NineCode = NineCode.Sender;
                    TumoNode.Instance.OnTransferParameter(mvc);
                    HeartBeatSignIn();
                    break;
                case (ElevenCode.RemoveHeartBeat):
                    Console.WriteLine(TimerTool.GetCurrentTime() + " PeerNode: " + elevenCode);
                    RemoveHeartBeat();
                    break;
                default:
                    break;
            }
        }

        //private ClientCDItem ClientCDItem { get; set; }
        
        public PeerNode()
        {
            //HeartBeatSignIn();
        }

        void HeartBeatSignIn()
        {
            if (TmAsyncTcpClient.Instance.CDItem != null)
            {
                TmAsyncTcpClient.Instance.CDItem.CdCount = 0;
            }
            else
            {
                ClientCDItem item = new ClientCDItem();
                item.CdCount = 0;
                item.CoolDown.MaxCdCount = 4;
                TmAsyncTcpClient.Instance.CDItem = item;
                Console.WriteLine("创建心跳 ClientCDItem.");
            }
        }
        void RemoveHeartBeat()
        {
            TmAsyncTcpClient.Instance.CDItem.Close();
            TmAsyncTcpClient.Instance.CDItem = null;
        }

    }
}
