using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tumo;
namespace Servers
{
    class TmInventoryDBSystem : TmSystem
    {
        public override void TmAwake()
        {
            ValTime = 4000;
            AddComponent(new TmSession());
        }
        public override void TmUpdate()
        {
            foreach (TmEntity entity in GetTmEntities())
            {
                SetInventoryDBs(entity);
            }
        }
        void SetInventoryDBs(TmEntity entity)
        {
            TmSession session = entity.GetComponent<TmSession>();
            if (session.InventoryDBs == null) return;
            if (session.inventorysChange != session.InventoryDBs.Count && session.InventoryDBs.Count > 0 && session.IsLogin)
            {
                TmParameter response = TmParameterTool.ToJsonParameter(TenCode.Knapsack, ElevenCode.SetIventoryDBs, ElevenCode.SetIventoryDBs.ToString(), session.InventoryDBs);
                response.Keys.Add(entity.EcsId);
                TmTcpSocket.Instance.Send(response);
                session.inventorysChange = session.InventoryDBs.Count;
                Console.WriteLine(TmTimerTool.CurrentTime() + " TmInventoryDBSystem-session.InventoryDBs:" + session.InventoryDBs.Count);
            }
        }


    }
}
