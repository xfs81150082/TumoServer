using System;
using System.Collections;
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
      

    }
}
