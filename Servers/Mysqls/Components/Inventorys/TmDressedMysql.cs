﻿using System;
using System.Collections.Generic;
using Tumo;
namespace Servers
{
    class TmDressedMysql : TmInventoryMysql
    {
        public override void TmAwake()
        {
            base.TmAwake();
            DatabaseFormName = "dresseditem";
        }
        public override void OnTransferParameter(object sender, TmParameter parameter)
        {
            ElevenCode elevenCode = parameter.ElevenCode;
            switch (elevenCode)
            {
                case (ElevenCode.GetInventorys):
                    Console.WriteLine(TmTimerTool.CurrentTime() + " TmDressedMysql: " + elevenCode);
                    GetDbsByRolerId(sender, parameter);
                    break;
                case (ElevenCode.None):
                    break;
                default:
                    break;
            }
        }
        void GetDbsByRolerId(object sender, TmParameter parameter)
        {
            int rolerid = TmParameterTool.GetJsonValue<int>(parameter, ElevenCode.GetInventorys.ToString());
            List<TmInventoryDB> dbs = GetInventorydbsByRolerId(rolerid);
            if (dbs.Count > 0)
            {
                (sender as TmDressedHandler).Dresseds.Add(rolerid, dbs);
            }
            else
            {
                Console.WriteLine(TmTimerTool.CurrentTime() + " 没有角色");
            }
        }

    }
}