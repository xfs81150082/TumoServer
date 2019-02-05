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
                case (ElevenCode.GetRolers):
                    Console.WriteLine(TmTimerTool.CurrentTime() + " TmBookerController: " + elevenCode);
                    GetBookers(parameter);
                    break;
                default:
                    break;
            }
        }
        void GetBookers(TmParameter parameter)
        {
            List<TmSoulerDB> bookers = TmParameterTool.GetJsonValue<List<TmSoulerDB>>(parameter, parameter.ElevenCode.ToString());
            Console.WriteLine(TmTimerTool.CurrentTime() + " TmBookerController-Bookers: " + bookers.Count);
        }
    }
}
