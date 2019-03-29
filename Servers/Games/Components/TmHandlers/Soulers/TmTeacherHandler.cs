using System;
using System.Collections.Generic;
using Tumo;
namespace Servers
{
    public class TmTeacherHandler : TmEntity
    {
        public override void TmAwake()
        {
            base.TmAwake();
            AddComponent(new TmStatusSyncHandler());
        }
        public override void OnTransferParameter(object obj, TmParameter parameter)
        {
            ElevenCode elevenCode = parameter.ElevenCode;
            switch (elevenCode)
            {
                case (ElevenCode.GetRolers):
                    Console.WriteLine(TmTimerTool.CurrentTime() + " TmTeacherHandler: " + elevenCode);
                    GetRolersByRolerId(parameter);
                    break;
                case (ElevenCode.StatusSync):
                    Console.WriteLine(TmTimerTool.CurrentTime() + " TmStatusSyncHandler: " + elevenCode);
                    Parent.GetComponent<TmStatusSyncHandler>().OnTransferParameter(this, parameter);
                    break;
                case (ElevenCode.None):
                    break;
                default:
                    break;
            }
        }
        internal List<TmSoulerDB> Teachers;
        private void GetRolersByRolerId(TmParameter parameter)
        {
            bool yes = false;
            int count = 0;
            while (!yes)
            {
                if (this.Teachers != null)
                {
                    TmParameter response = TmParameterTool.ToJsonParameter<List<TmSoulerDB>>(TenCode.Teacher, ElevenCode.GetRolers, ElevenCode.GetRolers.ToString(), this.Teachers);
                    response.Keys.Add(parameter.Keys[0]);
                    TmTcpSocket.Instance.Send(response);
                    yes = true;
                }
                else
                {
                    TmMysqlHandler.Instance.GetComponent<TmTeacherMysql>().OnTransferParameter(this, parameter);
                    Console.WriteLine(TmTimerTool.CurrentTime() + " Teachers:" + Teachers.Count);
                    count += 1;
                }
                if (count > 4)
                {
                    yes = true;
                    break;
                }
            }
        }


    }
}
