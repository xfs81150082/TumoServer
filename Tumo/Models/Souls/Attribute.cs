using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Tumo.Models
{
    public class Attribute : AttributeValue
    {
        public int Id { get => id; set => id = value; }
        public string Name { get => name1; set => name1 = value; }
        public string Icon { get => icon; set => icon = value; }
        public string AvatarName { get => avatarName; set => avatarName = value; }
        public int ChaterId { get => chaterId; set => chaterId = value; }
        public int LevelUpLimit { get => levelUpLimit; set => levelUpLimit = value; }
        public string Does { get => does; set => does = value; }

        public Attribute() { }
        private int id = 15101;                                //编号
        private string name1 = "人族";                         //家族名称
        private string icon = "headimagegirl";                 //图标
        private string avatarName = "15101_AncientWarrior";    //预制体名称
        private int chaterId = 111;                            //章节号 
        private int levelUpLimit = 30;                         //等级上级 
        private string does = "人族是最智慧的生灵之一";        //简介  
    }
}
