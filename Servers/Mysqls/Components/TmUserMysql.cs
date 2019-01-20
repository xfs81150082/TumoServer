﻿using Tumo;
using Tumo.Models;
using MySql.Data.MySqlClient;
using Servers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Servers
{
    class TmUserMysql : TmComponent
    {      
        private string SoulName = "Users";
        public TmUserMysql()
        {
            TmUserHandler.OnGetTmUserItemEvent += GetTmUser;
        }
        
        private void GetTmUser(object obj, TmParameter mvc)
        {
            TmUser user2 = GetUserByUserName(mvc.Username);
            if (user2 != null)
            {
                (obj as TmUserHandler).User = user2;
            }
        }

        //private void CheckLoginPassword(object obj,TmParameter mvc)
        //{
        //    TmUser user2 = GetUserByUserName(mvc.Username);
        //    if (user2 != null)
        //    {
        //        if (user2.Password == mvc.Password)
        //        {
        //            //mvc.TenCode = TenCode.Engineer;
        //            //mvc.ElevenCode = ElevenCode.UserLogin;
        //            //mvc.Parameters.Add(mvc.ElevenCode.ToString(), user2);
        //            //TumoLogin.Instance.OnTransferParameter(mvc);
        //        }
        //        else
        //        {
        //            Console.WriteLine("密码不正确");
        //        }
        //    }
        //    else
        //    {
        //        Console.WriteLine("帐号不存在");
        //    }
        //}

        #region  //取得user，插入，删除，更新
        private TmUser GetUserByUserName(string username)
        {
            MySqlCommand mySqlCommand = new MySqlCommand("select * from " + SoulName + " where username = '" + username + "'", TmMysql.Connection);//读取数据函数  
            MySqlDataReader reader = mySqlCommand.ExecuteReader();
            try
            {
                TmUser item = new TmUser();
                while (reader.Read())
                {
                    if (reader.HasRows)
                    {
                        //Console.WriteLine(reader.RecordsAffected + "*" + reader.FieldCount);
                        item.Id = reader.GetInt32(0);
                        item.Username = reader.GetString(1);
                        item.Password = reader.GetString(2);
                        item.Serverid = reader.GetInt32(3);
                        item.Phone = reader.GetString(4);
                        item.Qq = reader.GetString(5);
                        item.LoginCount = reader.GetInt32(6);
                        item.LoginDateTime = reader.GetString(7);
                        item.RigisterDateTime = reader.GetString(8);
                        //Console.WriteLine(TmTimer.GetCurrentTime() + " Username: " + item.Username + " + " + item.LoginCount);
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
        }     //得到user用户  //读取表格
        private void InsertItemdb(string name, int soulId, int userid, int exp, int level, int hp, int mp, int coin, int diamond, int senceId, double px, double py, double pz, double ax, double ay, double az, int serverid)
        {
            MySqlCommand mySqlCommand = new MySqlCommand("insert into " + SoulName + "(name,soulId,userid,exp,level,hp,mp,coin,diamond,senceId,px,py,pz,ax,ay,az,serverid) values('" + name + "','" + soulId + "','" + userid + "','" + exp + "','" + level + "','" + hp + "','" + mp + "','" + coin + "','" + diamond + "','" + senceId + "','" + px + "','" + py + "','" + pz + "','" + ax + "','" + ay + "','" + az + "','" + serverid + "')", TmMysql.Connection);  //插入列表行
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
        private void RemoveItemdb(int id)
        {
            MySqlCommand mySqlCommand = new MySqlCommand("delete from " + SoulName + " where id = '" + id + "'", TmMysql.Connection); //插入用户  
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
        private void UpdateItemdb(int id, int exp, int level, int hp, int mp, int coin, int diamond)
        {
            MySqlCommand mySqlCommand = new MySqlCommand("update " + SoulName + " set exp = '" + exp + "', level = '" + level + "', hp = '" + hp + "', mp = '" + mp + "', coin = '" + coin + "', diamond = '" + diamond + "' where id = '" + id + "'", TmMysql.Connection); //更新列表行
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
        #endregion


    }
}