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

namespace Servers.Sences.Nodes.Mysqlers
{
    class TumoNodeMysql : NodeBase
    {
        public override string Code => NineCode.Mysqler.ToString();
        public static TumoNodeMysql Instance { get => _instance; }
        private static TumoNodeMysql _instance;
        public Dictionary<string, NodeMysqlBase> NodeMysqlers = new Dictionary<string, NodeMysqlBase>();

        public override void OnTransferParameter(MvcParameter mvc)
        {
            //创建一个空的处理程序（handler）
            NodeMysqlBase measurementMysql;
            //根据操作代码（TenCode），从字典中取出处理程序
            NodeMysqlers.TryGetValue(mvc.TenCode.ToString(), out measurementMysql);
            if (measurementMysql != null)
            {
                measurementMysql.OnTransferParameter(mvc);
            }
            else
            {
                Console.WriteLine("寻找MeasurementMysql失败，通过TenCode:" + mvc.TenCode);
            }
        }
        
        public TumoNodeMysql()
        {
            _instance = this;
            Registers();
        }

        private void Registers()
        {
            //new NodeMysql();
            new BookerMysql();
            new TeacherMysql();
            new EngineerMysql();

        }

    }
}
