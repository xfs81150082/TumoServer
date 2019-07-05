using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
namespace Tumo
{
    class TmSkillInit : TmComponent
    {
        public override void TmAwake()
        {
            TmSoulerInfo();
        }
        void TmSoulerInfo()
        {
            TmObjects.Skills = GetTmSoulers();
        }
        Dictionary<int, TmSkill> GetTmSoulers()
        {
            Dictionary<int, TmSkill> soulers = new Dictionary<int, TmSkill>();
            TmSkill souler11101 = GetTmSouler("尘暴", 11101, "headimageboy", "BookerOne", "Icon_Player01", 30, "是最--的法术", RoleType.Engineer, EquipType.Box, InfoType.Bp, Quality.White, 4);
            soulers.Add(souler11101.Id, souler11101);
            TmSkill souler11102 = GetTmSouler("龙卷风", 11102, "headimagegirl", "BookerOne", "Icon_Player01", 30, "是最--的法术", RoleType.Engineer, EquipType.Box, InfoType.Bp, Quality.Green, 4);
            soulers.Add(souler11102.Id, souler11102);
            TmSkill souler11103 = GetTmSouler("鬼手", 11103, "headimageboy", "BookerOne", "Icon_Player01", 30, "是最--的法术", RoleType.Engineer, EquipType.Box, InfoType.Bp, Quality.Blue, 4);
            soulers.Add(souler11103.Id, souler11103);
            TmSkill souler11104 = GetTmSouler("圣火", 11104, "headimagegirl", "BookerOne", "Icon_Player01", 30, "是最--的法术", RoleType.Engineer, EquipType.Box, InfoType.Bp, Quality.Violet, 4);
            soulers.Add(souler11104.Id, souler11104);
            TmSkill souler11105 = GetTmSouler("火凤凰", 11105, "headimageboy", "BookerOne", "Icon_Player01", 30, "是最--的法术", RoleType.Engineer, EquipType.Box, InfoType.Bp, Quality.Orange, 4);
            soulers.Add(souler11105.Id, souler11105);
            TmSkill souler12101 = GetTmSouler("尘暴", 12101, "headimageboy", "BookerOne", "Icon_Player01", 30, "是最--的法术", RoleType.Booker, EquipType.Box, InfoType.Bp, Quality.White, 4);
            soulers.Add(souler12101.Id, souler12101);
            TmSkill souler12102 = GetTmSouler("龙卷风", 12102, "headimagegirl", "BookerOne", "Icon_Player01", 30, "是最--的法术", RoleType.Booker, EquipType.Box, InfoType.Bp, Quality.Green, 4);
            soulers.Add(souler12102.Id, souler12102);
            TmSkill souler12103 = GetTmSouler("鬼手", 12103, "headimageboy", "BookerOne", "Icon_Player01", 30, "是最--的法术", RoleType.Booker, EquipType.Box, InfoType.Bp, Quality.Blue, 4);
            soulers.Add(souler12103.Id, souler12103);
            TmSkill souler12104 = GetTmSouler("圣火", 12104, "headimageboy", "BookerOne", "Icon_Player01", 30, "是最--的法术", RoleType.Booker, EquipType.Box, InfoType.Bp, Quality.Violet, 4);
            soulers.Add(souler12104.Id, souler12104);
            TmSkill souler12105 = GetTmSouler("火凤凰", 12105, "headimagegirl", "BookerOne", "Icon_Player01", 30, "是最--的法术", RoleType.Booker, EquipType.Box, InfoType.Bp, Quality.Orange, 4);
            soulers.Add(souler12105.Id, souler12105);  
            return soulers;
        }
        TmSkill GetTmSouler(string name, int id, string icon, string avatarname, string chater, int leveluplimit, string does, RoleType roleType, EquipType equipType, InfoType infoType, Quality quality, int maxcoldtime)
        {
            TmSkill souler = new TmSkill();
            souler.Name = name;
            souler.Id = id;
            souler.Icon = icon;
            souler.AvatarName = avatarname;
            souler.Chater = chater;
            souler.Does = does;
            souler.RoleType = roleType;
            souler.EquipType = equipType;
            souler.InfoType = infoType;
            souler.Quality = quality;
            souler.MaxColdTime = maxcoldtime;
            return souler;
        }





    }
}
