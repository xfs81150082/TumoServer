﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tumo;
using Tumo.Models;
using MySql.Data.MySqlClient;
using Servers;

namespace Servers.Games.Mysqlers.Souls
{
    class EngineerMysqlTabler : GameMysqlBase
    {
        public override string Code => TenCode.Engineer.ToString();

        public override void OnTransferParameter(TmParameter mvc)
        {
            ElevenCode elevenCode = mvc.ElevenCode;
            switch (elevenCode)
            {             
                case (ElevenCode.None):
                    break;
                default:
                    break;
            }
        }

        //private string SoulName = "soul";
        private string SoulItemName = "engineeritem";

        public EngineerMysqlTabler()  {  }

        //void GetItemsByUser(MvcParameter mvc)
        //{
        //    User user1 = MvcTool.GetValue<User>(mvc, "User");
        //    List<SoulItem> items = GetSoulItemsByUserId(user1.Id);
        //    if (items.Count > 0)
        //    {
        //        Console.WriteLine("EngineerMysqlTabler-Engineers(当前User): " + items.Count );
        //        MvcParameter mvc2 = MvcTool.ToJsonParameter<List<SoulItem>>(NineCode.Login, TenCode.User, ElevenCode.GetItemsByUser, "GetItemsByUser", items);
        //        mvc2.Username = mvc.Username;
        //        TumoSender.Instance.OnTransferParameter(mvc2);
        //    }
        //    else
        //    {
        //        Console.WriteLine("帐号不存在");
        //    }
        //}

        void UpdateItemdb(TmSoulerDB itemDB)
        {
            UpdateItemdb(itemDB.Id, itemDB.Exp, itemDB.Level, itemDB.Hp, itemDB.Mp, itemDB.Coin, itemDB.Diamond);
            UpdateItemdb(itemDB.Id, itemDB.SenceId, itemDB.px, itemDB.py, itemDB.pz, itemDB.ax, itemDB.ay, itemDB.az);
        }

        //TmSoulerItem GetSoulItemById(int id)
        //{
        //    TmSoulerDB itemDB = GetSoulItemdbById(id);
        //    TmSoulerItem item = new TmSoulerItem(itemDB);
        //    TmSouler eng = GetSoulById(itemDB.SoulId);
        //    return item;
        //}               //得到userid所有角色列表
        //TmSoulerDB GetSoulItemdbById(int id)
        //{
        //    MySqlCommand mySqlCommand = new MySqlCommand("select * from " + SoulItemName + " where id = '" + id + "'", MysqlHelper.Connection);//读取数据函数  
        //    MySqlDataReader reader = mySqlCommand.ExecuteReader();
        //    try
        //    {
        //        TmSoulerDB item = new TmSoulerDB();
        //        while (reader.Read())
        //        {
        //            if (reader.HasRows)
        //            {
        //                item.Id = reader.GetInt32(0);
        //                item.Name = reader.GetString(1);
        //                item.SoulId = reader.GetInt32(2);
        //                item.UserId = reader.GetInt32(3);
        //                item.Exp = reader.GetInt32(4);
        //                item.Level = reader.GetInt32(5);
        //                item.Hp = reader.GetInt32(6);
        //                item.Mp = reader.GetInt32(7);
        //                item.Coin = reader.GetInt32(8);
        //                item.Diamond = reader.GetInt32(9);
        //                item.SenceId = reader.GetInt32(10);
        //                item.NodeId = reader.GetInt32(11);
        //                item.px = reader.GetDouble(12);
        //                item.py = reader.GetDouble(13);
        //                item.pz = reader.GetDouble(14);
        //                item.ax = reader.GetDouble(15);
        //                item.ay = reader.GetDouble(16);
        //                item.az = reader.GetDouble(17);
        //                item.ServerId = reader.GetInt32(18);
        //                item.CreateDateTime = reader.GetDateTime(19);
        //            }
        //        }
        //        return item;
        //    }
        //    catch (Exception)
        //    {
        //        Console.WriteLine("查询失败...");
        //        return null;
        //    }
        //    finally
        //    {
        //        reader.Close();
        //    }
        //}           //读取表格
        //List<TmSoulerItem> GetSoulItemsByUserId(int userid)
        //{
        //    List<TmSoulerItem> items = new List<TmSoulerItem>();
        //    List<TmSoulerDB> itemDBs = GetSoulItemdbsByUserId(userid);
        //    for (int i = 0; i < itemDBs.Count; i++)
        //    {
        //        TmSoulerItem item = new TmSoulerItem(itemDBs[i]);
        //        TmSouler eng = GetSoulById(itemDBs[i].SoulId);
        //        if (eng != null)
        //        {
        //            item.Soul = eng;
        //        }
        //        items.Add(item);
        //    }
        //    return items;
        //}               //得到userid所有角色列表
        //List<TmSoulerDB> GetSoulItemdbsByUserId(int userId)
        //{
        //    MySqlCommand mySqlCommand = new MySqlCommand("select * from " + SoulItemName + " where userid = '" + userId + "'", MysqlHelper.Connection);//读取数据函数  
        //    MySqlDataReader reader = mySqlCommand.ExecuteReader();
        //    try
        //    {
        //        List<TmSoulerDB> itemDBs = new List<TmSoulerDB>();
        //        while (reader.Read())
        //        {
        //            if (reader.HasRows)
        //            {
        //                TmSoulerDB item = new TmSoulerDB();
        //                item.Id = reader.GetInt32(0);
        //                item.Name = reader.GetString(1);
        //                item.SoulId = reader.GetInt32(2);
        //                item.UserId = reader.GetInt32(3);
        //                item.Exp = reader.GetInt32(4);
        //                item.Level = reader.GetInt32(5);
        //                item.Hp = reader.GetInt32(6);
        //                item.Mp = reader.GetInt32(7);
        //                item.Coin = reader.GetInt32(8);
        //                item.Diamond = reader.GetInt32(9);
        //                item.SenceId = reader.GetInt32(10);
        //                item.NodeId = reader.GetInt32(11);
        //                item.px = reader.GetDouble(12);
        //                item.py = reader.GetDouble(13);
        //                item.pz = reader.GetDouble(14);
        //                item.ax = reader.GetDouble(15);
        //                item.ay = reader.GetDouble(16);
        //                item.az = reader.GetDouble(17);
        //                item.ServerId = reader.GetInt32(18);
        //                item.CreateDateTime = reader.GetDateTime(19);
        //                //Console.WriteLine(userId + " " + reader.FieldCount + " " + item.Id);
        //                itemDBs.Add(item);
        //            }
        //        }
        //        return itemDBs;
        //    }
        //    catch (Exception)
        //    {
        //        Console.WriteLine("查询失败...");
        //        return null;
        //    }
        //    finally
        //    {
        //        reader.Close();
        //    }
        //}           //读取表格
        //TmSouler GetSoulById(int id)
        //{
        //    MySqlCommand mySqlCommand = new MySqlCommand("select * from " + SoulName + " where id = '" + id + "'", MysqlHelper.Connection);//读取数据函数  
        //    MySqlDataReader reader = mySqlCommand.ExecuteReader();
        //    try
        //    {
        //        TmSouler item = new TmSouler();
        //        while (reader.Read())
        //        {
        //            if (reader.HasRows)
        //            {
        //                item.Id = reader.GetInt32(0);
        //                item.Name = reader.GetString(1);
        //                item.Icon = reader.GetString(2);
        //                item.AvatarName = reader.GetString(3);
        //                item.ChaterId = reader.GetInt32(4);
        //                item.RoleType = (RoleType)reader.GetInt32(5);
        //                item.Grade = (Grade)reader.GetInt32(6);
        //                item.Profession = (Profession)reader.GetInt32(7);
        //                item.LevelUpLimit = reader.GetInt32(8);
        //                item.Does = reader.GetString(9);
        //                item.Stamina = reader.GetInt32(10);
        //                item.Brains = reader.GetInt32(11);
        //                item.Power = reader.GetInt32(12);
        //                item.Agility = reader.GetInt32(13);
        //                item.Hr = reader.GetDouble(14);
        //                item.Cr = reader.GetDouble(15);
        //                item.Sp = reader.GetDouble(16);
        //                item.StaminaRate = reader.GetDouble(17);
        //                item.BrainsRate = reader.GetDouble(18);
        //                item.PowerRate = reader.GetDouble(19);
        //                item.AgilityRate = reader.GetDouble(20);
        //            }
        //        }
        //        return item;
        //    }
        //    catch (Exception)
        //    {
        //        Console.WriteLine("查询失败...");
        //        return null;
        //    }
        //    finally
        //    {
        //        reader.Close();
        //    }
        //}                                      //读取表格

        //List<TmSoulerItem> GetSoulItems()
        //{
        //    List<TmSoulerItem> itemlist = new List<TmSoulerItem>();
        //    List<TmSoulerDB> dblist = GetSoulItemdbs();
        //    foreach (var tem in dblist)
        //    {
        //        TmSoulerItem item = new TmSoulerItem(tem);
        //        TmSouler eng = GetSoulById(tem.SoulId);
        //        if (eng != null)
        //        {
        //            item.Soul = eng;
        //        }
        //        itemlist.Add(item);
        //    }
        //    return itemlist;
        //}                    //得到SoulItemName列表中的所有角色列表
        //List<TmSoulerDB> GetSoulItemdbs()
        //{
        //    MySqlCommand mySqlCommand = new MySqlCommand("select * from " + SoulItemName, MysqlHelper.Connection);//读取数据函数  
        //    MySqlDataReader reader = mySqlCommand.ExecuteReader();
        //    try
        //    {
        //        List<TmSoulerDB> list = new List<TmSoulerDB>();
        //        while (reader.Read())
        //        {
        //            if (reader.HasRows)
        //            {
        //                Console.WriteLine(reader.RecordsAffected + "*" + reader.FieldCount);
        //                TmSoulerDB item = new TmSoulerDB();
        //                item.Id = reader.GetInt32(0);
        //                item.Name = reader.GetString(1);
        //                item.SoulId = reader.GetInt32(2);
        //                item.UserId = reader.GetInt32(3);
        //                item.Exp = reader.GetInt32(4);
        //                item.Level = reader.GetInt32(5);
        //                item.Hp = reader.GetInt32(6);
        //                item.Mp = reader.GetInt32(7);
        //                item.Coin = reader.GetInt32(8);
        //                item.Diamond = reader.GetInt32(9);
        //                item.SenceId = reader.GetInt32(10);
        //                item.px = reader.GetDouble(11);
        //                item.py = reader.GetDouble(12);
        //                item.pz = reader.GetDouble(13);
        //                item.ax = reader.GetDouble(14);
        //                item.ay = reader.GetDouble(15);
        //                item.az = reader.GetDouble(16);
        //                item.ServerId = reader.GetInt32(17);
        //                item.CreateDateTime = reader.GetDateTime(18);
        //                list.Add(item);
        //            }
        //        }
        //        Console.WriteLine("SoulItemdbs: " + list.Count);
        //        return list;
        //    }
        //    catch (Exception)
        //    {
        //        Console.WriteLine("查询失败...");
        //        return null;
        //    }
        //    finally
        //    {
        //        reader.Close();
        //    }
        //}                //读取表格
        //Dictionary<int, TmSouler> GetSouls()
        //{
        //    MySqlCommand mySqlCommand = new MySqlCommand("select * from " + SoulName, MysqlHelper.Connection);//读取数据函数  
        //    MySqlDataReader reader = mySqlCommand.ExecuteReader();
        //    try
        //    {
        //        Dictionary<int, TmSouler> dict = new Dictionary<int, TmSouler>();
        //        while (reader.Read())
        //        {
        //            if (reader.HasRows)
        //            {
        //                //Console.WriteLine(reader.RecordsAffected + "*" + reader.FieldCount);
        //                TmSouler item = new TmSouler();
        //                item.Id = reader.GetInt32(0);
        //                item.Name = reader.GetString(1);
        //                item.Icon = reader.GetString(2);
        //                item.AvatarName = reader.GetString(3);
        //                item.ChaterId = reader.GetInt32(4);
        //                item.RoleType = (RoleType)reader.GetInt32(5);
        //                item.Grade = (Grade)reader.GetInt32(6);
        //                item.Profession = (Profession)reader.GetInt32(7);
        //                item.LevelUpLimit = reader.GetInt32(8);
        //                item.Does = reader.GetString(9);
        //                item.Stamina = reader.GetInt32(10);
        //                item.Brains = reader.GetInt32(11);
        //                item.Power = reader.GetInt32(12);
        //                item.Agility = reader.GetInt32(13);
        //                item.Hr = reader.GetDouble(14);
        //                item.Cr = reader.GetDouble(15);
        //                item.Sp = reader.GetDouble(16);
        //                item.StaminaRate = reader.GetDouble(17);
        //                item.BrainsRate = reader.GetDouble(18);
        //                item.PowerRate = reader.GetDouble(19);
        //                item.AgilityRate = reader.GetDouble(20);
        //                dict.Add(item.Id, item);
        //            }
        //        }
        //        //Console.WriteLine("Souls:" + dict.Count);
        //        return dict;
        //    }
        //    catch (Exception)
        //    {
        //        Console.WriteLine("查询失败...");
        //        return null;
        //    }
        //    finally
        //    {
        //        reader.Close();
        //    }
        //}                 //读取表格

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
            Console.WriteLine("RolerId: " + id +" HpMp更新完成.");
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