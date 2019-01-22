using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Tumo;
using Tumo.Models;

namespace ClientExample
{
    class TmUserController : TmComponent
    {
        public static event EventHandler<TmParameter> OnLoginEngineersEvent;
        public override void OnTransferParameter(TmParameter tmp)
        {
            ElevenCode elevenCode = tmp.ElevenCode;
            switch (elevenCode)
            {
                case (ElevenCode.Login):
                    Console.WriteLine(TmTimerTool.CurrentTime() + " TmUserController: " + elevenCode);
                    RolerLoginOfEngineer(tmp);
                    break;
                default:
                    break;
            }
        }        
        void RolerLoginOfEngineer(TmParameter tmp)
        {
            List<TmSoulerDB> engineers = TmParameterTool.GetJsonValue<List<TmSoulerDB>>(tmp, tmp.ElevenCode.ToString());
             Console.WriteLine(TmTimerTool.CurrentTime() + " engineers: " + engineers.Count);

            //OnLoginEngineersEvent(this, tmp);

            for (int i = 0; i < engineers.Count; i++)
            {
                Console.WriteLine(TmTimerTool.CurrentTime() + " engineers: " + engineers.Count + " Id:" + engineers[i].Id + " Name:" + engineers[i].Name);
                TmConsoleLog.WriteLine(TmTimerTool.CurrentTime() + " engineers: " + engineers.Count + " Id:" + engineers[i].Id + " Name:" + engineers[i].Name);
            }
        }

    }
}
