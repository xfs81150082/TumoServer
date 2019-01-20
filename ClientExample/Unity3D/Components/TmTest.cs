using ClientExample;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Timers;
using Tumo;

namespace ClientExample
{
    class TmTest : TmSystem
    {
        private bool IsUserLogin = false;
        private bool IsLogin = false;
        public override void TmUpdate()
        {
            TestTmUserLogin();
        }

        #region
        void TestTmUserLogin()
        {
            Thread.Sleep(4000);
            if (IsUserLogin == false)
            {
                IsUserLogin = true;
                Console.WriteLine(TmTimerTool.CurrentTime() + " IsUserLogin:{0}", IsUserLogin.ToString());
                TmUserLogin();
            }
        }
        void TmUserLogin()
        {            
            TmUser tmUser = new TmUser();
            tmUser.Username = "Tumo";
            tmUser.Password = "123456";
            TmParameter mvc = TmTransferTool.ToJsonParameter(TenCode.TmUserHandler, ElevenCode.Login, ElevenCode.Login.ToString(), tmUser);
            TmNetTcp.Instance.Send(mvc);
            Console.WriteLine(TmTimerTool.CurrentTime() + " 用户登录, Username:{0} Password:{1}", tmUser.Username, tmUser.Password);
        }
        #endregion

        #region
        void TestLogin()
        {
            if (IsLogin == false)
            {
                IsLogin = true;
                Console.WriteLine(TmTimerTool.CurrentTime() + " IsLogin:{0}", IsLogin.ToString());
                EngineerLogin(100001);
            }
        }
        void EngineerLogin(int rolerId)
        {
            TmParameter mvc = TmTransferTool.ToJsonParameter(TenCode.TmUserHandler, ElevenCode.Login, ElevenCode.Login.ToString(), rolerId);
            TmNetTcp.Instance.Send(mvc);
            Console.WriteLine(TmTimerTool.CurrentTime() + " Id:{0}", rolerId);
        }
        #endregion

    }
}