using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tumo;
using Tumo.Models;
using Tumo;
using MySql.Data.MySqlClient;
using Servers;
using Servers.Sences.Nodes;
using Servers.Sences.Nodes.Mysqlers;

namespace Servers.Games.Mysqlers.Assignments
{
    class AssignmentMysqlTabler : GameMysqlBase
    {
        public override string Code => TenCode.Task.ToString();

        public override void OnTransferParameter(MvcParameter mvc)
        {
            ElevenCode elevenCode = mvc.ElevenCode;
            switch (elevenCode)
            {          
                case (ElevenCode.None):
                    break;
                case (ElevenCode.Test):
                    break;
                default:
                    break;
            }
        }

        public string ItemTableName { get; private set; } = "assignmentitem";
        public string TableName { get; private set; } = "assignment";

        public AssignmentMysqlTabler()
        {
            
        }
        void UpdateItemsByRolerId(int rolerid)
        {
            //Dictionary<int, AssignmentItem> items = GetItemsByRolerId(rolerid);
            //Dictionary<int, AssignmentItem> tems;
            //NodeInfo.Instance.EngineerAssignmentItems.TryGetValue(rolerid, out tems);
            //if (tems != null)
            //{
            //    tems = items;
            //}
            //else
            //{
            //    NodeInfo.Instance.EngineerAssignmentItems.Add(rolerid, items);
            //}
            //Console.WriteLine("AssignmentMysqlTabler-TaskItems: " + items.Count + " One: " + NodeInfo.Instance.EngineerAssignmentItems.Count);
        }

        List<AssignmentItem> GetItemsByTeacherId(int teacherid)
        {
            List<AssignmentItem> items = new List<AssignmentItem>();
            List<Assignment> assignments = GetsByTeacherId(teacherid);
            for(int i = 0; i < assignments.Count; i++)
            {
                AssignmentItem item = new AssignmentItem(assignments[i]);
                items.Add(item);
            }
            return items;
        }
        List< Assignment> GetsByTeacherId(int teacherId)
        {
            MySqlCommand mySqlCommand = new MySqlCommand("select * from " + TableName + " where teacherid = '" + teacherId + "'", MysqlHelper.Connection);//读取数据函数  
            MySqlDataReader reader = mySqlCommand.ExecuteReader();
            try
            {

                List<Assignment> list = new List<Assignment>();
                while (reader.Read())
                {
                    if (reader.HasRows)
                    {
                        Assignment item = new Assignment();
                        item.Id = reader.GetInt32(0);
                        item.Name = reader.GetString(1);
                        item.Iocn = reader.GetString(2);
                        item.LevelUpLimit = reader.GetInt32(3);
                        item.AssignmentType = (AssignmentType)reader.GetInt32(4);
                        item.Cion = reader.GetInt32(5);
                        item.Does = reader.GetString(0);
                        item.TeacherId = reader.GetInt32(0);
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
        }                              //读取表格

        Dictionary<int, AssignmentItem> GetItemsByRolerId(int rolerid)
        {
            Dictionary<int, AssignmentItem> items = new Dictionary<int, AssignmentItem>();
            List<AssignmentItemDB> itemDBs = GetItemdbsByRolerId(rolerid);
            for (int i = 0; i < itemDBs.Count; i++)
            {
                AssignmentItem item = new AssignmentItem(itemDBs[i]);
                Assignment assignment  = GetById(itemDBs[i].AssignmentId);
                item.Assignment = assignment;
                items.Add(item.Id, item);
            }
            return items;
        }        //得到userid所有角色列表
        List<AssignmentItemDB> GetItemdbsByRolerId(int rolerid)
        {
            MySqlCommand mySqlCommand = new MySqlCommand("select * from " + ItemTableName + " where rolerid = '" + rolerid + "'", MysqlHelper.Connection);  //读取数据函数  
            MySqlDataReader reader = mySqlCommand.ExecuteReader();
            try
            {
                List<AssignmentItemDB> list = new List<AssignmentItemDB>();
                while (reader.Read())
                {
                    if (reader.HasRows)
                    {
                        AssignmentItemDB item = new AssignmentItemDB();
                        item.Id = reader.GetInt32(0);
                        item.Rolerid = reader.GetInt32(1);
                        item.AssignmentId = reader.GetInt32(2);
                        item.AssignmentState = (AssignmentState)reader.GetInt32(3);
                        item.UpdateTime = reader.GetString(4);
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
        }               //读取表格
        Assignment GetById(int id)
        {
            MySqlCommand mySqlCommand = new MySqlCommand("select * from " + TableName + " where id = '" + id + "'", MysqlHelper.Connection);//读取数据函数  
            MySqlDataReader reader = mySqlCommand.ExecuteReader();
            try
            {
                Assignment item = new Assignment();
                while (reader.Read())
                {
                    if (reader.HasRows)
                    {
                        item.Id = reader.GetInt32(0);
                        item.Name = reader.GetString(1);
                        item.Iocn = reader.GetString(2);
                        item.LevelUpLimit = reader.GetInt32(3);
                        item.AssignmentType = (AssignmentType)reader.GetInt32(4);
                        item.Cion = reader.GetInt32(5);
                        item.Does = reader.GetString(0);
                        item.TeacherId = reader.GetInt32(0);
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
        }                                            //读取表格




    }
}
