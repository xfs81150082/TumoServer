using System;
using System.Collections.Generic;
using Tumo;
namespace Servers
{
    public class TmTeacherHandler : TmComponent
    {
        public override void OnTransferParameter(object obj , TmParameter parameter)
        {
            ElevenCode elevenCode = parameter.ElevenCode;
            switch (elevenCode)
            {
                case (ElevenCode.GetRolers):
                    Console.WriteLine(TmTimerTool.CurrentTime() + " TmTeacherHandler: " + elevenCode);
                    GetRolers(parameter);
                    break;
                case (ElevenCode.None):
                    break;
                default:
                    break;
            }
        }
        internal List<TmSoulerDB> Teachers;
        private void GetRolers(TmParameter parameter)
        {
            TmMysqlHandler.Instance.GetComponent<TmTeacherMysql>().OnTransferParameter(this, parameter);
            Console.WriteLine(TmTimerTool.CurrentTime() + " Teachers:" + Teachers.Count);
            if (this.Teachers != null)
            {
                TmParameter response = TmParameterTool.ToJsonParameter<List<TmSoulerDB>>(TenCode.Teacher, ElevenCode.GetRolers, ElevenCode.GetRolers.ToString(), this.Teachers);
                response.EcsId = parameter.EcsId;
                TmTcpSocket.Instance.Send(response);
            }
        }
      
    }
}
