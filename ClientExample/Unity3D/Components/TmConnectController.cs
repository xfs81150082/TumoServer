using Tumo;
using System;
using System.Collections.Generic;
namespace ClientExample
{
    public class TmConnectController : TmEntity
    {
        private static TmConnectController _instance;
        public static TmConnectController Instance { get => _instance; }
        public override void TmAwake() { _instance = this; }
        //这个方法用来处理TPeer参数Mvc，并让结果给客户端响应（当客户端发起请求时调用）
        public override void OnTransferParameter(object obj, TmParameter parameter)
        {
            TenCode tenCode = parameter.TenCode;
            switch (tenCode)
            {
                case (TenCode.User):
                    Console.WriteLine(TmTimerTool.CurrentTime() + " TmConnect: " + tenCode);
                    TmGame.TmSence.GetComponent<TmUserController>().OnTransferParameter(this, parameter);
                    break;
                case (TenCode.Engineer):
                    Console.WriteLine(TmTimerTool.CurrentTime() + " TmConnect: " + tenCode);
                    TmGame.TmSence.GetComponent<TmEngineerController>().OnTransferParameter(this, parameter);
                    break;
                case (TenCode.Booker):
                    Console.WriteLine(TmTimerTool.CurrentTime() + " TmConnect: " + tenCode);
                    TmGame.TmSence.GetComponent<TmBookerController>().OnTransferParameter(this, parameter);
                    break;
                case (TenCode.Teacher):
                    Console.WriteLine(TmTimerTool.CurrentTime() + " TmConnect: " + tenCode);
                    TmGame.TmSence.GetComponent<TmTeacherController>().OnTransferParameter(this, parameter);
                    break;
                case (TenCode.StatusSync):
                    Console.WriteLine(TmTimerTool.CurrentTime() + " TmConnect: " + tenCode);
                    TmGame.TmSence.GetComponent<TmStatusSyncController>().OnTransferParameter(this, parameter);
                    break;
                case (TenCode.None):
                    break;
                default:
                    break;
            }
        }

    }
}