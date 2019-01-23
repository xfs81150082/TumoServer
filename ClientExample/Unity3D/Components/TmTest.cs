using System;
using System.Threading;
using Tumo;
namespace ClientExample
{
     class TmTest : TmSystem
    {
        private static TmTest _instance;
        public static TmTest Instance { get => _instance;  }
        public override void TmAwake() { base.TmAwake(); _instance = this; }

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
            TmParameter mvc = TmParameterTool.ToJsonParameter(TenCode.TmUserHandler, ElevenCode.Login, ElevenCode.Login.ToString(), tmUser);
            TmTcpSocket.Instance.Send(mvc);
            Console.WriteLine(TmTimerTool.CurrentTime() + " 用户登录, Username:{0} Password:{1}", tmUser.Username, tmUser.Password);
        }
        public void EngineerLogin(int rolerId)
        {
            TmParameter parameter = TmParameterTool.ToJsonParameter(TenCode.TmEngineerHandler, ElevenCode.Login, ElevenCode.Login.ToString(), rolerId);
            TmTcpSocket.Instance.Send(parameter);
            Console.WriteLine(TmTimerTool.CurrentTime() + " Id:{0}", rolerId);
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
        #endregion
    }
}