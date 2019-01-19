﻿using Tumo;
using Tumo.Models;
using MySql.Data.MySqlClient;
using Servers;
using Servers.Sences.Nodes;
using Servers.Sences.Nodes.Mysqlers;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Servers.Games.Mysqlers.Skills
{
    class InbornMysqlTabler : GameMysqlBase
    {
        public override string Code => TenCode.Inborn.ToString();
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

        string TableName { get => tableName; set => tableName = value; }
        string ItemTableName { get => itemTableName; set => itemTableName = value; }
        private string tableName = "skill";
        private string itemTableName = "inbornitem";
        public InbornMysqlTabler()
        {
            
        }

        void UpdateSkillItemsByRolerId(int rolerid)
        {
            //Dictionary<int, SkillItem> items = GetSkillItemsByRolerId(rolerid);
            //Dictionary<int, SkillItem> tems;
            //NodeInfo.Instance.InbornItems.TryGetValue(rolerid, out tems);
            //if (tems != null)
            //{
            //    tems = items;
            //}
            //else
            //{
            //    NodeInfo.Instance.InbornItems.Add(rolerid, items);
            //}
            //Console.WriteLine("InbornMysqlTabler-SkillItems: " + items.Count + " One: " + NodeInfo.Instance.InbornItems.Count);

        }

        //Dictionary<int,TmSkillItem> GetSkillItemsByRolerId(int rolerid )
        //{
        //    Dictionary<int, TmSkillItem> items = new Dictionary<int, TmSkillItem>();
        //    List<TmSkillDB> itemDBs = GetItemdbsByRolerId(rolerid);
        //    for (int i = 0; i < itemDBs.Count; i++)
        //    {
        //        TmSkillItem item = new TmSkillItem(itemDBs[i]);
        //        TmSkill skill = GetSkillById(itemDBs[i].SkillId);
        //        item.Skill = skill;
        //        items.Add(item.Id, item);
        //    }
        //    return items;
        //}        //得到userid所有角色列表
        //List<TmSkillDB> GetItemdbsByRolerId(int rolerid)
        //{
        //    MySqlCommand mySqlCommand = new MySqlCommand("select * from " + ItemTableName + " where rolerid = '" + rolerid + "'", MysqlHelper.Connection);  //读取数据函数  
        //    MySqlDataReader reader = mySqlCommand.ExecuteReader();
        //    try
        //    {
        //        List<TmSkillDB> list = new List<TmSkillDB>();
        //        while (reader.Read())
        //        {
        //            if (reader.HasRows)
        //            {
        //                TmSkillDB item = new TmSkillDB();
        //                item.Id = reader.GetInt32(0);
        //                item.Name = reader.GetString(1);
        //                item.SkillId = reader.GetInt32(2);
        //                item.RolerId = reader.GetInt32(3);
        //                item.Level = reader.GetInt32(4);
        //                item.RoleType = (RoleType)reader.GetInt32(5);
        //                item.SkillPlace = (SkillPlace)reader.GetInt32(6);
        //                list.Add(item);
        //            }
        //        }
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
        //}                                         //读取表格
        //TmSkill GetSkillById(int id)
        //{
        //    MySqlCommand mySqlCommand = new MySqlCommand("select * from " + TableName + " where id = '" + id + "'", MysqlHelper.Connection);//读取数据函数  
        //    MySqlDataReader reader = mySqlCommand.ExecuteReader();
        //    try
        //    {
        //        TmSkill item = new TmSkill();
        //        while (reader.Read())
        //        {
        //            if (reader.HasRows)
        //            {
        //                item.Id = reader.GetInt32(0);
        //                item.Name = reader.GetString(1);
        //                item.Icon = reader.GetString(2);
        //                item.AvatarName = reader.GetString(3);
        //                item.ChaterId = reader.GetInt32(4);
        //                item.SkillType = (SkillType)reader.GetInt32(5);
        //                item.ColdTime = reader.GetInt32(6);
        //                item.DamageDis = reader.GetInt32(7);
        //                item.Start = Convert.ToBoolean(reader.GetInt32(8));
        //                item.Duration = reader.GetDouble(9);
        //                item.LevelUpLimit = reader.GetInt32(10);
        //                item.Does = reader.GetString(11);
        //                item.Stamina = reader.GetInt32(12);
        //                item.Brains = reader.GetInt32(13);
        //                item.Power = reader.GetInt32(14);
        //                item.Agility = reader.GetInt32(15);
        //                item.Hp = reader.GetInt32(16);
        //                item.Mp = reader.GetInt32(17);
        //                item.MaxHp = reader.GetInt32(18);
        //                item.MaxMp = reader.GetInt32(19);
        //                item.Bp = reader.GetInt32(20);
        //                item.Ap = reader.GetInt32(21);
        //                item.Hr = reader.GetDouble(22);
        //                item.Cr = reader.GetDouble(23);
        //                item.Sp = reader.GetDouble(24);
        //                item.HpRate = reader.GetDouble(25);
        //                item.MpRate = reader.GetDouble(26);
        //                item.MaxHpRate = reader.GetDouble(27);
        //                item.MaxMpRate = reader.GetDouble(28);
        //                item.BpRate = reader.GetDouble(29);
        //                item.ApRate = reader.GetDouble(30);
        //                item.HrRate = reader.GetDouble(31);
        //                item.CrRate = reader.GetDouble(32);
        //                item.SpRate = reader.GetDouble(33);
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
        //}                                            //读取表格

        //List<TmSkillDB> ReaderItemdbs()
        //{
        //    MySqlCommand mySqlCommand = new MySqlCommand("select * from " + ItemTableName, MysqlHelper.Connection);//读取数据函数  
        //    MySqlDataReader reader = mySqlCommand.ExecuteReader();
        //    try
        //    {
        //        List<TmSkillDB> list = new List<TmSkillDB>();
        //        while (reader.Read())
        //        {
        //            if (reader.HasRows)
        //            {
        //                //Console.WriteLine(reader.HasRows + "*" + reader.FieldCount);
        //                TmSkillDB item = new TmSkillDB();
        //                item.Id = reader.GetInt32(0);
        //                item.Name = reader.GetString(1);
        //                item.SkillId = reader.GetInt32(2);
        //                item.RolerId = reader.GetInt32(3);
        //                item.Level = reader.GetInt32(4);
        //                item.RoleType = (RoleType)reader.GetInt32(5);
        //                item.SkillPlace = (SkillPlace)reader.GetInt32(6);
        //                //item.BuildTime = reader.GetString(10); 查询失败的原因？
        //                list.Add(item);
        //            }
        //        }
        //        //Console.WriteLine("skillItemdbs: " + list.Count);
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
        //}                                     //读取表格
        //Dictionary<int, TmSkill> ReaderSkills()
        //{
        //    MySqlCommand mySqlCommand = new MySqlCommand("select * from " + TableName, MysqlHelper.Connection);//读取数据函数  
        //    MySqlDataReader reader = mySqlCommand.ExecuteReader();
        //    try
        //    {
        //        Dictionary<int, TmSkill> dict = new Dictionary<int, TmSkill>();
        //        while (reader.Read())
        //        {
        //            if (reader.HasRows)
        //            {
        //                //Console.WriteLine(reader.HasRows + "*" + reader.FieldCount);
        //                TmSkill item = new TmSkill();
        //                item.Id = reader.GetInt32(0);
        //                item.Name = reader.GetString(1);
        //                item.Icon = reader.GetString(2);
        //                item.AvatarName = reader.GetString(3);
        //                item.ChaterId = reader.GetInt32(4);
        //                item.SkillType = (SkillType)reader.GetInt32(5);
        //                item.ColdTime = reader.GetInt32(6);
        //                item.DamageDis = reader.GetInt32(7);
        //                item.Start = Convert.ToBoolean(reader.GetInt32(8));
        //                item.Duration = reader.GetDouble(9);
        //                item.LevelUpLimit = reader.GetInt32(10);
        //                item.Does = reader.GetString(11);
        //                item.Stamina = reader.GetInt32(12);
        //                item.Brains = reader.GetInt32(13);
        //                item.Power = reader.GetInt32(14);
        //                item.Agility = reader.GetInt32(15);
        //                item.Hp = reader.GetInt32(16);
        //                item.Mp = reader.GetInt32(17);
        //                item.MaxHp = reader.GetInt32(18);
        //                item.MaxMp = reader.GetInt32(19);
        //                item.Bp = reader.GetInt32(20);
        //                item.Ap = reader.GetInt32(21);
        //                item.Hr = reader.GetDouble(22);
        //                item.Cr = reader.GetDouble(23);
        //                item.Sp = reader.GetDouble(24);
        //                item.HpRate = reader.GetDouble(25);
        //                item.MpRate = reader.GetDouble(26);
        //                item.MaxHpRate = reader.GetDouble(27);
        //                item.MaxMpRate = reader.GetDouble(28);
        //                item.BpRate = reader.GetDouble(29);
        //                item.ApRate = reader.GetDouble(30);
        //                item.HrRate = reader.GetDouble(31);
        //                item.CrRate = reader.GetDouble(32);
        //                item.SpRate = reader.GetDouble(33);
        //                dict.Add(item.Id, item);
        //            }
        //        }
        //        //Console.WriteLine("skills:" + dict.Count);
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
        //}                                 //读取表格

        void InsertItemdb(string name, int inventoryid, int rolerid)
        {
            MySqlCommand mySqlCommand = new MySqlCommand("insert into " + ItemTableName + "(name,inventoryid,rolerid) values('" + name + "','" + inventoryid + "','" + rolerid + "')", MysqlHelper.Connection); //插入列表行
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
        void InsertItemdb(string name, int inventoryid, int rolerid, int equipquality, int place, int level, int count, int durability, int pice)
        {
            MySqlCommand mySqlCommand = new MySqlCommand("insert into " + ItemTableName + "(name,inventoryid,rolerid,equipquality,place,level,count,durability,pice) values('" + name + "','" + inventoryid + "','" + rolerid + "','" + equipquality + "','" + place + "','" + level + "','" + count + "','" + durability + "','" + pice + "')", MysqlHelper.Connection); //插入列表行
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
        void UpdateItemdb(int id, string name, int equipquality, int level)
        {
            MySqlCommand mySqlCommand = new MySqlCommand("update " + ItemTableName + " set name = '" + name + "', equipquality = '" + equipquality + "', level = '" + level + "' where id = '" + id + "'", MysqlHelper.Connection); //更新列表行
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
        void UpdateItemdb(int id, int rolerid, int place)
        {
            MySqlCommand mySqlCommand = new MySqlCommand("update " + ItemTableName + " set rolerid = '" + rolerid + "', place = '" + place + "' where id = '" + id + "'", MysqlHelper.Connection); //更新列表行
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
        void UpdateItemdb(int id, int count, int durability, int pice)
        {
            MySqlCommand mySqlCommand = new MySqlCommand("update " + ItemTableName + " set count = '" + count + "', durability = '" + durability + "', pice = '" + pice + "' where id = '" + id + "'", MysqlHelper.Connection); //更新列表行
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
            MySqlCommand mySqlCommand = new MySqlCommand("delete from " + ItemTableName + " where id = '" + id + "'", MysqlHelper.Connection); //插入用户  
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