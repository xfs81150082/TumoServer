using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using Tumo;

namespace Servers
{
    public class TmMysqlConnection : TmSystem
    {
        public static MySqlConnection Connection { get; private set; } //创建一个数据库连接                                                     
        private string localhost = "111.231.50.160";           //IP地址
        private string database = "tumoworld";                 //数据库名    
        private string root = "tumo";                          //用户名  
        private string password = "qq81150082";                //密码  
        public bool IsConnecting { get; private set; } = false;
        public override void TmAwake()
        {
            base.TmAwake();
            ValTime = 4000;
        }
        public TmMysqlConnection()
        {
            StartConnectToMysql();
        }
        public override void TmUpdate()
        {
            StartConnectToMysql();
        }
        ///连接到数据库
        public void StartConnectToMysql()
        {
            if (!IsConnecting || Connection == null || Connection.State.ToString() != "Open")
            {
                try
                {
                    string connectionString = string.Format("Server = {0}; Database = {1}; User ID = {2}; Password = {3};", localhost, database, root, password);
                    Connection = new MySqlConnection(connectionString);
                    Connection.Open();
                    IsConnecting = true;
                    Console.WriteLine(TmTimerTool.CurrentTime() + " MySql版本号:{0},数据库:{1} ", Connection.ServerVersion, localhost);
                }
                catch (Exception ex)
                {
                    IsConnecting = false;
                    Console.WriteLine(TmTimerTool.CurrentTime() + " 连接MySql数据库,异常:{0} ", ex.Message);
                }
                Console.WriteLine(TmTimerTool.CurrentTime() + " IsConnecting:" + IsConnecting + " State:" + Connection.State);

            }
        }
        ///退出数据库
        public void QuitMysql()
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
