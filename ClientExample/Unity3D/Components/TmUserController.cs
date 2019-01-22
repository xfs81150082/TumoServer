using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Tumo;
using Tumo.Models;
using ClientExample;

namespace ClientExample
{
    class TmUserController : TmComponent
    {    
        public override void OnTransferParameter(TmParameter tmp)
        {
            ElevenCode elevenCode = tmp.ElevenCode;
            switch (elevenCode)
            {
                case (ElevenCode.Login):
                    List<TmSoulerDB> engineers = TmParameterTool.GetJsonValue<List<TmSoulerDB>>(tmp, tmp.ElevenCode.ToString());
                    for (int i = 0; i < engineers.Count; i++)
                    {
                        Console.WriteLine(TmTimerTool.CurrentTime() + " engineers: " + engineers.Count + " Id:" + engineers[i].Id + " Name:" + engineers[i].Name);
                        TmConsoleLog.WriteLine(TmTimerTool.CurrentTime() + " engineers: " + engineers.Count + " Id:" + engineers[i].Id + " Name:" + engineers[i].Name);
                    }
                    
                    break;
                default:
                    break;
            }
        }

        void RolerLoginTest(TmSoulerDB soulerDB)
        {
            TmParameter tm = TmParameterTool.ToJsonParameter(TenCode.TmEngineerHandler, ElevenCode.Login, ElevenCode.Login.ToString(), soulerDB.Id);
            TmTcpSocket.Instance.Send(tm);
            Console.WriteLine(TmTimerTool.CurrentTime() + " Test1-EngineerLogin: " + soulerDB.Id);
        }

    }
}
