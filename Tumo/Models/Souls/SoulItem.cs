using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Tumo.Models
{
    [Serializable]
    public class SoulItem : AttributeValue
    {
        public int Id { get => id; set => id = value; }
        public string Name { get => name2; set => name2 = value; }
        public SoulItemDB SoulItemDB { get => _soulItemDB; }
        public Soul Soul { get => _soul; set => _soul = value; }
        public int UserId { get => _userId; set => _userId = value; }
        public int Exp { get => _exp; set => _exp = value; }
        public int Level { get => level; set => level = value; }
        public int Coin { get => _coin; set => _coin = value; }
        public int Diamond { get => _diamond; set => _diamond = value; }
        public int SenceId { get => _senceId; set => _senceId = value; }
        public int NodeId { get => _nodeId; set => _nodeId = value; }
        public double px { get => _px; set => _px = value; }
        public double py { get => _py; set => _py = value; }
        public double pz { get => _pz; set => _pz = value; }
        public double ax { get => _ax; set => _ax = value; }
        public double ay { get => _ay; set => _ay = value; }
        public double az { get => _az; set => _az = value; }
        public int ServerId { get => serverId; set => serverId = value; }
        public bool MasterController { get => masterController; set => masterController = value; }
        public AttributeAdd InventoryAdd { get => _inventoryAdd; set => _inventoryAdd = value; }
        public AttributeAdd BuffAdd { get => _buffAdd; set => _buffAdd = value; }
        public AttributeAdd SkillAdd { get => _skillAdd; set => _skillAdd = value; }

        public SoulItem() { } //构造函数 
        public SoulItem(SoulItemDB itemDB)
        {
            this._soulItemDB = itemDB;
            this.Id = itemDB.Id;
            this.Name = itemDB.Name;
            this.UserId = itemDB.UserId;
            this.Exp = itemDB.Exp;
            this.Level = itemDB.Level;
            this.Hp = itemDB.Hp;
            this.Mp = itemDB.Mp;
            this.Coin = itemDB.Coin;
            this.Diamond = itemDB.Diamond;
            this.SenceId = itemDB.SenceId;
            this.NodeId = itemDB.NodeId;
            this.px = itemDB.px;
            this.py = itemDB.py;
            this.pz = itemDB.pz;
            this.ax = itemDB.ax;
            this.ay = itemDB.ay;
            this.az = itemDB.az;
            this.serverId = itemDB.ServerId;
            InitAttribute();
        }
        public SoulItemDB CreatSoulItemDB()
        {
            _soulItemDB.Id = Id;
            _soulItemDB.Name = Name;
            _soulItemDB.SoulId = Soul.Id;
            _soulItemDB.UserId = UserId;
            _soulItemDB.Exp = Exp;
            _soulItemDB.Level = Level;
            _soulItemDB.Hp = Hp;
            _soulItemDB.Mp = Mp;
            _soulItemDB.Coin = Coin;
            _soulItemDB.Diamond = Diamond;
            _soulItemDB.SenceId = SenceId;
            _soulItemDB.NodeId = NodeId;
            _soulItemDB.px = px;
            _soulItemDB.py = py;
            _soulItemDB.pz = pz;
            _soulItemDB.ax = ax;
            _soulItemDB.ay = ay;
            _soulItemDB.az = az;
            return _soulItemDB;
        }

        public void InitAttribute()
        {
            UpdateLevel();
            Stamina = (Soul.Stamina + Level);
            Brains = (Soul.Brains + Level);
            Power = (Soul.Power + Level);
            Agility = (Soul.Agility + Level);
            MaxHp = (int)Math.Round(Stamina * Soul.StaminaRate);                            //Hp与根骨成正比；暂定10倍；
            MaxMp = (int)Math.Round(Level * Soul.StaminaRate);                              //Mp与等级有关；暂定10倍；
            Bp = (int)Math.Round(Brains * Soul.BrainsRate);                                 //Bp与智力成正比；暂定1倍；
            Ap = (int)Math.Round(Power * Soul.PowerRate);                                   //Ap与力量成正比；暂定1倍；
            Hr = Math.Round((Soul.Hr + (Agility * Soul.AgilityRate) / (100 * Level)), 4);   //hr命中率与敏捷成正比。
            Cr = Math.Round((Soul.Cr + (Agility * Soul.AgilityRate) / (100 * Level)), 4);   //cr暴击率与敏捷成正比。
            Sp = Math.Round((Soul.Sp + (Agility * Soul.AgilityRate) / (100 * Level)), 4);
        } //更新属性
        void UpdateLevel()
        {
            if (Level == Soul.LevelUpLimit) return;
            int expTem = (int)Math.Round((Level + 1.0) * (Level + 1.0) + 10.0);
            if (Exp >= expTem)
            {
                Exp -= expTem;
                Level++;
                if (Level >= Soul.LevelUpLimit)
                {
                    Level = Soul.LevelUpLimit;
                    Exp = 0;
                }
                this.Hp = this.MaxHp;
                this.Mp = this.MaxMp;
            }
            //1-59级：经验值 = ((8 × 角色等级) + 难度系数(角色等级)) × 基础经验值(角色等级) × 经验系数(角色等级)
            //60级：经验值 = 155 + 基础经验值(角色等级) × (1275 - ((69 - 角色等级) × (3 + (69 - 角色等级) × 4)));
            //61-69级：经验值 = 155 + 基础经验值(角色等级) × (1344 - ((69 - 角色等级) × (3 + (69 - 角色等级) × 4)));
            //基础经验值(角色等级) = 45 + (5 × 角色等级) (适用于艾泽拉斯的怪物) 基础经验值(角色等级) = 235 + (5 × 角色等级) (适用于外域的怪物) 基础经验值(角色等级) = 626 + (5 × 角色等级) (适用于诺森德的怪物);
            //难度系数(角色等级) = 0 (角色等级 <= 28) 难度系数(角色等级) = 1 (角色等级 = 29) 难度系数(角色等级) = 3 (角色等级 = 30) 难度系数(角色等级) = 6 (角色等级 = 31) 难度系数(角色等级) = 5 × (角色等级 - 30) (角色等级 >= 32, <= 59);
            //经验系数(角色等级) = 1(角色等级 <= 10) 经验系数(角色等级) = (1 - (角色等级 - 10) / 100)(角色等级 >= 11, <= 27) 经验系数(角色等级) = 0.82(角色等级 >= 28, <= 59);
        } //等级更新        

        private int id = 100001;
        private string name2 = "tumo";
        private SoulItemDB _soulItemDB = new SoulItemDB();
        private Soul _soul = new Soul();
        private int _userId = 0;
        private int _exp = 0;
        private int level = 0;
        private int _coin = 0;
        private int _diamond = 0;
        private int _senceId = 0;
        private int _nodeId = 0;
        private double _px = 0.0;
        private double _py = 0.0;
        private double _pz = 0.0;
        private double _ax = 0.0;
        private double _ay = 0.0;
        private double _az = 0.0;
        private int serverId = 0;
        private bool masterController = false;
        private AttributeAdd _inventoryAdd = new AttributeAdd();
        private AttributeAdd _buffAdd = new AttributeAdd();
        private AttributeAdd _skillAdd = new AttributeAdd();
    }
}
