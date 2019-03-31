using System;
using System.Collections.Generic;
using Tumo;
using MySql.Data.MySqlClient;
namespace Servers
{
    class TmInventoryMysql : TmComponent
    {    
        internal string DatabaseFormName { get; set; }
        internal TmInventoryDB GetInventorydbById(int id)
        {
            MySqlCommand mySqlCommand = new MySqlCommand("select * from " + DatabaseFormName + " where id = '" + id + "'", TmMysqlConnection.Connection);//读取数据函数  
            MySqlDataReader reader = mySqlCommand.ExecuteReader();
            try
            {
                TmInventoryDB item = new TmInventoryDB();
                while (reader.Read())
                {
                    if (reader.HasRows)
                    {
                        item.Id = reader.GetInt32(0);
                        item.Name = reader.GetString(1);
                        item.InventoryId = reader.GetInt32(2);
                        item.RolerId = reader.GetInt32(3);
                        item.Quality = (Quality)reader.GetInt32(4);
                        item.Place = reader.GetInt32(5);
                        item.Level = reader.GetInt32(6);
                        item.Count = reader.GetInt32(7);
                        item.Durability = reader.GetInt32(8);
                        item.Pice = reader.GetInt32(9);
                        item.BuildDate = reader.GetString(10);
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
        }                    //读取表格
        internal List<TmInventoryDB> GetInventorydbsByRolerId(int rolerid)
        {
            MySqlCommand mySqlCommand = new MySqlCommand("select * from " + DatabaseFormName + " where rolerid = '" + rolerid + "'", TmMysqlConnection.Connection);//读取数据函数  
            MySqlDataReader reader = mySqlCommand.ExecuteReader();
            try
            {
                List<TmInventoryDB> list = new List<TmInventoryDB>();
                while (reader.Read())
                {
                    if (reader.HasRows)
                    {
                        TmInventoryDB item = new TmInventoryDB();
                        item.Id = reader.GetInt32(0);
                        item.Name = reader.GetString(1);
                        item.InventoryId = reader.GetInt32(2);
                        item.RolerId = reader.GetInt32(3);
                        item.Quality = (Quality)reader.GetInt32(4);
                        item.Place = reader.GetInt32(5);
                        item.Level = reader.GetInt32(6);
                        item.Count = reader.GetInt32(7);
                        item.Durability = reader.GetInt32(8);
                        item.Pice = reader.GetInt32(9);
                        item.BuildDate = reader.GetString(10);
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
        }   //读取表格
        internal List<TmInventoryDB> GetInventorydbs()
        {
            MySqlCommand mySqlCommand = new MySqlCommand("select * from " + DatabaseFormName, TmMysqlConnection.Connection);//读取数据函数  
            MySqlDataReader reader = mySqlCommand.ExecuteReader();
            try
            {
                List<TmInventoryDB> list = new List<TmInventoryDB>();
                while (reader.Read())
                {
                    if (reader.HasRows)
                    {
                        TmInventoryDB item = new TmInventoryDB();
                        item.Id = reader.GetInt32(0);
                        item.Name = reader.GetString(1);
                        item.InventoryId = reader.GetInt32(2);
                        item.RolerId = reader.GetInt32(3);
                        item.Quality = (Quality)reader.GetInt32(4);
                        item.Place = reader.GetInt32(5);
                        item.Level = reader.GetInt32(6);
                        item.Count = reader.GetInt32(7);
                        item.Durability = reader.GetInt32(8);
                        item.Pice = reader.GetInt32(9);
                        item.BuildDate = reader.GetString(10);
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
        }                       //读取表格
        internal Dictionary<int,TmInventory> GetInventorys()
        {
            MySqlCommand mySqlCommand = new MySqlCommand("select * from " + "inventory", TmMysqlConnection.Connection);//读取数据函数  
            MySqlDataReader reader = mySqlCommand.ExecuteReader();
            try
            {
                Dictionary<int, TmInventory> dict = new Dictionary<int, TmInventory>();
                while (reader.Read())
                {
                    if (reader.HasRows)
                    {
                        TmInventory item = new TmInventory();
                        item.Id = reader.GetInt32(0);
                        item.Name = reader.GetString(1);
                        item.Icon = reader.GetString(2);
                        item.AvatarName = reader.GetString(3);
                        item.ChaterId = reader.GetInt32(4);
                        item.LevelUpLimit = reader.GetInt32(5);
                        item.Does = reader.GetString(6);
                        item.InfoType = (InfoType)reader.GetInt32(8);
                        item.Quality = (Quality)reader.GetInt32(9);
                        item.EquipType = (EquipType)reader.GetInt32(7);
                        item.Duration = reader.GetInt32(10);
                        item.ColdTime = reader.GetInt32(11);
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
                        //(item.GetComponent<TmFixedType>() as TmFixedType).Quality = (Quality)reader.GetInt32(9);
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
        }                       //读取表格
        internal void InsertItemdb(string name, int soulId, int userid)
        {
            MySqlCommand mySqlCommand = new MySqlCommand("insert into " + DatabaseFormName + "(name,soulId,userid) values('" + name + "','" + soulId + "','" + userid + "')", TmMysqlConnection.Connection); //插入列表行
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
        internal void InsertItemdb(string name, int soulId, int userid, int exp, int level, int hp, int mp, int coin, int diamond, int senceId, double px, double py, double pz, double ax, double ay, double az, int serverid)
        {
            MySqlCommand mySqlCommand = new MySqlCommand("insert into " + DatabaseFormName + "(name,soulId,userid,exp,level,hp,mp,coin,diamond,senceId,px,py,pz,ax,ay,az,serverid) values('" + name + "','" + soulId + "','" + userid + "','" + exp + "','" + level + "','" + hp + "','" + mp + "','" + coin + "','" + diamond + "','" + senceId + "','" + px + "','" + py + "','" + pz + "','" + ax + "','" + ay + "','" + az + "','" + serverid + "')", TmMysqlConnection.Connection);  //插入列表行
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
        internal void UpdateItemdb(int id, string name)
        {
            MySqlCommand mySqlCommand = new MySqlCommand("update " + DatabaseFormName + " set name = '" + name + "' where id = '" + id + "'", TmMysqlConnection.Connection); //更新列表行
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
        internal void UpdateItemdb(int id, int exp, int level, int hp, int mp, int coin, int diamond)
        {
            MySqlCommand mySqlCommand = new MySqlCommand("update " + DatabaseFormName + " set exp = '" + exp + "', level = '" + level + "', hp = '" + hp + "', mp = '" + mp + "', coin = '" + coin + "', diamond = '" + diamond + "' where id = '" + id + "'", TmMysqlConnection.Connection); //更新列表行
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
        internal void UpdateItemdb(int id, int senceId, double px, double py, double pz, double ax, double ay, double az)
        {
            MySqlCommand mySqlCommand = new MySqlCommand("update " + DatabaseFormName + " set senceId = '" + senceId + "', px = '" + px + "', py = '" + py + "', pz = '" + pz + "', ax = '" + ax + "', ay = '" + ay + "', az = '" + az + "' where id = '" + id + "'", TmMysqlConnection.Connection); //更新列表行
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
 