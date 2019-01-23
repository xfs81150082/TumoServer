using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tumo;

namespace Servers
{
    public class TmMysqlHandler : TmEntity
    {
        private static TmMysqlHandler _instance;
        public static TmMysqlHandler Instance { get => _instance;  }
        public override void TmAwake()
        {
            base.TmAwake();
            _instance = this;
            this.AddComponent(new TmUserMysql());
            this.AddComponent(new TmEngineerMysql());
            this.AddComponent(new TmBookerMysql());
            this.AddComponent(new TmTeacherMysql());
        }
    }
}
