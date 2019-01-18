using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Tumo
{
    public class TmLabel : TmComponent
    {
        public string Icon { get; set; } = "headimagegirl";                 //图标
        public string AvatarName { get; set; } = "15101_AncientWarrior";    //预制体名称
        public int ChaterId { get; set; } = 111;                            //章节号 
        public int LevelUpLimit { get; set; } = 30;                         //等级上级 
        public string Does { get; set; } = "人族是最智慧的生灵之一";        //简介  
    }
}
