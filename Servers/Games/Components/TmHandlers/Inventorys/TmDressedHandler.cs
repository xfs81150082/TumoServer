using System;
using System.Collections.Generic;
using Tumo;
namespace Servers
{
    class TmDressedHandler : TmComponent
    {
        public override void OnTransferParameter(object obj, TmParameter parameter)
        {
            ElevenCode elevenCode = parameter.ElevenCode;
            switch (elevenCode)
            {
                case (ElevenCode.GetInventorys):
                    Console.WriteLine(TmTimerTool.CurrentTime() + " TmDressedHandler: " + elevenCode);
                    GetSkillsByRolerId(parameter);
                    break;
                case (ElevenCode.GetInventory):
                    Console.WriteLine(TmTimerTool.CurrentTime() + " TmDressedHandler: " + elevenCode);
                    break;
                case (ElevenCode.Save):
                    Console.WriteLine(TmTimerTool.CurrentTime() + " TmDressedHandler: " + elevenCode);
                    break;
                case (ElevenCode.None):
                    break;
                default:
                    break;
            }
        }
        internal TmInventoryDB Dressed;
        internal Dictionary<int, List<TmInventoryDB>> Dresseds { get; set; }
        private void GetSkillsByRolerId(TmParameter parameter)
        {
            int rolerid = TmParameterTool.GetJsonValue<int>(parameter, ElevenCode.GetSkills.ToString());
            List<TmInventoryDB> inventoryDBs;
            bool yes = false;
            while (!yes)
            {
                yes = Dresseds.TryGetValue(rolerid, out inventoryDBs);
                if (yes)
                {
                    TmParameter response = TmParameterTool.ToJsonParameter<List<TmInventoryDB>>(TenCode.Dressed, ElevenCode.GetInventorys, ElevenCode.GetInventorys.ToString(), inventoryDBs);
                    response.EcsId = parameter.EcsId;
                    TmTcpSocket.Instance.Send(response);
                    break;
                }
                else
                {
                    TmMysqlHandler.Instance.GetComponent<TmDressedMysql>().OnTransferParameter(this, parameter);
                    Console.WriteLine(TmTimerTool.CurrentTime() + " this.Abilities:" + this.Dresseds.Count);
                }
            }
        }


    }
}
