using System;
using System.Collections.Generic;
using Tumo;
namespace Servers
{
    class TmStatusSyncHandler : TmEntity
    {
        public override void TmAwake()
        {
            base.TmAwake();


        }


        public override void OnTransferParameter(object sender, TmParameter parameter)
        {
            ElevenCode elevenCode = parameter.ElevenCode;
            switch (elevenCode)
            {
                case (ElevenCode.GetRolers):
                    Console.WriteLine(TmTimerTool.CurrentTime() + " TmBookerHandler: " + elevenCode);
                    break;
                case (ElevenCode.Die):
                    Console.WriteLine(TmTimerTool.CurrentTime() + " TmBookerHandler: " + elevenCode);

                    break;
                case (ElevenCode.None):
                    break;
                default:
                    break;
            }
        }




    }
}