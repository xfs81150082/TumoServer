using System;
using System.Collections.Generic;
using Tumo;
namespace Servers
{
    class TmKnapsackMysql : TmInventoryMysql
    {
        public override void TmAwake()
        {
            base.TmAwake();
            DatabaseFormName = "knapsackitem";
        }
        public override void OnTransferParameter(object sender, TmParameter parameter)
        {
            ElevenCode elevenCode = parameter.ElevenCode;
            switch (elevenCode)
            {
                case (ElevenCode.GetInventorys):
                    Console.WriteLine(TmTimerTool.CurrentTime() + " TmKnapsackMysql: " + elevenCode);
                    GetKnapsackByRolerId(sender, parameter);
                    break;
                case (ElevenCode.Get):
                    Console.WriteLine(TmTimerTool.CurrentTime() + " TmKnapsackMysql: " + elevenCode);
                    GetInventory(sender, parameter);
                    break;
                case (ElevenCode.None):
                    break;
                default:
                    break;
            }
        }
        void GetInventory(object sender, TmParameter parameter)
        {
            Dictionary<int,TmInventory> inventorys = GetInventorys();
            Console.WriteLine(TmTimerTool.CurrentTime() + " inventorys:" + inventorys.Count);
            if (inventorys.Count > 0)
            {
                (sender as TmKnapsackHandler).Inventorys = inventorys;
            }
            else
            {
                Console.WriteLine(TmTimerTool.CurrentTime() + " 没有角色");
            }
        }
        void GetKnapsackByRolerId(object sender, TmParameter parameter)
        {
            int rolerid = TmParameterTool.GetJsonValue<int>(parameter, ElevenCode.EngineerLogin.ToString());
            List<TmInventoryDB> dbs = GetInventorydbsByRolerId(rolerid);
            Console.WriteLine(TmTimerTool.CurrentTime() + " TmKnapsackMysql-dbs: " + dbs.Count);
            if (dbs.Count > 0)
            {
                (sender as TmKnapsackHandler).Knapsacks.Add(rolerid, dbs);
            }
            else
            {
                Console.WriteLine(TmTimerTool.CurrentTime() + " 没有角色");
            }
        }

    }
}