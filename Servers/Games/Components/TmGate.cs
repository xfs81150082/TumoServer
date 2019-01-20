using Tumo;
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
        }
        
        //这个方法用来处理TPeer参数Mvc，并让结果给客户端响应（当客户端发起请求时调用）
        public override void OnTransferParameter(TmParameter parameter)
        {
            TenCode tenCode = parameter.TenCode;
            switch (tenCode)
            {
                case (TenCode.TmUserHandler):
                    Console.WriteLine(TmTimerTool.CurrentTime() + " TmLogin: " + tenCode);
                    this.GetComponent<TmUserHandler>().OnTransferParameter(parameter);
                    break;
                case (TenCode.TmEngineerHandler):
                    Console.WriteLine(TmTimerTool.CurrentTime() + " TmLogin: " + tenCode);
                    this.GetComponent<TmEngineerHandler>().OnTransferParameter(parameter);
                    break;
                case (TenCode.None):
                    break;
                default:
                    break;
            }

        }
        
    }
}
