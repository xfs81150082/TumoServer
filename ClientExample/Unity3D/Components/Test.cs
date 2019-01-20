using ClientExample;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Timers;
using Tumo;

namespace ClientExample
{
    class Test : TmSystem
    {
        private bool IsLogin = false;

        public override void TmUpdate()
        {
            TestLogin();
        }

        // 当时间发生的时候需要进行的逻辑处理等    // 在这里仅仅是一种方式，可以实现这样的方式很多    
        void TestLogin()
        {
            if (IsLogin == false)
            {
                IsLogin = true;
                Console.WriteLine(TmTimerTool.CurrentTime() + " IsLogin:{0}", IsLogin.ToString());
                EngineerLogin();
            }
        }

        void EngineerLogin()
        {
            int Id = 100001;
            TmParameter mvc = TmTransferTool.ToJsonParameter(TenCode.TmEngineer, ElevenCode.Login);
            mvc.RolerId = Id.ToString();
            TmConnect.Instance.OnTransferParameter(mvc);
            Console.WriteLine(TmTimerTool.CurrentTime() + " Id:{0}", mvc.RolerId);
        }

    }
}
