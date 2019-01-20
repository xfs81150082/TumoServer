﻿using Tumo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Servers
{
    public class TmGate : TmEntity
    {
        private static TmGate _instance;
        public static TmGate Instance { get => _instance; }  
        public override void TmAwake()
        {
            base.TmAwake();
            _instance = this;
            //AddComponent(new TmLogin());
            //AddComponent(new TmUser());
            //AddComponent(new TmEngineer());

            TmLog.WriteLine(TmTimerTool.CurrentTime() + " " + this.GetType().Name + " 组件加载完成。 ");
        }
        
        //这个方法用来处理TPeer参数Mvc，并让结果给客户端响应（当客户端发起请求时调用）
        public override void OnTransferParameter(TmParameter parameter)
        {
            TenCode tenCode = parameter.TenCode;
            switch (tenCode)
            {
                case (TenCode.TmUser):
                    Console.WriteLine(TmTimerTool.CurrentTime() + " TmLogin: " + tenCode);
                    this.GetComponent<TmUser>().OnTransferParameter(parameter);
                    break;
                case (TenCode.TmEngineer):
                    Console.WriteLine(TmTimerTool.CurrentTime() + " TmLogin: " + tenCode);
                    this.GetComponent<TmEngineer>().OnTransferParameter(parameter);
                    break;
                case (TenCode.None):
                    break;
                default:
                    break;
            }

        }
        
    }
}