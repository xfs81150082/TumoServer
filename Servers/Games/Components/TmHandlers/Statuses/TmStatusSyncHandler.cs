using System;
using System.Collections.Generic;
using Tumo;
namespace Servers
{
    class TmStatusSyncHandler : TmComponent
    {       
        public override void OnTransferParameter(object sender, TmParameter parameter)
        {
            ElevenCode elevenCode = parameter.ElevenCode;
            switch (elevenCode)
            {
                case (ElevenCode.Engineer):
                    Console.WriteLine(TmTimerTool.CurrentTime() + " TmStatusSyncHandler: " + elevenCode);
                    RolerStatusSync(parameter);
                    break;
                case (ElevenCode.Teacher):
                    Console.WriteLine(TmTimerTool.CurrentTime() + " TmStatusSyncHandler: " + elevenCode);
                    RolerStatusSync(parameter);
                    break;
                case (ElevenCode.Booker):
                    Console.WriteLine(TmTimerTool.CurrentTime() + " TmStatusSyncHandler: " + elevenCode);
                    RolerStatusSync(parameter);
                    break;
                //case (ElevenCode.Souler):
                //    Console.WriteLine(TmTimerTool.CurrentTime() + " TmStatusSyncHandler: " + elevenCode);
                //    RolerStatusSync(parameter);
                //    break;
                case (ElevenCode.None):
                    break;
                default:
                    break;
            }
        }      
        
        void RolerStatusSync(TmParameter parameter)
        {
            string myself = parameter.Keys[0];
            parameter.Keys = new List<string>(TmTcpSocket.Instance.TPeers.Keys);
            //parameter.Keys.Remove(myself);
            TmTcpSocket.Instance.Send(parameter);
        }



    }
}