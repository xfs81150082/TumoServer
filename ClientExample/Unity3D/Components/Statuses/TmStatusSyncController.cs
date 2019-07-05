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
                Console.WriteLine(" KeyId: " + status.KeyId + " Recv30: " + " px: " + status.MyselfTmTransform.px + " py: " + status.MyselfTmTransform.py + " pz: " + status.MyselfTmTransform.pz + " ay: " + status.MyselfTmTransform.ay);
                Console.WriteLine(" KeyId: " + status.KeyId + " Recv31: " + " px: " + status.TargetTmTransform.px + " py: " + status.TargetTmTransform.py + " pz: " + status.TargetTmTransform.pz + " ay: " + status.TargetTmTransform.ay);
            }
        }

    }
}