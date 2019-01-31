using System;
using System.Collections.Generic;
using Tumo;
using MySql.Data.MySqlClient;

namespace Servers
{
    class TmTaskMysql : TmComponent
    {
        string DatabaseFormName { get; set; }

        public override void OnTransferParameter(object sender, TmParameter parameter)
        {
            ElevenCode elevenCode = parameter.ElevenCode;
            switch (elevenCode)
            {
                case (ElevenCode.Login):
                    Console.WriteLine(TmTimerTool.CurrentTime() + " TmEngineerMysql: " + elevenCode);

                    break;
                case (ElevenCode.None):
                    break;
                default:
                    break;
            }
        }



    }
}
