using Tumo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ClientExample
{
    public class TmConnect : TmEntity
    {
        public static TmConnect Instance { get => _instance; }
        private static TmConnect _instance;
        public override void TmAwake()
        {
            base.TmAwake();
            _instance = this;
        }
        public TmConnect() {  }

        //这个方法用来处理TPeer参数Mvc，并让结果给客户端响应（当客户端发起请求时调用）
        public override void OnTransferParameter(TmParameter parameter)
        {
            TenCode tenCode = parameter.TenCode;
            switch (tenCode)
            {
                case (TenCode.TmUserController):
                    Console.WriteLine(TmTimerTool.CurrentTime() + " TmLogin: " + tenCode);

                    break;
                case (TenCode.TmEngineerController):
                    Console.WriteLine(TmTimerTool.CurrentTime() + " TmLogin: " + tenCode);

                    break;
                case (TenCode.None):
                    break;
                default:
                    break;
            }

        }



    }
}
