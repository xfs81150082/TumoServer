using Tumo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Servers.Games;
using Servers.Games.Mysqlers.Souls;

namespace Servers.Games.Mysqlers
{
    public class TumoGameMysql : GameBase
    {
        public override string Code => NineCode.Game.ToString();
        private static TumoGameMysql _instance;
        public static TumoGameMysql Instance { get => _instance; }
        public Dictionary<string, GameMysqlBase> GameMysqls = new Dictionary<string, GameMysqlBase>();

        public TumoGameMysql()
        {
            _instance = this;
            Registes();
        }

        public void Init()  {    }

        //这个方法用来处理参数Mvc，并让结果给客户端响应（当客户端发起请求时调用）
        public override void OnTransferParameter(TmParameter mvc)
        {
            //创建一个空的处理程序（handler）
            GameMysqlBase mysqlTabler;
            //根据操作代码（TenCode），从字典中取出处理程序
            GameMysqls.TryGetValue(mvc.TenCode.ToString(), out mysqlTabler);
            if (mysqlTabler != null)
            {
                mysqlTabler.OnTransferParameter(mvc);
            }
            else
            {
                Console.WriteLine("寻找GameMysqls失败，通过TenCode:" + mvc.TenCode);
            }
        }

        void Registes()
        {
            //new DressedMysqlTabler();
            //new KnapsackMysqlTabler();
            //new SmithyMysqlTabler();
            //new TerrainMysqlTabler();

            //new AbilityMysqlTabler();
            //new BuffMysqlTabler();
            //new InbornMysqlTabler();
            //new AssignmentMysqlTabler();

            new BookerMysqlTabler();
            new TeacherMysqlTabler();
            new EngineerMysqlTabler();

        }

      
    }
}
