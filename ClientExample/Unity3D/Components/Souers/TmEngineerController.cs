using System;
using System.Collections.Generic;
using System.Threading;
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
                case (ElevenCode.GetRolers):
                    Console.WriteLine(TmTimerTool.CurrentTime() + " TmEngineerController: " + elevenCode);
                    GetEngineersByUserId(parameter);
                    break;
                case (ElevenCode.GetRoler):
                    Console.WriteLine(TmTimerTool.CurrentTime() + " TmEngineerController: " + elevenCode);
                    GetRoler(parameter);
                    break;
                case (ElevenCode.None):
                    Console.WriteLine(TmTimerTool.CurrentTime() + " TmEngineerController: " + elevenCode);
                    break;
                default:
                    break;
            }
        }
        public TmSoulerDB Engineer;
        void GetEngineersByUserId(TmParameter tmp)
        {
            List<TmSoulerDB> engineers = TmParameterTool.GetJsonValue<List<TmSoulerDB>>(tmp, tmp.ElevenCode.ToString());
            Console.WriteLine(TmTimerTool.CurrentTime() + " engineers: " + engineers.Count);
            Engineer = engineers[0];
            for (int i = 0; i < engineers.Count; i++)
            {
                Console.WriteLine(TmTimerTool.CurrentTime() + " engineers: " + engineers.Count + " Id:" + engineers[i].Id + " Name:" + engineers[i].Name);
                TmConsoleLog.WriteLine(TmTimerTool.CurrentTime() + " engineers: " + engineers.Count + " Id:" + engineers[i].Id + " Name:" + engineers[i].Name);
            }
            EngineerLoginToServer(Engineer.Id);
        }
        void EngineerLoginToServer(int id)
        {
            Thread.Sleep(2000);
            TmTest.Instance.EngineerLogin(id);
        }
        void GetRoler(TmParameter tmp)
        {
            Engineer = TmParameterTool.GetJsonValue<TmSoulerDB>(tmp, tmp.ElevenCode.ToString());
            Console.WriteLine(TmTimerTool.CurrentTime() + " engineer: " + Engineer.Name);
        }

    }
}
