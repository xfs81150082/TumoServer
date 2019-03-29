using System;
using System.Collections;
using System.Collections.Generic;
using Tumo;
namespace ClientExample
{
    class TmStatusSyncController : TmComponent
    {       
        public override void OnTransferParameter(object sender, TmParameter parameter)
        {
            ElevenCode elevenCode = parameter.ElevenCode;
            switch (elevenCode)
            {
                case (ElevenCode.Roler):
                    Console.WriteLine(TmTimerTool.CurrentTime() + " TmStatusSyncHandler: " + elevenCode);
                    RolerStatusSync(parameter);
                    break;              
                case (ElevenCode.None):
                    break;
                default:
                    break;
            }
        }

        void RolerStatusSync(TmParameter parameter)
        {
            TmStatus status = TmParameterTool.GetJsonValue<TmStatus>(parameter, parameter.ElevenCode.ToString());
            if (status != null)
            {
                Console.WriteLine(TmTimerTool.CurrentTime() + " TmStatusSyncController-Recv-status.Count28: " + status.Paths.Count);
                TestPaths(status);
            }
        }
        void TestPaths(TmStatus status)
        {
            if (status.Paths != null && status.Paths.Count > 0)
            {
                Console.WriteLine(status.Paths.Count);
                Console.WriteLine(TmTimerTool.CurrentTime() + " Myself-px: " + status.MyselfTmTransform.px + " py: " + status.MyselfTmTransform.py + " pz: " + status.MyselfTmTransform.pz);
                Console.WriteLine(TmTimerTool.CurrentTime() + " Target-px: " + status.TargetTmTransform.px + " py: " + status.TargetTmTransform.py + " pz: " + status.TargetTmTransform.pz);
                for (int i = 0; i < status.Paths.Count; i++)
                {
                    TmTransform trans = status.Paths[i];
                    Console.WriteLine(TmTimerTool.CurrentTime() + " (x,z): " + trans.px + " , " + trans.pz);
                }
            }
        }

    }
}