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
    class EngineerNode : NodeHandlerBase
    {
        #region OnTransferParameter
        public override string Code => TenCode.Engineer.ToString();
        public override void OnTransferParameter(MvcParameter mvc)
        {
            ElevenCode elevenCode = mvc.ElevenCode;
            switch (elevenCode)
            {      
                case (ElevenCode.EngineerLogin):
                    Console.WriteLine(TmTimer.GetCurrentTime() + " EngineerNode: " + elevenCode);
                    EngineerLogin(mvc);
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

     
        #endregion


        #region EngineerLogin
        private void EngineerLogin(MvcParameter mvc)
        {
            mvc.NineCode = NineCode.Mysqler;
            TumoNode.Instance.OnTransferParameter(mvc);
            GetBookers(mvc);
            Thread.Sleep(100);
            Console.WriteLine(TmTimer.GetCurrentTime() + " EngineerNode Thread Name:" + Thread.CurrentThread);
            Console.WriteLine(TmTimer.GetCurrentTime() + " EngineerNode Thread Name:" + Thread.CurrentThread.Name);
            Console.WriteLine(TmTimer.GetCurrentTime() + " EngineerNode Thread Name:" + Thread.CurrentThread.ManagedThreadId);
            GetTeachers(mvc);
        }
        private void GetBookers(MvcParameter mvc)
        {
            MvcParameter mvc2 = MvcTool.ToJsonParameter(EightCode.Node, NineCode.Handler, TenCode.Booker, ElevenCode.GetItems);
            mvc2.EcsId = mvc.EcsId;
            TumoGate.Instance.OnTransferParameter(mvc2);
        }
        private void GetTeachers(MvcParameter mvc)
        {
            MvcParameter mvc2 = MvcTool.ToJsonParameter(EightCode.Node, NineCode.Handler, TenCode.Teacher, ElevenCode.GetItems);
            mvc2.EcsId = mvc.EcsId;
            TumoGate.Instance.OnTransferParameter(mvc2);
        }
        #endregion


    }
}
