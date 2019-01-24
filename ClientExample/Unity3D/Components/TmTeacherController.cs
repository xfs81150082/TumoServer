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
                case (ElevenCode.EngineerLogin):
                    Console.WriteLine(TmTimerTool.CurrentTime() + " EngineerLogin: " + elevenCode);
                    GetTeachers(parameter);
                    break;
                default:
                    break;
            }
        }
        void GetTeachers(TmParameter parameter)
        {
            List<TmSoulerDB> teachers = TmParameterTool.GetJsonValue<List<TmSoulerDB>>(parameter, "Teachers");
            Console.WriteLine(TmTimerTool.CurrentTime() + " TmTeacherController-Teachers: " + teachers.Count);
        }


    }
}
