using Tumo;
using Tumo.Models;
using MySql.Data.MySqlClient;
using Servers.Sences.Nodes;
using Servers.Sences.Nodes.Mysqlers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Servers.Sences.Rolers.Mysqlers
{
    class TumoRolerMysql : RolerBase
    {
        public override string Code => NineCode.Mysqler.ToString();
        public static TumoRolerMysql Instance { get => _instance; }
        private static TumoRolerMysql _instance;
        public Dictionary<string, RolerMysqlBase> RolerMysqls = new Dictionary<string, RolerMysqlBase>();

        public override void OnTransferParameter(TmParameter mvc)
        {
            //创建一个空的处理程序（handler）
            RolerMysqlBase measurementMysql;
            //根据操作代码（TenCode），从字典中取出处理程序
            RolerMysqls.TryGetValue(mvc.TenCode.ToString(), out measurementMysql);
            if (measurementMysql != null)
            {
                measurementMysql.OnTransferParameter(mvc);
            }
            else
            {
                Console.WriteLine("寻找RolerMysql失败，通过TenCode:" + mvc.TenCode);
            }
        }
        
        public TumoRolerMysql()
        {
            _instance = this;
            Registers();
        }

        private void Registers()
        {
            new RolerMysqlInfo();
            new BookerMysql();
            new TeacherMysql();
            new EngineerMysql();

        }

    }
}
