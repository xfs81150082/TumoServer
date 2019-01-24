using System;
using System.Collections.Generic;
using Tumo;
namespace ClientExample
{
    class TmBookerController : TmComponent
    {
        public override void OnTransferParameter(object obj, TmParameter parameter)
        {
            ElevenCode elevenCode = parameter.ElevenCode;
            switch (elevenCode)
            {
                case (ElevenCode.EngineerLogin):
                    Console.WriteLine(TmTimerTool.CurrentTime() + " EngineerLogin: " + elevenCode);
                    GetBookers(parameter);
                    break;
                default:
                    break;
            }
        }
        void GetBookers(TmParameter parameter)
        {
            List<TmSoulerDB> bookers = TmParameterTool.GetJsonValue<List<TmSoulerDB>>(parameter, "Bookers");
            Console.WriteLine(TmTimerTool.CurrentTime() + " TmBookerController-Bookers: " + bookers.Count);
        }


    }
}
