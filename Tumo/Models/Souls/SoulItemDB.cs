using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Tumo.Models
{
    [Serializable]
    public class SoulItemDB
    {
        public int Id { get => id; set => id = value; }
        public string Name { get => name2; set => name2 = value; }
        public int SoulId { get => soulId; set => soulId = value; }
        public int UserId { get => userId; set => userId = value; }
        public int Exp { get => exp; set => exp = value; }
        public int Level { get => level; set => level = value; }
        public int Hp { get => hp; set => hp = value; }
        public int Mp { get => mp; set => mp = value; }
        public int Coin { get => coin; set => coin = value; }
        public int Diamond { get => diamond; set => diamond = value; }
        public int SenceId { get => senceId; set => senceId = value; }
        public int NodeId { get => nodeId; set => nodeId = value; }
        public double px { get => _px; set => _px = value; }
        public double py { get => _py; set => _py = value; }
        public double pz { get => _pz; set => _pz = value; }
        public double ax { get => _ax; set => _ax = value; }
        public double ay { get => _ay; set => _ay = value; }
        public double az { get => _az; set => _az = value; }
        public int ServerId { get => serverId; set => serverId = value; }
        public DateTime CreateDateTime { get => createDateTime; set => createDateTime = value; }

        public SoulItemDB() { }
        private int id = 100001;
        private string name2 = "tumo";
        private int soulId = 15101;
        private int userId = 0;             //用户名
        private int exp = 0;                //经验数
        private int level = 0;              //等级
        private int hp = 0;                 //血量
        private int mp = 0;                 //法量          
        private int coin = 0;               //金币数  
        private int diamond = 0;            //钻石数
        private int senceId = 0;           //场景id
        private int nodeId = 0;           //场景id
        private double _px = 0.0;          //坐标x
        private double _py = 0.0;          //坐标x
        private double _pz = 0.0;          //坐标x  
        private double _ax = 0.0;          //坐标w-朝向
        private double _ay = 0.0;          //坐标x  
        private double _az = 0.0;          //坐标w-朝向
        private int serverId = 0;          //服务Id
        private DateTime createDateTime = DateTime.Now;      //角色创建日期
    }
}
