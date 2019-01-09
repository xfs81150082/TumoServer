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
using Servers.Gates;
using Servers.Sences.Models;

namespace Servers.Sences.Nodes.Handlers
{
    class EngineerNode : NodeHandlerBase
    {
        #region OnTransferParameter
        public override string Code => TenCode.Engineer.ToString();
        public override void OnTransferParameter(MvcParameter mvc)
        {
            ElevenCode elevenCode = mvc.ElevenCode;
            switch (elevenCode)
            {
                case (ElevenCode.HeartBeat):
                    Console.WriteLine(TimerTool.GetCurrentTime() + " EngineerNode: " + elevenCode);
                    PeerSignIn(mvc);
                    break;
                case (ElevenCode.RemoveHeartBeat):
                    Console.WriteLine(TimerTool.GetCurrentTime() + " EngineerNode: " + elevenCode);
                    RemovePeerCDItem(mvc);
                    break;
                case (ElevenCode.EngineerLogin):
                    Console.WriteLine(TimerTool.GetCurrentTime() + " EngineerNode: " + elevenCode);
                    EngineerLogin(mvc);
                    break;
                case (ElevenCode.Test):
                    Console.WriteLine(TimerTool.GetCurrentTime() + " EngineerNode: " + elevenCode);
                    break;
                case (ElevenCode.None):
                    Console.WriteLine(TimerTool.GetCurrentTime() + " EngineerNode: " + elevenCode);
                    break;
                default:
                    break;
            }
        }
        #endregion

        #region TmUpdate
        private int valTime = 4000;
        private int cdsCount = -1;
        public Dictionary<string, PeerCDItem> PeerCDItems = new Dictionary<string, PeerCDItem>();            
        public override void TmAwake()  {   }
        public override void TmUpdate(ElapsedEventArgs time)
        {
            //CheckPeersCD(time);
        }
        #endregion

        #region PeerCD
        void CheckPeersCD(ElapsedEventArgs ela)
        {
            if (TmAsyncTcpServer.Instance.TPeers.Count != cdsCount)
            {
                cdsCount = TmAsyncTcpServer.Instance.TPeers.Count;
                Console.WriteLine(TimerTool.GetCurrentTime() + " PeerCD:心跳包每" + valTime / 1000 + "秒钟心跳一次(秒针:" + ela.SignalTime.Second + ", 毫秒针:" + ela.SignalTime.Millisecond + ")");
                TmLog.WriteLine("EngineerTimer每" + valTime / 1000 + "秒钟心跳一次(秒针:" + ela.SignalTime.Second + ",毫秒针:" + ela.SignalTime.Millisecond + ")");
                //初始化服务器PeersCD字典
                if (TmAsyncTcpServer.Instance.TPeers.Count > 0)
                {
                    List<string> list1 = new List<string>(TmAsyncTcpServer.Instance.TPeers.Keys);
                    for (int i = 0; i < list1.Count; i++)
                    {
                        PeerCDItem cd1;
                        bool yes = PeerCDItems.TryGetValue(list1[i], out cd1);
                        if (yes == false)
                        {
                            PeerCDItem cd2 = new PeerCDItem();
                            cd2.CdCount = 0;
                            cd2.CoolDown.MaxCdCount = 4;
                            cd2.Key = list1[i];
                            PeerCDItems.Add(list1[i], cd2);
                        }
                    }
                }
                else
                {
                    if (PeerCDItems.Count > 0)
                    {
                        PeerCDItems.Clear();
                    }
                }
                Console.WriteLine(TimerTool.GetCurrentTime() + " PeerCDItems: " + PeerCDItems.Count + "/" + TmAsyncTcpServer.Instance.TPeers.Count);
            }
        }
        void PeerSignIn(MvcParameter mvc)
        {
            PeerCDItem cd;
            PeerCDItems.TryGetValue(mvc.Endpoint, out cd);
            if (cd != null)
            {
                cd.CdCount = 0;
            }
        }
        void RemovePeerCDItem(MvcParameter mvc)
        {
            if (PeerCDItems.Count > 0)
            {
                PeerCDItem item;
                PeerCDItems.TryGetValue(mvc.Endpoint, out item);
                if (item != null)
                {
                    item.Close();
                    PeerCDItems.Remove(mvc.Endpoint);
                }
            }
        }
        #endregion

        #region EngineerLogin
        private void EngineerLogin(MvcParameter mvc)
        {
            mvc.NineCode = NineCode.Mysqler;
            TumoNode.Instance.OnTransferParameter(mvc);
            GetBookers(mvc);
            Thread.Sleep(100);
            Console.WriteLine(TimerTool.GetCurrentTime() + " EngineerNode Thread Name:" + Thread.CurrentThread);
            Console.WriteLine(TimerTool.GetCurrentTime() + " EngineerNode Thread Name:" + Thread.CurrentThread.Name);
            Console.WriteLine(TimerTool.GetCurrentTime() + " EngineerNode Thread Name:" + Thread.CurrentThread.ManagedThreadId);
            GetTeachers(mvc);
        }
        private void GetBookers(MvcParameter mvc)
        {
            MvcParameter mvc2 = MvcTool.ToJsonParameter(EightCode.Node, NineCode.Handler, TenCode.Booker, ElevenCode.GetItems);
            mvc2.Endpoint = mvc.Endpoint;
            TumoGate.Instance.OnTransferParameter(mvc2);
        }
        private void GetTeachers(MvcParameter mvc)
        {
            MvcParameter mvc2 = MvcTool.ToJsonParameter(EightCode.Node, NineCode.Handler, TenCode.Teacher, ElevenCode.GetItems);
            mvc2.Endpoint = mvc.Endpoint;
            TumoGate.Instance.OnTransferParameter(mvc2);
        }
        #endregion


    }
}
