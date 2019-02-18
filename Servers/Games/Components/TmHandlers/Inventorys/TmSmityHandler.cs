using System;
using System.Collections.Generic;
using Tumo;
namespace Servers
{
    class TmSmityHandler : TmEntity
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
                case (ElevenCode.Save):
                    Console.WriteLine(TmTimerTool.CurrentTime() + " TmSmityHandler: " + elevenCode);
                    break;
                case (ElevenCode.None):
                    break;
                default:
                    break;
            }
        }
        internal Dictionary<int, List<TmInventoryDB>> Smithys { get; set; } = new Dictionary<int, List<TmInventoryDB>>();
        private void GetSkillsByRolerId(TmParameter parameter)
        {
            int rolerid = TmParameterTool.GetJsonValue<int>(parameter, ElevenCode.EngineerLogin.ToString());
            List<TmInventoryDB> inventoryDBs;
            bool yes = false;
            int count = 0;
            while (!yes)
            {
                yes = Smithys.TryGetValue(rolerid, out inventoryDBs);
                if (yes)
                {
                    TmParameter response = TmParameterTool.ToJsonParameter<List<TmInventoryDB>>(TenCode.Smithy, ElevenCode.GetInventorys, ElevenCode.GetInventorys.ToString(), inventoryDBs);
                    TmParameterTool.AddJsonParameter(response, "RolerId", rolerid);
                    response.EcsId = parameter.EcsId;
                    TmTcpSocket.Instance.Send(response);
                    yes = true;
                    break;
                }
                else
                {
                    TmMysqlHandler.Instance.GetComponent<TmSmithyMysql>().OnTransferParameter(this, parameter);
                    Console.WriteLine(TmTimerTool.CurrentTime() + " this.Smithys:" + this.Smithys.Count);
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
