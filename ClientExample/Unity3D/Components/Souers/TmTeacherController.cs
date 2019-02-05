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
                case (ElevenCode.GetRolers):
                    Console.WriteLine(TmTimerTool.CurrentTime() + " TmTeacherController: " + elevenCode);
                    GetTeachers(parameter);
                    break;
                default:
                    break;
            }
        }
        void GetTeachers(TmParameter parameter)
        {
            List<TmSoulerDB> teachers = TmParameterTool.GetJsonValue<List<TmSoulerDB>>(parameter, parameter.ElevenCode.ToString());
            Console.WriteLine(TmTimerTool.CurrentTime() + " TmTeacherController-Teachers: " + teachers.Count);
        }        
    }
}
