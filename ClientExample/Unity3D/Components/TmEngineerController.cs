using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ClientExample;
using Tumo;
using Tumo.Models;

namespace ClientExample
{
    class TmEngineerController : TmComponent
    {
        public override void OnTransferParameter(TmParameter mvc)
        {
            ElevenCode elevenCode = mvc.ElevenCode;
            switch (elevenCode)
            {
                case (ElevenCode.Login):
                    Console.WriteLine(TmTimerTool.CurrentTime() + " EngineerLogin: " + elevenCode);

                    break;         
                default:
                    break;
            }
        }
        void GetBookersAndTeachers(TmParameter parameter)
        {
            List<TmSoulerDB> bookers = TmParameterTool.GetJsonValue<List<TmSoulerDB>>(parameter, "bookers");
            List<TmSoulerDB> teachers = TmParameterTool.GetJsonValue<List<TmSoulerDB>>(parameter, "teachers");

            Console.WriteLine(TmTimerTool.CurrentTime() + " Test1-EngineerLogin: "  );
        }


    }
}
