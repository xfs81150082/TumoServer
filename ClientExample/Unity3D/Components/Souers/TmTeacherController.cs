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
                //case (ElevenCode.GetRolers):
                //    Console.WriteLine(TmTimerTool.CurrentTime() + " TmTeacherController: " + elevenCode);
                //    GetTeachers(parameter);
                //    break;
                default:
                    break;
            }
        }
        void SetSoulerDBs(TmParameter parameter)
        {
            Dictionary<int, TmSoulerDB> teachers = TmParameterTool.GetJsonValue<Dictionary<int, TmSoulerDB>>(parameter, parameter.ElevenCode.ToString());
            if (teachers.Count > 0)
            {
                TmObjects.Teachers = teachers;
                Console.WriteLine(TmTimerTool.CurrentTime() + " TmObjects.Teachers: " + TmObjects.Teachers.Count);
            }
        }
        //void GetTeachers(TmParameter parameter)
        //{
        //    List<TmSoulerDB> teachers = TmParameterTool.GetJsonValue<List<TmSoulerDB>>(parameter, parameter.ElevenCode.ToString());
        //    Console.WriteLine(TmTimerTool.CurrentTime() + " TmTeacherController-Teachers: " + teachers.Count);
        //}   
        
    }
}
