using System;
using System.Collections.Generic;
using Tumo;
namespace Servers
{
    class TmSmityHandler : TmComponent
    {
        public override void OnTransferParameter(object obj, TmParameter parameter)
        {
            ElevenCode elevenCode = parameter.ElevenCode;
            switch (elevenCode)
            {
                case (ElevenCode.GetInventorys):
                    Console.WriteLine(TmTimerTool.CurrentTime() + " TmSmityHandler: " + elevenCode);
                    GetSkillsByRolerId(parameter);
                    break;
                case (ElevenCode.GetInventory):
                    Console.WriteLine(TmTimerTool.CurrentTime() + " TmSmityHandler: " + elevenCode);
                    break;
                case (ElevenCode.Save):
                    Console.WriteLine(TmTimerTool.CurrentTime() + " TmSmityHandler: " + elevenCode);
                    break;
                case (ElevenCode.None):
                    break;
                default:
                    break;
            }
        }
        internal TmInventoryDB Smithy;
        internal Dictionary<int, List<TmInventoryDB>> Smithys { get; set; }
        private void GetSkillsByRolerId(TmParameter parameter)
        {
            int rolerid = TmParameterTool.GetJsonValue<int>(parameter, ElevenCode.GetSkills.ToString());
            List<TmInventoryDB> inventoryDBs;
            bool yes = false;
            while (!yes)
            {
                yes = Smithys.TryGetValue(rolerid, out inventoryDBs);
                if (yes)
                {
                    TmParameter response = TmParameterTool.ToJsonParameter<List<TmInventoryDB>>(TenCode.Smithy, ElevenCode.GetInventorys, ElevenCode.GetInventorys.ToString(), inventoryDBs);
                    response.EcsId = parameter.EcsId;
                    TmTcpSocket.Instance.Send(response);
                    break;
                }
                else
                {
                    TmMysqlHandler.Instance.GetComponent<TmSmithyMysql>().OnTransferParameter(this, parameter);
                    Console.WriteLine(TmTimerTool.CurrentTime() + " this.Abilities:" + this.Smithys.Count);
                }
            }
        }


    }
}
