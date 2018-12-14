using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Timers;
using Clients;
using Tumo;
using Tumo.Models;

namespace Clients.Sences.Nodes.Controllers
{
    class EngineerNode : NodeCotrollerBase
    {
        public override string Code => TenCode.Engineer.ToString();
        public override void OnTransferParameter(MvcParameter mvc)
        {
            ElevenCode elevenCode = mvc.ElevenCode;
            switch (elevenCode)
            {   
                case (ElevenCode.HeartBeat):
                    Console.WriteLine(TmClientHelper.Instance.GetCurrentTime() + " EngineerNode: " + elevenCode);
                    mvc.NineCode = NineCode.Sender;
                    TumoNode.Instance.OnTransferParameter(mvc);
                    break;
                case (ElevenCode.EngineerLogin):
                    Console.WriteLine(TmClientHelper.Instance.GetCurrentTime() + " EngineerNode: " + elevenCode);
                    EngineerLogin(mvc);
                    break;
                default:
                    break;
            }
        }

        private int interval = 14000;
        public Dictionary<string, CoolDownItem> PeerCounterItems = new Dictionary<string, CoolDownItem>();
        
        public EngineerNode()
        {
            SecondTimer(interval);
        }
        void SecondTimer(int val)
        {
            Timer aTimer = new Timer();                                   //实例化Timer类，在括号里设置间隔时间,单位为毫秒；
            aTimer.Elapsed += new ElapsedEventHandler(SecondTimeEvent);   //到达时间的时候执行事件；
            aTimer.Interval = val;                                        //心跳间隔时间14000毫秒；
            aTimer.Enabled = true;                                        //是否执行事件System.Timers.Timer.Elapsed；
            aTimer.AutoReset = true;                                      //设置是否循环执行，是执行一次（false）还是一直执行(true)；
        }
        // 当时间发生的时候需要进行的逻辑处理等    // 在这里仅仅是一种方式，可以实现这样的方式很多    
        void SecondTimeEvent(object source, ElapsedEventArgs ela)
        {
            CheckPeers(ela);
        }
        void CheckPeers(ElapsedEventArgs ela)
        {
            //Transform.
            //GameObject.transform.position = new Vector3();
            //Transform.Destroy
            //Transform.Destroy(this, 2);
        }

        void EngineerLogin(MvcParameter mvc)
        {
            SoulItem soulItem = MvcTool.GetJsonValue<SoulItem>(mvc, mvc.ElevenCode.ToString());
            NodeInfo.Instance.Engineer = soulItem;
            Console.WriteLine(TmClientHelper.Instance.GetCurrentTime() + " 当前角色Name: " + NodeInfo.Instance.Engineer.Name + " Id: " + NodeInfo.Instance.Engineer.Id + " px: " + NodeInfo.Instance.Engineer.px);
        }



    }
}
