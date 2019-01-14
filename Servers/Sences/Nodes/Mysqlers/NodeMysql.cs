using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tumo;
using Tumo.Models;
using MySql.Data.MySqlClient;
using Servers;

namespace Servers.Sences.Nodes.Mysqlers
{
    class NodeMysql : NodeMysqlBase
    {
        public override string Code => TenCode.Node.ToString();

        public override void OnTransferParameter(MvcParameter mvc)
        {
            ElevenCode elevenCode = mvc.ElevenCode;
            switch (elevenCode)
            {             
                case (ElevenCode.None):
                    break;
            }
        }


        private string TableName = "measurementnode";
        public NodeMysql()
        {
            //UpdateItems();
        }

        void UpdateItems()
        {
            NodeInfo.Instance.NodeItems = GetNodeItems();
            NodeInfo.Instance.MapNodes = GetMapNodes();
            Console.WriteLine("MeasurementNodeMysqlTabler-NodeItems: " + GetNodeItems().Count + " MeasurementNodeInfo: " + NodeInfo.Instance.NodeItems.Count);
            //Console.WriteLine("MeasurementNodeMysqlTabler-GetMapNodeIds: " + GetMapNodes().Length + " MeasurementNodeInfo: " + NodeInfo.Instance.MapNodeIds.LongLength);
        }

        Dictionary<int, NodeItem> GetNodeItems()
        {
            Dictionary<int, NodeItem> items = new Dictionary<int, NodeItem>();
            List<Node> tems = GetNodes();
            for (int i = 0; i < tems.Count; i++)
            {
                NodeItem item = new NodeItem(tems[i]);
                items.Add(item.Id, item);
                //Console.WriteLine("Node: " + item.Id);
            }
            return items;
        }               //得到SoulItemName列表中的所有角色列表
        List<Node> GetNodes()
        {
            MySqlCommand mySqlCommand = new MySqlCommand("select * from " + TableName, MysqlHelper.Connection);//读取数据函数  
            MySqlDataReader reader = mySqlCommand.ExecuteReader();
            try
            {
                List<Node> list = new List<Node>();
                while (reader.Read())
                {
                    if (reader.HasRows)
                    {
                        Node item = new Node();
                        item.Id = reader.GetInt32(0);
                        item.Name = reader.GetString(1);
                        item.Idx = reader.GetInt32(2);
                        item.Idy = reader.GetInt32(3);
                        item.Px = reader.GetInt32(4);
                        item.Py = reader.GetInt32(5);
                        item.Pz = reader.GetInt32(6);
                        item.Lx = reader.GetInt32(7);
                        item.Ly = reader.GetInt32(8);
                        item.MoveType = reader.GetInt32(9);
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
        }                                  //读取表格
        
        NodeItem[,] GetMapNodes()
        {
            NodeItem[,] arrays = new NodeItem[10, 10];
            for(int y = 0; y < 10; y++)
            {
                for(int x = 0; x < 10; x++)
                {
                    arrays[x, y] = GetNodeItemByIdxy(x + 1, y + 1);
                    //Console.WriteLine(ServerHelper.Instance.GetCurrentTime() + " arrays:px " + arrays[x, y].Node.Px + " py: " + arrays[x, y].Node.Py);
                }
            }
            return arrays;
        }
        NodeItem GetNodeItemByIdxy(int x,int y)
        {
            Node node = GetNodeByIdxy(x, y);
            if (node == null) return null;
            NodeItem nodeItem = new NodeItem(node);
            return nodeItem;
        }
        Node GetNodeByIdxy(int x, int y)
        {
            MySqlCommand mySqlCommand = new MySqlCommand("select * from " + TableName + " where idx = " + "'" + x + "'" + " and idy = " + "'" + y + "'", MysqlHelper.Connection);//读取数据函数  
            MySqlDataReader reader = mySqlCommand.ExecuteReader();
            try
            {
                Node item = new Node();
                while (reader.Read())
                {
                    if (reader.HasRows)
                    {
                        item.Id = reader.GetInt32(0);
                        item.Name = reader.GetString(1);
                        item.Idx = reader.GetInt32(2);
                        item.Idy = reader.GetInt32(3);
                        item.Px = reader.GetInt32(4);
                        item.Py = reader.GetInt32(5);
                        item.Pz = reader.GetInt32(6);
                        item.Lx = reader.GetInt32(7);
                        item.Ly = reader.GetInt32(8);
                        item.MoveType = reader.GetInt32(9);
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
        }


    }
}
