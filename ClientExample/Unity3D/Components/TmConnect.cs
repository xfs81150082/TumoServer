﻿using Tumo;
using System;
using System.Collections.Generic;
namespace ClientExample
{
    public class TmConnect : TmEntity
    {
        private static TmConnect _instance;
        public static TmConnect Instance { get => _instance; }
        public override void TmAwake() { base.TmAwake(); _instance = this; }
        //这个方法用来处理TPeer参数Mvc，并让结果给客户端响应（当客户端发起请求时调用）
        public override void OnTransferParameter(object obj, TmParameter parameter)
        {
            TenCode tenCode = parameter.TenCode;
            switch (tenCode)
            {
                case (TenCode.User):
                    Console.WriteLine(TmTimerTool.CurrentTime() + " TmLogin: " + tenCode);
                    TmGame.TmSence.GetComponent<TmUserController>().OnTransferParameter(this, parameter);
                    break;
                case (TenCode.Engineer):
                    Console.WriteLine(TmTimerTool.CurrentTime() + " TmLogin: " + tenCode);
                    TmGame.TmSence.GetComponent<TmEngineerController>().OnTransferParameter(this, parameter);
                    break;
                case (TenCode.None):
                    break;
                default:
                    break;
            }
        }
    }
}