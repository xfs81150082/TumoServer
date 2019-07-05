using Tumo;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
namespace Servers
{
    class TmSkilldbMysql : TmComponent
    {
        internal string DatabaseFormName { get; set; }
        internal List<TmSkillDB> GetSkillDBsListByRolerId(int rolerid)
        {
            MySqlCommand mySqlCommand = new MySqlCommand("select * from " + DatabaseFormName + " where rolerid = '" + rolerid + "'", TmMysqlConnection.Connection);  //读取数据函数  
            MySqlDataReader reader = mySqlCommand.ExecuteReader();
            try
            {
                List< TmSkillDB> dict = new List< TmSkillDB>();
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
                        dict.Add(item);
                    }
                }
                return dict;
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
        internal Dictionary<int, TmSkillDB> GetSkilldbsByRolerId(int rolerid)
        {
            MySqlCommand mySqlCommand = new MySqlCommand("select * from " + DatabaseFormName + " where rolerid = '" + rolerid + "'", TmMysqlConnection.Connection);  //读取数据函数  
            MySqlDataReader reader = mySqlCommand.ExecuteReader();
            try
            {
                Dictionary<int, TmSkillDB> dict = new Dictionary<int, TmSkillDB>();
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
                        dict.Add(item.Id, item);
                    }
                }
                return dict;
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
        internal Dictionary<int, TmSkill> GetSkills()
        {
            MySqlCommand mySqlCommand = new MySqlCommand("select * from " + "skill" , TmMysqlConnection.Connection);  //读取数据函数  
            MySqlDataReader reader = mySqlCommand.ExecuteReader();
            try
            {
                Dictionary<int, TmSkill> dict = new Dictionary<int, TmSkill>();
                while (reader.Read())
                {
                    if (reader.HasRows)
                    {
                        TmSkill  item = new TmSkill();
                        item.Id = reader.GetInt32(0);
                        item.Name = reader.GetString(1);
                        item.Icon = reader.GetString(2);
                        item.AvatarName = reader.GetString(3);
                        item.Chater = reader.GetString(4);
                        item.LevelUpLimit = reader.GetInt32(5);
                        item.Does = reader.GetString(6);
                        item.InfoType = (InfoType)reader.GetInt32(8);
                        item.RoleType = (RoleType)reader.GetInt32(7);
                        item.DamageDis = reader.GetInt32(9);
                        item.Duration = reader.GetInt32(10);
                        item.MaxColdTime = reader.GetInt32(11);
                        item.Stamina = reader.GetInt32(12);
                        item.Brains = reader.GetInt32(13);
                        item.Power = reader.GetInt32(14);
                        item.Agility = reader.GetInt32(15);
                        item.Sp = reader.GetDouble(16);
                        item.Hr = reader.GetDouble(17);
                        item.Cr = reader.GetDouble(18);
                        item.StaminaRate = reader.GetDouble(19);
                        item.BrainsRate = reader.GetDouble(20);
                        item.PowerRate = reader.GetDouble(21);
                        item.AgilityRate = reader.GetDouble(22);
                        //Console.WriteLine(TmTimerTool.CurrentTime() + " TmSouler-186-Power:" + (item.GetComponent<TmProperty>() as TmProperty).Power);
                        dict.Add(item.Id, item);

                        //(item.GetComponent<TmName>() as TmName).Id = reader.GetInt32(0);
                        //(item.GetComponent<TmName>() as TmName).Name = reader.GetString(1);
                        //(item.GetComponent<TmLabel>() as TmLabel).Icon = reader.GetString(2);
                        //(item.GetComponent<TmLabel>() as TmLabel).AvatarName = reader.GetString(3);
                        //(item.GetComponent<TmLabel>() as TmLabel).ChaterId = reader.GetInt32(4);
                        //(item.GetComponent<TmLabel>() as TmLabel).LevelUpLimit = reader.GetInt32(5);
                        //(item.GetComponent<TmLabel>() as TmLabel).Does = reader.GetString(6);
                        //(item.GetComponent<TmFixedType>() as TmFixedType).RoleType = (RoleType)reader.GetInt32(7);
                        //(item.GetComponent<TmFixedType>() as TmFixedType).InfoType = (InfoType)reader.GetInt32(8);
                        //(item.GetComponent<TmFixedType>() as TmFixedType).DamageDis = reader.GetInt32(9);
                        //(item.GetComponent<TmFixedType>() as TmFixedType).Duration = reader.GetInt32(10);
                        //(item.GetComponent<TmFixedType>() as TmFixedType).ColdTime = reader.GetInt32(11);
                        //(item.GetComponent<TmProperty>() as TmProperty).Stamina = reader.GetInt32(12);
                        //(item.GetComponent<TmProperty>() as TmProperty).Brains = reader.GetInt32(13);
                        //(item.GetComponent<TmProperty>() as TmProperty).Power = reader.GetInt32(14);
                        //(item.GetComponent<TmProperty>() as TmProperty).Agility = reader.GetInt32(15);
                        //(item.GetComponent<TmProperty>() as TmProperty).Hp = reader.GetInt32(16);
                        //(item.GetComponent<TmProperty>() as TmProperty).MaxHp = reader.GetInt32(17);
                        //(item.GetComponent<TmProperty>() as TmProperty).Bp = reader.GetInt32(18);
                        //(item.GetComponent<TmProperty>() as TmProperty).Ap = reader.GetInt32(19);
                        //(item.GetComponent<TmProperty>() as TmProperty).Sp = reader.GetDouble(20);
                        //(item.GetComponent<TmProperty>() as TmProperty).Hr = reader.GetDouble(21);
                        //(item.GetComponent<TmProperty>() as TmProperty).Cr = reader.GetDouble(22);
                    }
                }
                return dict;
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
