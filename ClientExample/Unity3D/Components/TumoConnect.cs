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
        
        public TmConnect()
        {
            _instance = this;
        }

        //这个方法用来处理TPeer参数Mvc，并让结果给客户端响应（当客户端发起请求时调用）
        public override void OnTransferParameter(TmParameter parameter)
        {
            TenCode tenCode = parameter.TenCode;
            switch (tenCode)
            {
                case (TenCode.TmUser):
                    Console.WriteLine(TmTimerTool.CurrentTime() + " TmLogin: " + tenCode);

                    break;
                case (TenCode.TmEngineer):
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
