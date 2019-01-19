using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Tumo;
using Tumo.Models;

namespace ClientExample.Logins.Controllers
{
    class TumoLoginController : LoginBase
    {
        public override string Code => NineCode.Controller.ToString();

        public static TumoLoginController Instance { get => _instance; }
        private static TumoLoginController _instance;
        public Dictionary<string, LoginControllerBase> Controllers = new Dictionary<string, LoginControllerBase>();


        public TumoLoginController()
        {
            _instance = this;
            Reisters();
        }
        
        public override void OnTransferParameter(TmParameter mvc)
        {
            //创建一个空的处理程序（handler）
            LoginControllerBase controller;
            //根据操作代码（OneCode），从字典中取出处理程序
            Controllers.TryGetValue(mvc.TenCode.ToString(), out controller);
            if (controller != null)
            {
                controller.OnTransferParameter(mvc);
            }
            else
            {
                Console.WriteLine("寻找controller失败，通过NineCode:" + mvc.NineCode);
            }
        }

        private void Reisters()
        {
            new UserLogin();
            new EngineerLogin();

        }




    }
}
