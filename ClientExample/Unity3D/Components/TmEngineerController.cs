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
                case (ElevenCode.None):
                    Console.WriteLine(TmTimerTool.CurrentTime() + " TmEngineerController: " + elevenCode);
                    break;
                default:
                    break;
            }
        }
        public TmSoulerDB SoulerDB;
        void GetEngineersByUserId(TmParameter tmp)
        {
            List<TmSoulerDB> engineers = TmParameterTool.GetJsonValue<List<TmSoulerDB>>(tmp, tmp.ElevenCode.ToString());
            Console.WriteLine(TmTimerTool.CurrentTime() + " engineers: " + engineers.Count);
            SoulerDB = engineers[0];
            for (int i = 0; i < engineers.Count; i++)
            {
                Console.WriteLine(TmTimerTool.CurrentTime() + " engineers: " + engineers.Count + " Id:" + engineers[i].Id + " Name:" + engineers[i].Name);
                TmConsoleLog.WriteLine(TmTimerTool.CurrentTime() + " engineers: " + engineers.Count + " Id:" + engineers[i].Id + " Name:" + engineers[i].Name);
            }
            EngineerLoginToServer(SoulerDB.Id);
        }
        void EngineerLoginToServer(int id)
        {
            Thread.Sleep(2000);
            TmTest.Instance.EngineerLogin(id);
        }

    }
}
