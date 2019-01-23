using System;
using System.Collections.Generic;
using Tumo;
namespace ClientExample
{
    class TmEngineerController : TmComponent
    {
        public override void OnTransferParameter(object obj, TmParameter parameter)
        {
            ElevenCode elevenCode = parameter.ElevenCode;
            switch (elevenCode)
            {
                case (ElevenCode.Login):
                    Console.WriteLine(TmTimerTool.CurrentTime() + " EngineerLogin: " + elevenCode);
                    GetBookersAndTeachers(parameter);
                    break;
                default:
                    break;
            }
        }
        void GetBookersAndTeachers(TmParameter parameter)
        {
            List<TmSoulerDB> bookers = TmParameterTool.GetJsonValue<List<TmSoulerDB>>(parameter, "Bookers");
            List<TmSoulerDB> teachers = TmParameterTool.GetJsonValue<List<TmSoulerDB>>(parameter, "Teachers");
            Console.WriteLine(TmTimerTool.CurrentTime() + " TmEngineerController-Bookers: " + bookers.Count);
            Console.WriteLine(TmTimerTool.CurrentTime() + " TmEngineerController-Teachers: " + teachers.Count);
        }


    }
}
