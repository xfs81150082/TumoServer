using Tumo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Servers.Logins.Mysqlers
{
    class TumoLoginMysql : LoginBase
    {
        public override string Code => NineCode.Mysqler.ToString();

        public static TumoLoginMysql Instance { get => _instance; }
        private static TumoLoginMysql _instance;
        public Dictionary<string, LoginMysqlBase> LoginMysqls = new Dictionary<string, LoginMysqlBase>();

        public TumoLoginMysql()
        {
            _instance = this;
            Reisters();
        }

        public override void OnTransferParameter(MvcParameter mvc)
        {
            //创建一个空的处理程序（handler）
            LoginMysqlBase controller;
            //根据操作代码（OneCode），从字典中取出处理程序
            LoginMysqls.TryGetValue(mvc.TenCode.ToString(), out controller);
            if (controller != null)
            {
                controller.OnTransferParameter(mvc);
            }
            else
            {
                Console.WriteLine("寻找LoginSender失败，通过NineCode:" + mvc.NineCode);
            }
        }

        private void Reisters()
        {
            new EngineerloginMysql();
            new UserLoginMysql();

        }
    }
}
