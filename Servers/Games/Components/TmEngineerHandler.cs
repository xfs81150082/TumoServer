using System;
using System.Collections.Generic;
using Tumo;
namespace Servers
{
    public class TmEngineerHandler : TmComponent
    {
        public override void OnTransferParameter(object obj , TmParameter parameter)
        {
            ElevenCode elevenCode = parameter.ElevenCode;
            switch (elevenCode)
            {
                case (ElevenCode.Login):
                    Console.WriteLine(TmTimerTool.CurrentTime() + " TmEngineerHandler: " + elevenCode);
                    EngineerLogin(parameter);
                    break;
                case (ElevenCode.None):
                    break;
                default:
                    break;
            }
        }

        private void EngineerLogin(TmParameter parameter)
        {
            int rolerId = TmParameterTool.GetJsonValue<int>(parameter, parameter.ElevenCode.ToString());
            //(TmMysqlHandler.Instance.GetComponent<TmEngineerMysql>() as TmEngineerMysql).GetItemsByUser(this, parameter);
            Console.WriteLine(TmTimerTool.CurrentTime() + " EngineerLogin.rolerId:" + rolerId);
        }

    }
}
