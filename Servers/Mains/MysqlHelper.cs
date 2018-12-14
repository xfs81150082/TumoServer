using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Servers
{
    public class MysqlHelper
    {
        public static MySqlConnection Connection;     //创建一个数据库连接                                                     
        //private string localhost = "127.0.0.1";     //IP地址
        //private string root = "root";               //用户名  
        private string localhost = "111.231.50.160";  //IP地址
        private string database = "tumoworld";        //数据库名    
        private string root = "tumo";                 //用户名  
        private string password = "qq81150082";       //密码  

        public MysqlHelper()
        {
            StartConnecting(new object());
        }

        public void StartConnecting(object obj)
        {
            if (Connection == null || Connection.State != ConnectionState.Connecting)
            {
                ConnectMysql();
            }
        }

        public void ConnectMysql()
        {
            string connectionString = string.Format("Server = {0}; Database = {1}; User ID = {2}; Password = {3};", localhost, database, root, password);
            OpenMysqlConnection(connectionString);
        } //连接到数据库
        
        // Connect to database    
        private void OpenMysqlConnection(string connectionString)
        {
            Connection = new MySqlConnection(connectionString);
            Connection.Open();
            Console.WriteLine("MySql版本号： " + Connection.ServerVersion);
        }

        public void QuitMysql()
        {
            CloseMysqlConnection();
        } //退出数据库

        // Disconnect from database    
        private void CloseMysqlConnection()
        {
            Connection.Close();
            Connection = null;
        }

        // MySQL Query    
        public void DoQuery(string sqlQuery)
        {
            IDbCommand dbCommand = Connection.CreateCommand();
            dbCommand.CommandText = sqlQuery;
            IDataReader reader = dbCommand.ExecuteReader();
            reader.Close();
            reader = null;
            dbCommand.Dispose();
            dbCommand = null;
        }

        // Get DataSet    
        public DataSet GetDataSet(string sqlString)
        {
            DataSet ds = new DataSet();
            try
            {
                MySqlDataAdapter da = new MySqlDataAdapter(sqlString, Connection);
                da.Fill(ds);
            }
            catch (Exception ee)
            {
                throw new Exception("SQL:" + sqlString + "\n" + ee.Message.ToString());
            }
            return ds;
        }

    }
}
