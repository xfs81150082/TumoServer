using Tumo;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
namespace Servers
{
    class TmSkilldbMysql : TmComponent
    {
        internal string DatabaseFormName { get; set; }
        internal List<TmSkillDB> GetSkilldbsByRolerId(int rolerid)
        {
            MySqlCommand mySqlCommand = new MySqlCommand("select * from " + DatabaseFormName + " where rolerid = '" + rolerid + "'", TmMysqlConnection.Connection);  //读取数据函数  
            MySqlDataReader reader = mySqlCommand.ExecuteReader();
            try
            {
                List<TmSkillDB> list = new List<TmSkillDB>();
                while (reader.Read())
                {
                    if (reader.HasRows)
                    {
                        TmSkillDB item = new TmSkillDB();
                        item.Id = reader.GetInt32(0);
                        item.Name = reader.GetString(1);
                        item.SkillId = reader.GetInt32(2);
                        item.RolerId = reader.GetInt32(3);
                        item.Level = reader.GetInt32(4);
                        item.RoleType = (RoleType)reader.GetInt32(5);
                        item.Place = reader.GetInt32(6);
                        list.Add(item);
                    }
                }
                return list;
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
        }                               //读取表格
        internal List<TmSkillDB> GetSkilldbsById(int id)
        {
            MySqlCommand mySqlCommand = new MySqlCommand("select * from " + DatabaseFormName + " where id = '" + id + "'", TmMysqlConnection.Connection);  //读取数据函数  
            MySqlDataReader reader = mySqlCommand.ExecuteReader();
            try
            {
                List<TmSkillDB> list = new List<TmSkillDB>();
                while (reader.Read())
                {
                    if (reader.HasRows)
                    {
                        TmSkillDB item = new TmSkillDB();
                        item.Id = reader.GetInt32(0);
                        item.Name = reader.GetString(1);
                        item.SkillId = reader.GetInt32(2);
                        item.RolerId = reader.GetInt32(3);
                        item.Level = reader.GetInt32(4);
                        item.RoleType = (RoleType)reader.GetInt32(5);
                        item.Place = reader.GetInt32(6);
                        list.Add(item);
                    }
                }
                return list;
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
        }                                         //读取表格
        internal void InsertItemdb(string name, int inventoryid, int rolerid)
        {
            MySqlCommand mySqlCommand = new MySqlCommand("insert into " + DatabaseFormName + "(name,inventoryid,rolerid) values('" + name + "','" + inventoryid + "','" + rolerid + "')", TmMysqlConnection.Connection); //插入列表行
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
        internal void InsertItemdb(string name, int inventoryid, int rolerid, int equipquality, int place, int level, int count, int durability, int pice)
        {
            MySqlCommand mySqlCommand = new MySqlCommand("insert into " + DatabaseFormName + "(name,inventoryid,rolerid,equipquality,place,level,count,durability,pice) values('" + name + "','" + inventoryid + "','" + rolerid + "','" + equipquality + "','" + place + "','" + level + "','" + count + "','" + durability + "','" + pice + "')", TmMysqlConnection.Connection); //插入列表行
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
        internal void UpdateItemdb(int id, string name, int equipquality, int level)
        {
            MySqlCommand mySqlCommand = new MySqlCommand("update " + DatabaseFormName + " set name = '" + name + "', equipquality = '" + equipquality + "', level = '" + level + "' where id = '" + id + "'", TmMysqlConnection.Connection); //更新列表行
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
        internal void UpdateItemdb(int id, int rolerid, int place)
        {
            MySqlCommand mySqlCommand = new MySqlCommand("update " + DatabaseFormName + " set rolerid = '" + rolerid + "', place = '" + place + "' where id = '" + id + "'", TmMysqlConnection.Connection); //更新列表行
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
        internal void UpdateItemdb(int id, int count, int durability, int pice)
        {
            MySqlCommand mySqlCommand = new MySqlCommand("update " + DatabaseFormName + " set count = '" + count + "', durability = '" + durability + "', pice = '" + pice + "' where id = '" + id + "'", TmMysqlConnection.Connection); //更新列表行
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
        internal void RemoveItemdb(int id)
        {
            MySqlCommand mySqlCommand = new MySqlCommand("delete from " + DatabaseFormName + " where id = '" + id + "'", TmMysqlConnection.Connection); //插入用户  
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
