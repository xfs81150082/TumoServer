using System;
using System.Collections.Generic;
using Tumo;
namespace ClientExample
{
    class TmTeacherController : TmComponent
    {
        public override void OnTransferParameter(object obj, TmParameter parameter)
        {
            ElevenCode elevenCode = parameter.ElevenCode;
            switch (elevenCode)
            {
                case (ElevenCode.SetSoulerDBs):
                    Console.WriteLine(TmTimerTool.CurrentTime() + " TmTeacherController: " + elevenCode);

                    SetSoulerDBs(parameter);

                    break;
                default:
                    break;
            }
        }
        void SetSoulerDBs(TmParameter parameter)
        {
            List<TmSoulerDB> bookers = TmParameterTool.GetJsonValue<List<TmSoulerDB>>(parameter, parameter.ElevenCode.ToString());
            if (bookers.Count > 0)
            {
                TmObjects.Teachers = bookers;
                Console.WriteLine(TmTimerTool.CurrentTime() + " TmObjects.Teachers: " + TmObjects.Teachers.Count);
            }
        }

    }
}
