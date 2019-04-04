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
                case (ElevenCode.SetSoulerDBs):
                    Console.WriteLine(TmTimerTool.CurrentTime() + " TmBookerController: " + elevenCode);
                    SetSoulerDBs(parameter);
                    break;
                //case (ElevenCode.GetRolers):
                //    Console.WriteLine(TmTimerTool.CurrentTime() + " TmBookerController: " + elevenCode);
                //    GetBookers(parameter);
                //    break;
                default:
                    break;
            }
        }
        void SetSoulerDBs(TmParameter parameter)
        {
            Dictionary<int, TmSoulerDB> bookers = TmParameterTool.GetJsonValue<Dictionary<int, TmSoulerDB>>(parameter, parameter.ElevenCode.ToString());
            if (bookers.Count > 0)
            {
                TmObjects.Bookers = bookers;
                Console.WriteLine(TmTimerTool.CurrentTime() + " TmObjects.Bookers: " + TmObjects.Bookers.Count);
            }
        }
        void GetBookers(TmParameter parameter)
        {
            List<TmSoulerDB> bookers = TmParameterTool.GetJsonValue<List<TmSoulerDB>>(parameter, parameter.ElevenCode.ToString());
            Console.WriteLine(TmTimerTool.CurrentTime() + " TmBookerController-Bookers: " + bookers.Count);
        }
    }
}
