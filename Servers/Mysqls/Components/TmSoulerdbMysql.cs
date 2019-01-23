using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using Tumo;

namespace Servers
{
    public class TmSoulerdbMysql : TmComponent
    {
        public string TmSoulerdbName { get; set; } = "engineeritem";
        public void GetItemsByUser(object obj, TmParameter tmp)
        {
            TmUser user1 = TmParameterTool.GetJsonValue<TmUser>(tmp, tmp.ElevenCode.ToString());
            List<TmSoulerDB> itemDBs = GetSoulItemdbsByUserId(user1.Id);
            if (itemDBs.Count > 0)
            {
                (obj as TmUserHandler).TmSoulerDbs = itemDBs;
            }
            else
            {
                Console.WriteLine(TmTimerTool.CurrentTime() + " 没有角色");
            }
        }
        public void GetTmSoulerdbs(object obj)
        {
            List<TmSoulerDB> dbs = GetSoulItemdbs();
            if (dbs.Count > 0)
            {
                //(obj as TmEngineerHandler).TmSoulerDbs = dbs;
            }
            else
            {
                Console.WriteLine(TmTimerTool.CurrentTime() + " 没有角色");
            }
        }
        void GetTmSoulerDB(TmParameter tmp)
        {
            TmSoulerDB item2 = GetSoulerdbById(int.Parse(tmp.Key));
            if (item2 != null)
            {
                Console.WriteLine("TmSoulerdbMysql: " + item2.Name);
            }
            else
            {
                Console.WriteLine("角色不存在");
            }
        }
        List<TmSoulerDB> GetSoulItemdbs()
        {
            MySqlCommand mySqlCommand = new MySqlCommand("select * from " + TmSoulerdbName, TmMysqlConnection.Connection);//读取数据函数  
            MySqlDataReader reader = mySqlCommand.ExecuteReader();
            try
            {
                List<TmSoulerDB> itemDBs = new List<TmSoulerDB>();
                while (reader.Read())
                {
                    if (reader.HasRows)
                    {
                        TmSoulerDB item = new TmSoulerDB();
                        item.Id = reader.GetInt32(0);
                        item.Name = reader.GetString(1);
                        item.SoulId = reader.GetInt32(2);
                        item.UserId = reader.GetInt32(3);
                        item.Exp = reader.GetInt32(4);
                        item.Level = reader.GetInt32(5);
                        item.Hp = reader.GetInt32(6);
                        item.Mp = reader.GetInt32(7);
                        item.Coin = reader.GetInt32(8);
                        item.Diamond = reader.GetInt32(9);
                        item.SenceId = reader.GetInt32(10);
                        item.NodeId = reader.GetInt32(11);
                        item.px = reader.GetDouble(12);
                        item.py = reader.GetDouble(13);
                        item.pz = reader.GetDouble(14);
                        item.ax = reader.GetDouble(15);
                        item.ay = reader.GetDouble(16);
                        item.az = reader.GetDouble(17);
                        item.ServerId = reader.GetInt32(18);
                        item.CreateDate = reader.GetString(19);
                        //Console.WriteLine(userId + " " + reader.FieldCount + " " + item.Id);
                        itemDBs.Add(item);
                    }
                }
                return itemDBs;
            }
            catch (Exception)
            {
                Console.WriteLine("查询失败...168");
                return null;
            }
            finally
            {
                reader.Close();
            }
        }                          //读取表格//得到所有角色列表         
        List<TmSoulerDB> GetSoulItemdbsByUserId(int userId)
        {
            MySqlCommand mySqlCommand = new MySqlCommand("select * from " + TmSoulerdbName + " where userid = '" + userId + "'", TmMysqlConnection.Connection);//读取数据函数  
            MySqlDataReader reader = mySqlCommand.ExecuteReader();
            try
            {
                List<TmSoulerDB> itemDBs = new List<TmSoulerDB>();
                while (reader.Read())
                {
                    if (reader.HasRows)
                    {
                        TmSoulerDB item = new TmSoulerDB();
                        item.Id = reader.GetInt32(0);
                        item.Name = reader.GetString(1);
                        item.SoulId = reader.GetInt32(2);
                        item.UserId = reader.GetInt32(3);
                        item.Exp = reader.GetInt32(4);
                        item.Level = reader.GetInt32(5);
                        item.Hp = reader.GetInt32(6);
                        item.Mp = reader.GetInt32(7);
                        item.Coin = reader.GetInt32(8);
                        item.Diamond = reader.GetInt32(9);
                        item.SenceId = reader.GetInt32(10);
                        item.NodeId = reader.GetInt32(11);
                        item.px = reader.GetDouble(12);
                        item.py = reader.GetDouble(13);
                        item.pz = reader.GetDouble(14);
                        item.ax = reader.GetDouble(15);
                        item.ay = reader.GetDouble(16);
                        item.az = reader.GetDouble(17);
                        item.ServerId = reader.GetInt32(18);
                        item.CreateDate = reader.GetString(19);
                        //Console.WriteLine(userId + " " + reader.FieldCount + " " + item.Id);
                        itemDBs.Add(item);
                    }
                }
                return itemDBs;
            }
            catch (Exception)
            {
                Console.WriteLine("查询失败...168");
                return null;
            }
            finally
            {
                reader.Close();
            }
        }        //读取表格//得到userid所有角色列表         
        TmSoulerDB GetSoulerdbById(int id)
        {
            MySqlCommand mySqlCommand = new MySqlCommand("select * from " + TmSoulerdbName + " where id = '" + id + "'", TmMysqlConnection.Connection);//读取数据函数  
            MySqlDataReader reader = mySqlCommand.ExecuteReader();
            try
            {
                TmSoulerDB item = new TmSoulerDB();
                while (reader.Read())
                {
                    if (reader.HasRows)
                    {
                        item.Id = reader.GetInt32(0);
                        item.Name = reader.GetString(1);
                        item.SoulId = reader.GetInt32(2);
                        item.UserId = reader.GetInt32(3);
                        item.Exp = reader.GetInt32(4);
                        item.Level = reader.GetInt32(5);
                        item.Hp = reader.GetInt32(6);
                        item.Mp = reader.GetInt32(7);
                        item.Coin = reader.GetInt32(8);
                        item.Diamond = reader.GetInt32(9);
                        item.SenceId = reader.GetInt32(10);
                        item.NodeId = reader.GetInt32(11);
                        item.px = reader.GetDouble(12);
                        item.py = reader.GetDouble(13);
                        item.pz = reader.GetDouble(14);
                        item.ax = reader.GetDouble(15);
                        item.ay = reader.GetDouble(16);
                        item.az = reader.GetDouble(17);
                        item.ServerId = reader.GetInt32(18);
                        item.CreateDate = reader.GetString(19);
                    }
                }
                return item;
            }
            catch (Exception)
            {
                Console.WriteLine("查询失败...");
                return null;
            }
            finally
            {
                reader.Close();
            }
        }                         //读取表格//得到id单个角色列表
        void InsertItemdb(string name, int soulId, int userid, int exp, int level, int hp, int mp, int coin, int diamond, int senceId, double px, double py, double pz, double ax, double ay, double az, int serverid)
        {
            MySqlCommand mySqlCommand = new MySqlCommand("insert into " + TmSoulerdbName + "(name,soulId,userid,exp,level,hp,mp,coin,diamond,senceId,px,py,pz,ax,ay,az,serverid) values('" + name + "','" + soulId + "','" + userid + "','" + exp + "','" + level + "','" + hp + "','" + mp + "','" + coin + "','" + diamond + "','" + senceId + "','" + px + "','" + py + "','" + pz + "','" + ax + "','" + ay + "','" + az + "','" + serverid + "')", TmMysqlConnection.Connection);  //插入列表行
            try
            {
                mySqlCommand.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                string message = ex.Message;
                Console.WriteLine("插入数据失败..." + message);
            }
        }
        void UpdateItemdb(int id, int exp, int level, int hp, int mp, int coin, int diamond)
        {
            MySqlCommand mySqlCommand = new MySqlCommand("update " + TmSoulerdbName + " set exp = '" + exp + "', level = '" + level + "', hp = '" + hp + "', mp = '" + mp + "', coin = '" + coin + "', diamond = '" + diamond + "' where id = '" + id + "'", TmMysqlConnection.Connection); //更新列表行
            try
            {
                mySqlCommand.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                string message = ex.Message;
                Console.WriteLine("修改数据失败..." + message);
            }
        }
        void RemoveItemdb(int id)
        {
            MySqlCommand mySqlCommand = new MySqlCommand("delete from " + TmSoulerdbName + " where id = '" + id + "'", TmMysqlConnection.Connection); //插入用户  
            try
            {
                mySqlCommand.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                string message = ex.Message;
                Console.WriteLine("删除数据失败..." + message);
            }
        }
    }
}