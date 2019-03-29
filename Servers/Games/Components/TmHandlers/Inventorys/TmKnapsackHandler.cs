using System;
using System.Collections.Generic;
using Tumo;
namespace Servers
{
    class TmKnapsackHandler : TmEntity
    {
        public override void OnTransferParameter(object obj, TmParameter parameter)
        {
            ElevenCode elevenCode = parameter.ElevenCode;
            switch (elevenCode)
            {
                case (ElevenCode.GetInventorys):
                    Console.WriteLine(TmTimerTool.CurrentTime() + " TmKnapsackHandler: " + elevenCode);
                    GetSkillsByRolerId(parameter);
                    break;
                case (ElevenCode.Get):
                    Console.WriteLine(TmTimerTool.CurrentTime() + " TmKnapsackHandler: " + elevenCode);
                    GetInventorys(parameter);
                    break;
                case (ElevenCode.Save):
                    Console.WriteLine(TmTimerTool.CurrentTime() + " TmKnapsackHandler: " + elevenCode);
                    break;
                case (ElevenCode.None):
                    break;
                default:
                    break;
            }
        }
        internal Dictionary<int, TmInventory> Inventorys { get; set; } = new Dictionary<int, TmInventory>();
        internal Dictionary<int, List<TmInventoryDB>> Knapsacks { get; set; } = new Dictionary<int, List<TmInventoryDB>>();
        private void GetInventorys(TmParameter parameter)
        {
            bool yes = false;
            int count = 0;
            while (!yes)
            {
                if (Inventorys.Count > 0)
                {
                    TmParameter response = TmParameterTool.ToJsonParameter<Dictionary<int, TmInventory>>(TenCode.Knapsack, ElevenCode.Get, ElevenCode.Get.ToString(), Inventorys);
                    response.Keys.Add(parameter.Keys[0]);
                    TmTcpSocket.Instance.Send(response);
                    yes = true;
                }
                else
                {
                    TmMysqlHandler.Instance.GetComponent<TmKnapsackMysql>().OnTransferParameter(this, parameter);
                    Console.WriteLine(TmTimerTool.CurrentTime() + " this.Inventorys:" + this.Inventorys.Count);
                    count += 1;
                }
                if (count > 4)
                {
                    yes = true;
                    break;
                }
            }
        }
        private void GetSkillsByRolerId(TmParameter parameter)
        {
            int rolerid = TmParameterTool.GetJsonValue<int>(parameter, ElevenCode.EngineerLogin.ToString());
            List<TmInventoryDB> inventoryDBs;
            bool yes = false;
            int count = 0;
            while (!yes)
            {
                yes = Knapsacks.TryGetValue(rolerid, out inventoryDBs);
                if (yes)
                {
                    TmParameter response = TmParameterTool.ToJsonParameter<List<TmInventoryDB>>(TenCode.Knapsack, ElevenCode.GetInventorys, ElevenCode.GetInventorys.ToString(), inventoryDBs);
                    TmParameterTool.AddJsonParameter(response, "RolerId", rolerid);
                    response.Keys.Add(parameter.Keys[0]);
                    TmTcpSocket.Instance.Send(response);
                    yes = true;
                    break;
                }
                else
                {
                    TmMysqlHandler.Instance.GetComponent<TmKnapsackMysql>().OnTransferParameter(this, parameter);
                    Console.WriteLine(TmTimerTool.CurrentTime() + " this.Knapsacks:" + this.Knapsacks.Count);
                    count += 1;
                }
                if (count > 4)
                {
                    yes = true;
                    break;
                }
            }
        }


    }
}
