using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Timers;
using ClientExample;
using Tumo;
using Tumo.Models;

namespace ClientExample.Sences.Nodes.Controllers
{
    class PeerNode : NodeCotrollerBase
    {
        public override string Code => TenCode.Peer.ToString();
        public override void OnTransferParameter(TmParameter mvc)
        {
            ElevenCode elevenCode = mvc.ElevenCode;
            switch (elevenCode)
            {
                case (ElevenCode.HeartBeat):
                    Console.WriteLine(TmTimerTool.CurrentTime() + " PeerNode: " + elevenCode);
                    mvc.NineCode = NineCode.Sender;
                    TumoNode.Instance.OnTransferParameter(mvc);
                    //HeartBeatSignIn();
                    break;
                case (ElevenCode.RemoveHeartBeat):
                    Console.WriteLine(TmTimerTool.CurrentTime() + " PeerNode: " + elevenCode);
                    //RemoveHeartBeat();
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

        //void HeartBeatSignIn()
        //{
        //    if (TmAsyncTcpClient.Instance.CD != null)
        //    {
        //        TmAsyncTcpClient.Instance.CD.CdCount = 0;
        //    }
        //    else
        //    {
        //        //TmClientCDItem item = new TmClientCDItem();
        //        //item.CdCount = 0;
        //        //item.CoolDown.MaxCdCount = 4;
        //        //TmAsyncTcpClient.Instance.CDItem = item;
        //        //Console.WriteLine("创建心跳 ClientCDItem.");
        //    }
        //}
        //void RemoveHeartBeat()
        //{
        //    TmAsyncTcpClient.Instance.CDItem.Dispose();
        //    TmAsyncTcpClient.Instance.CDItem = null;
        //}

    }
}
