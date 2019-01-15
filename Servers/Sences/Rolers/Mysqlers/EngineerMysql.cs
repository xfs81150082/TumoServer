using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;
using System.Timers;
using Tumo;
using Tumo.Models;
using MySql.Data.MySqlClient;
using Servers;
using Servers.Sences.Models;

namespace Servers.Sences.Rolers.Mysqlers
{
    class EngineerMysql : RolerMysqlBase
    {
        public override string Code => TenCode.Engineer.ToString();
        public override void OnTransferParameter(MvcParameter mvc)
        {
            ElevenCode elevenCode = mvc.ElevenCode;
            switch (elevenCode)
            {
                case (ElevenCode.None):
                    Console.WriteLine(TmTimerTool.GetCurrentTime() + " EngineerMysqlRoler: " + elevenCode);
                    break;
                default:
                    break;
            }
        }

        private string SoulName = "soul";
        private string SoulItemName = "engineeritem";
        public EngineerMysql() { }

        void UpdateItemdb(SoulItemDB itemDB)
        {
            UpdateItemdb(itemDB.Id, itemDB.Exp, itemDB.Level, itemDB.Hp, itemDB.Mp, itemDB.Coin, itemDB.Diamond);
            UpdateItemdb(itemDB.Id, itemDB.SenceId, itemDB.px, itemDB.py, itemDB.pz, itemDB.ax, itemDB.ay, itemDB.az);
        }

        SoulItem GetSoulItemById(int id)
        {
            SoulItemDB itemDB = GetSoulItemdbById(id);
            SoulItem item = new SoulItem(itemDB);
            Soul eng = GetSoulById(itemDB.SoulId);
            item.Soul = eng;
            return item;
        }                              //得到userid所有角色列表
        SoulItemDB GetSoulItemdbById(int id)
        {
            MySqlCommand mySqlCommand = new MySqlCommand("select * from " + SoulItemName + " where id = '" + id + "'", MysqlHelper.Connection);//读取数据函数  
            MySqlDataReader reader = mySqlCommand.ExecuteReader();
            try
            {
                SoulItemDB item = new SoulItemDB();
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
                        item.CreateDateTime = reader.GetDateTime(19);
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
        }                          //读取表格
        Soul GetSoulById(int id)
        {
            MySqlCommand mySqlCommand = new MySqlCommand("select * from " + SoulName + " where id = '" + id + "'", MysqlHelper.Connection);//读取数据函数  
            MySqlDataReader reader = mySqlCommand.ExecuteReader();
            try
            {
                Soul item = new Soul();
                while (reader.Read())
                {
                    if (reader.HasRows)
                    {
                        item.Id = reader.GetInt32(0);
                        item.Name = reader.GetString(1);
                        item.Icon = reader.GetString(2);
                        item.AvatarName = reader.GetString(3);
                        item.ChaterId = reader.GetInt32(4);
                        item.RoleType = (RoleType)reader.GetInt32(5);
                        item.Grade = (Grade)reader.GetInt32(6);
                        item.Profession = (Profession)reader.GetInt32(7);
                        item.LevelUpLimit = reader.GetInt32(8);
                        item.Does = reader.GetString(9);
                        item.Stamina = reader.GetInt32(10);
                        item.Brains = reader.GetInt32(11);
                        item.Power = reader.GetInt32(12);
                        item.Agility = reader.GetInt32(13);
                        item.Hr = reader.GetDouble(14);
                        item.Cr = reader.GetDouble(15);
                        item.Sp = reader.GetDouble(16);
                        item.StaminaRate = reader.GetDouble(17);
                        item.BrainsRate = reader.GetDouble(18);
                        item.PowerRate = reader.GetDouble(19);
                        item.AgilityRate = reader.GetDouble(20);
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
        }                                      //读取表格

        void InsertItemdb(string name, int soulId, int userid)
        {
            MySqlCommand mySqlCommand = new MySqlCommand("insert into " + SoulItemName + "(name,soulId,userid) values('" + name + "','" + soulId + "','" + userid + "')", MysqlHelper.Connection); //插入列表行
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
        void InsertItemdb(string name, int soulId, int userid, int exp, int level, int hp, int mp, int coin, int diamond, int senceId, double px, double py, double pz, double ax, double ay, double az, int serverid)
        {
            MySqlCommand mySqlCommand = new MySqlCommand("insert into " + SoulItemName + "(name,soulId,userid,exp,level,hp,mp,coin,diamond,senceId,px,py,pz,ax,ay,az,serverid) values('" + name + "','" + soulId + "','" + userid + "','" + exp + "','" + level + "','" + hp + "','" + mp + "','" + coin + "','" + diamond + "','" + senceId + "','" + px + "','" + py + "','" + pz + "','" + ax + "','" + ay + "','" + az + "','" + serverid + "')", MysqlHelper.Connection);  //插入列表行
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
            MySqlCommand mySqlCommand = new MySqlCommand("update " + SoulItemName + " set exp = '" + exp + "', level = '" + level + "', hp = '" + hp + "', mp = '" + mp + "', coin = '" + coin + "', diamond = '" + diamond + "' where id = '" + id + "'", MysqlHelper.Connection); //更新列表行
            try
            {
                mySqlCommand.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                string message = ex.Message;
                Console.WriteLine("修改数据失败..." + message);
            }
            Console.WriteLine("RolerId: " + id + " HpMp更新完成.");
        }
        void UpdateItemdb(int id, int senceId, double px, double py, double pz, double ax, double ay, double az)
        {
            MySqlCommand mySqlCommand = new MySqlCommand("update " + SoulItemName + " set senceId = '" + senceId + "', px = '" + px + "', py = '" + py + "', pz = '" + pz + "', ax = '" + ax + "', ay = '" + ay + "', az = '" + az + "' where id = '" + id + "'", MysqlHelper.Connection); //更新列表行
            try
            {
                mySqlCommand.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                string message = ex.Message;
                Console.WriteLine("修改数据失败..." + message);
            }
            Console.WriteLine("RolerId: " + id + " PxPyPz更新完成.");
        }
        void RemoveItemdb(int id)
        {
            MySqlCommand mySqlCommand = new MySqlCommand("delete from " + SoulItemName + " where id = '" + id + "'", MysqlHelper.Connection); //插入用户  
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
