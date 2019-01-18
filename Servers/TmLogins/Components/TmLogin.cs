using Tumo;
using Servers.Logins.Handlers;
using Servers.Logins.Mysqlers;
using Servers.Logins.Senders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Servers
{
    public class TmLogin : TmEntity
    {
        public override void TmAwake()
        {
            base.TmAwake();
            Registes();
        }
    
        public void OnTransferParameter(TmRequest mvc)
        {
            ////创建一个空的处理程序（handler）
            //LoginBase user;
            ////根据操作代码（TenCode），从字典中取出处理程序
            //Logins.TryGetValue(mvc.NineCode.ToString(), out user);
            //if (user != null)
            //{
            //    user.OnTransferParameter(mvc);
            //}
            //else
            //{
            //    Console.WriteLine("寻找Login失败，通过NineCode:" + mvc.NineCode);
            //}
        }

        void Registes()
        {
            AddComponent(new TmLoginMysql());
            AddComponent(new TmLoginHandler());
        }

    }
}
