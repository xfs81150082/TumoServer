using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tumo;

namespace Servers
{
    public class TmMysql : TmEntity
    {
        public static MySqlConnection Connection;     //创建一个数据库连接                                                     
        private string localhost = "111.231.50.160";  //IP地址
        private string database = "tumoworld";        //数据库名    
        private string root = "tumo";                 //用户名  
        private string password = "qq81150082";       //密码  

        public TmMysql()
        {
            StartConnecting(new object());
        }

        public void StartConnecting(object obj)
        {
            if (Connection == null || Connection.State != ConnectionState.Connecting)
            {
            string connectionString = string.Format("Server = {0}; Database = {1}; User ID = {2}; Password = {3};", localhost, database, root, password);
            Connection = new MySqlConnection(connectionString);
            Connection.Open();
            Console.WriteLine("MySql版本号： " + Connection.ServerVersion);
            }
        }//连接到数据库

    }
}
