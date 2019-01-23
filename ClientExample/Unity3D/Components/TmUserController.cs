﻿using System;
using System.Collections.Generic;
using System.Threading;
using Tumo;
namespace ClientExample
{
    class TmUserController : TmComponent
    {
        public override void OnTransferParameter(object obj, TmParameter parameter)
        {
            ElevenCode elevenCode = parameter.ElevenCode;
            switch (elevenCode)
            {
                case (ElevenCode.Login):
                    Console.WriteLine(TmTimerTool.CurrentTime() + " TmUserController: " + elevenCode);
                    UserLoginGetEngineer(parameter);
                    break;
                default:
                    break;
            }
        }
        public TmSoulerDB SoulerDB;
        void UserLoginGetEngineer(TmParameter tmp)
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