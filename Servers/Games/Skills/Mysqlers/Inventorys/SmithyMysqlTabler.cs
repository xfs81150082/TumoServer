using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tumo;
using Tumo.Models;
using MySql.Data.MySqlClient;
using Servers;
using Servers.Sences.Nodes;
using Servers.Sences.Nodes.Mysqlers;

namespace Servers.Games.Mysqlers.Inventorys
{
    class SmithyMysqlTabler : GameMysqlBase
    {
        public override string Code => TenCode.Smithy.ToString();

        public override void OnTransferParameter(TmParameter mvc)
        {
            ElevenCode ElevenCode = mvc.ElevenCode;
            switch (ElevenCode)
            {
                case (ElevenCode.GetItemsByRolerId):
                    int rolerid = TmTransferTool.GetValue<int>(mvc, "RolerId");
                    UpdateSmithyByRolerId(rolerid);
                    break;           
                case (ElevenCode.None):
                    break;
                case (ElevenCode.Test):
                    break;
                default:
                    break;
            }
        }

        //private string TableName = "inventory";
        private string ItemTableName = "smithyitem";

        public SmithyMysqlTabler()
        {
            //UpdateSmithyByRolerId(161033); //Test
        }

        void UpdateSmithyByRolerId(int rolerid)
        {
            //List<InventoryItem> items = GetInventoryItemsByRolerId(rolerid);
            //List<InventoryItem> tems;
            //NodeInfo.Instance.SmithyItems.TryGetValue(rolerid, out tems);
            //if (tems != null)
            //{
            //    tems = items;
            //}
            //else
            //{
            //    NodeInfo.Instance.SmithyItems.Add(rolerid, items);
            //}
            //Console.WriteLine("SmithyMysqlTabler-InventoryItems: " + items.Count + " One: " + NodeInfo.Instance.SmithyItems.Count);
        }

        //List<InventoryItem> GetInventoryItemsByRolerId(int rolerid)
        //{
        //    List<InventoryItem> items = new List<InventoryItem>();
        //    List<InventoryItemDB> itemdbs = GetInventorydbsByRolerId(rolerid);
        //    for (int i = 0; i < itemdbs.Count; i++)
        //    {
        //        InventoryItem item = new InventoryItem(itemdbs[i]);
        //        Inventory inv = GetInventoryById(itemdbs[i].InventoryId);
        //        item.Inventory = inv;
        //        items.Add(item);
        //    }
        //    //Console.WriteLine("itemsbyrolerid:" + items.Count);
        //    return items;
        //}   //得到SoulItemName列表中的所有角色列表
        //List<InventoryItem> GetInventoryItems()
        //{
        //    List<InventoryItem> items = new List<InventoryItem>();
        //    List<InventoryItemDB> itemdbs = GetInventorydbs();
        //    for(int i = 0; i < itemdbs.Count; i++)
        //    {
        //        InventoryItem item = new InventoryItem(itemdbs[i]);
        //        Inventory inv = GetInventoryById(itemdbs[i].InventoryId);
        //        item.Inventory = inv;
        //        items.Add(item);
        //    }
        //    //Console.WriteLine("items:" + items.Count);
        //    return items;
        //}                       //得到SoulItemName列表中的所有角色列表
        //InventoryItem GetInventoryItemById(int id)
        //{
        //    InventoryItemDB itemdb = GetInventorydbsById(id);
        //    InventoryItem item = new InventoryItem(itemdb);
        //    Inventory inv = GetInventoryById(itemdb.InventoryId);
        //    item.Inventory = inv;
        //    //Console.WriteLine("itembyid:" + item.Id);
        //    return item;
        //}                    //得到SoulItemName列表中的所有角色列表
        //InventoryItemDB GetInventorydbsById(int id)
        //{
        //    MySqlCommand mySqlCommand = new MySqlCommand("select * from " + ItemTableName + " where id = '" + id + "'", MysqlHelper.Connection);//读取数据函数  
        //    MySqlDataReader reader = mySqlCommand.ExecuteReader();
        //    try
        //    {
        //        InventoryItemDB item = new InventoryItemDB();
        //        while (reader.Read())
        //        {
        //            if (reader.HasRows)
        //            {
        //                //Console.WriteLine(reader.RecordsAffected + "*" + reader.FieldCount);
        //                item.Id = reader.GetInt32(0);
        //                item.Name = reader.GetString(1);
        //                item.InventoryId = reader.GetInt32(2);
        //                item.RolerId = reader.GetInt32(3);
        //                item.EquipQuality = (EquipQuality)reader.GetInt32(4);
        //                item.Place = (Place)reader.GetInt32(5);
        //                item.Level = reader.GetInt32(6);
        //                item.Count = reader.GetInt32(7);
        //                item.Durability = reader.GetInt32(8);
        //                item.Pice = reader.GetInt32(9);
        //                item.BuildTime = reader.GetString(10);
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
        //}                   //读取表格
        //Inventory GetInventoryById(int id)
        //{
        //    MySqlCommand mySqlCommand = new MySqlCommand("select * from " + TableName + " where id = '" + id + "'", MysqlHelper.Connection);//读取数据函数  
        //    MySqlDataReader reader = mySqlCommand.ExecuteReader();
        //    try
        //    {
        //        Inventory item = new Inventory();
        //        while (reader.Read())
        //        {
        //            if (reader.HasRows)
        //            {
        //                //Console.WriteLine(reader.RecordsAffected + "*" + reader.FieldCount);
        //                item.Id = reader.GetInt32(0);
        //                item.Name = reader.GetString(1);
        //                item.Icon = reader.GetString(2);
        //                item.AvatarName = reader.GetString(3);
        //                item.ChaterId = reader.GetInt32(4);
        //                item.InventoryType = (InventoryType)reader.GetInt32(5);
        //                item.EquipType = (EquipType)reader.GetInt32(6);
        //                item.InfoType = (InfoType)reader.GetInt32(7);
        //                item.LevelUpLimit = reader.GetInt32(8);
        //                item.Does = reader.GetString(9);
        //                item.Stamina = reader.GetInt32(10);
        //                item.Brains = reader.GetInt32(11);
        //                item.Power = reader.GetInt32(12);
        //                item.Agility = reader.GetInt32(13);
        //                item.Hp = reader.GetInt32(14);
        //                item.Mp = reader.GetInt32(15);
        //                item.MaxHp = reader.GetInt32(16);
        //                item.MaxMp = reader.GetInt32(17);
        //                item.Bp = reader.GetInt32(18);
        //                item.Ap = reader.GetInt32(19);
        //                item.Hr = reader.GetDouble(20);
        //                item.Cr = reader.GetDouble(21);
        //                item.Sp = reader.GetDouble(22);
        //                item.HpRate = reader.GetDouble(23);
        //                item.MpRate = reader.GetDouble(24);
        //                item.MaxHpRate = reader.GetDouble(25);
        //                item.MaxMpRate = reader.GetDouble(26);
        //                item.BpRate = reader.GetDouble(27);
        //                item.ApRate = reader.GetDouble(28);
        //                item.HrRate = reader.GetDouble(29);
        //                item.CrRate = reader.GetDouble(30);
        //                item.SpRate = reader.GetDouble(31);
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
        //}                            //读取表格
        //List<InventoryItemDB> GetInventorydbsByRolerId(int rolerid)
        //{
        //    MySqlCommand mySqlCommand = new MySqlCommand("select * from " + ItemTableName + " where rolerid = '" + rolerid + "'", MysqlHelper.Connection);//读取数据函数  
        //    MySqlDataReader reader = mySqlCommand.ExecuteReader();
        //    try
        //    {
        //        List<InventoryItemDB> list = new List<InventoryItemDB>();
        //        while (reader.Read())
        //        {
        //            if (reader.HasRows)
        //            {
        //                InventoryItemDB item = new InventoryItemDB();
        //                item.Id = reader.GetInt32(0);
        //                item.Name = reader.GetString(1);
        //                item.InventoryId = reader.GetInt32(2);
        //                item.RolerId = reader.GetInt32(3);
        //                item.EquipQuality = (EquipQuality)reader.GetInt32(4);
        //                item.Place = (Place)reader.GetInt32(5);
        //                item.Level = reader.GetInt32(6);
        //                item.Count = reader.GetInt32(7);
        //                item.Durability = reader.GetInt32(8);
        //                item.Pice = reader.GetInt32(9);
        //                item.BuildTime = reader.GetString(10);
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
        //}   //读取表格
        //List<InventoryItemDB> GetInventorydbs()
        //{
        //    MySqlCommand mySqlCommand = new MySqlCommand("select * from " + ItemTableName, MysqlHelper.Connection);//读取数据函数  
        //    MySqlDataReader reader = mySqlCommand.ExecuteReader();
        //    try
        //    {
        //        List<InventoryItemDB> list = new List<InventoryItemDB>();
        //        while (reader.Read())
        //        {
        //            if (reader.HasRows)
        //            {
        //                InventoryItemDB item = new InventoryItemDB();
        //                item.Id = reader.GetInt32(0);
        //                item.Name = reader.GetString(1);
        //                item.InventoryId = reader.GetInt32(2);
        //                item.RolerId = reader.GetInt32(3);
        //                item.EquipQuality = (EquipQuality)reader.GetInt32(4);
        //                item.Place = (Place)reader.GetInt32(5);
        //                item.Level = reader.GetInt32(6);
        //                item.Count = reader.GetInt32(7);
        //                item.Durability = reader.GetInt32(8);
        //                item.Pice = reader.GetInt32(9);
        //                item.BuildTime = reader.GetString(10);
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
        //}                       //读取表格
        void InsertItemdb(string name, int soulId, int userid)
        {
            MySqlCommand mySqlCommand = new MySqlCommand("insert into " + ItemTableName + "(name,soulId,userid) values('" + name + "','" + soulId + "','" + userid + "')", MysqlHelper.Connection); //插入列表行
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
            MySqlCommand mySqlCommand = new MySqlCommand("insert into " + ItemTableName + "(name,soulId,userid,exp,level,hp,mp,coin,diamond,senceId,px,py,pz,ax,ay,az,serverid) values('" + name + "','" + soulId + "','" + userid + "','" + exp + "','" + level + "','" + hp + "','" + mp + "','" + coin + "','" + diamond + "','" + senceId + "','" + px + "','" + py + "','" + pz + "','" + ax + "','" + ay + "','" + az + "','" + serverid + "')", MysqlHelper.Connection);  //插入列表行
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
        void UpdateItemdb(int id, string name)
        {
            MySqlCommand mySqlCommand = new MySqlCommand("update " + ItemTableName + " set name = '" + name + "' where id = '" + id + "'", MysqlHelper.Connection); //更新列表行
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
        void UpdateItemdb(int id, int exp, int level, int hp, int mp, int coin, int diamond)
        {
            MySqlCommand mySqlCommand = new MySqlCommand("update " + ItemTableName + " set exp = '" + exp + "', level = '" + level + "', hp = '" + hp + "', mp = '" + mp + "', coin = '" + coin + "', diamond = '" + diamond + "' where id = '" + id + "'", MysqlHelper.Connection); //更新列表行
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
        void UpdateItemdb(int id, int senceId, double px, double py, double pz, double ax, double ay, double az)
        {
            MySqlCommand mySqlCommand = new MySqlCommand("update " + ItemTableName + " set senceId = '" + senceId + "', px = '" + px + "', py = '" + py + "', pz = '" + pz + "', ax = '" + ax + "', ay = '" + ay + "', az = '" + az + "' where id = '" + id + "'", MysqlHelper.Connection); //更新列表行
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
