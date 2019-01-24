using System;
using System.Threading;
using Tumo;
namespace ClientExample
{
    class TmTest : TmSystem
    {
        private static TmTest _instance;
        public static TmTest Instance { get => _instance; }
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
            TmUser user = new TmUser();
            user.Username = "Tumo";
            user.Password = "123456";
            //TmParameter parameter = TmParameterTool.ToJsonParameter<TmUser>(TenCode.User, ElevenCode.UserLogin, ElevenCode.UserLogin.ToString(), user);
            TmParameter parameter = TmParameterTool.ToParameter(TenCode.User, ElevenCode.UserLogin);
            TmParameterTool.AddParameter(parameter, "Username", "Tumo");
            TmParameterTool.AddParameter(parameter, "Password", "123456");
            TmTcpSocket.Instance.Send(parameter);
            Console.WriteLine(TmTimerTool.CurrentTime() + " 用户登录36, Username:{0} Password:{1}", user.Username, user.Password);
            Console.WriteLine(TmTimerTool.CurrentTime() + " 用户登录37, Username:{0} Password:{1}", parameter.Parameters["Username"], parameter.Parameters["Password"]);
        }
        public void EngineerLogin(int rolerId)
        {
            TmParameter parameter = TmParameterTool.ToJsonParameter(TenCode.Engineer, ElevenCode.EngineerLogin, ElevenCode.EngineerLogin.ToString(), rolerId);
            TmTcpSocket.Instance.Send(parameter);
            Console.WriteLine(TmTimerTool.CurrentTime() + " Id:{0}", rolerId);
        }
        #endregion

    }
}