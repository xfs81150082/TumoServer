using System;
using System.Collections.Generic;
using Tumo;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections;

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
                case (ElevenCode.Save):
                    Console.WriteLine(TmTimerTool.CurrentTime() + " TmKnapsackHandler: " + elevenCode);


                    break;
                case (ElevenCode.None):
                    break;
                default:
                    break;
            }
        }
        internal Dictionary<int, List<TmInventoryDB>> Knapsacks { get; set; } = new Dictionary<int, List<TmInventoryDB>>();
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

                    if (TmTcpSocket.Instance.TPeers[parameter.Keys[0]] != null)
                    {
                        TmTcpSocket.Instance.TPeers[parameter.Keys[0]].GetComponent<TmSession>().InventoryDBs = inventoryDBs;  //给TmTcpSession赋值Engineer-SoulerDB
                    }
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
