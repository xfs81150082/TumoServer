using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tumo;
namespace Servers
{
    class TmEngineerSystem : TmSystem
    {
        public override void TmUpdate()
        {
            GetEngineers();
        }
        int engineerChange = -1;
        void GetEngineers()
        {
            if (engineerChange != TmTcpSocket.Instance.TPeers.Count && TmTcpSocket.Instance.TPeers.Count > 0)
            {
                Dictionary<string, TmSoulerDB> soulerDBs = new Dictionary<string, TmSoulerDB>();
                //lock (TmTcpSocket.Instance.TPeers)
                foreach (var tem in TmTcpSocket.Instance.TPeers.Values)
                {
                    TmSoulerDB soulerDB = tem.GetComponent<TmSession>().Engineer; 
                    soulerDBs.Add(soulerDB.Id.ToString(), soulerDB);
                }
                TmObjects.Engineers = soulerDBs;
                engineerChange = TmTcpSocket.Instance.TPeers.Count;
            }
        }  

    }
}