using System;
using System.Collections.Generic;
using Tumo;
namespace Servers
{
    class TmStatusSyncHandler : TmComponent
    {       
        public override void OnTransferParameter(object sender, TmParameter parameter)
        {
            ElevenCode elevenCode = parameter.ElevenCode;
            switch (elevenCode)
            {
                case (ElevenCode.StatusSync):
                    Console.WriteLine(TmTimerTool.CurrentTime() + " TmStatusSyncHandler: " + elevenCode);
                    InStatusSync(parameter);
                    break;
                case (ElevenCode.Remove):
                    Console.WriteLine(TmTimerTool.CurrentTime() + " TmStatusSyncHandler: " + elevenCode);
                    RemoveStatus(parameter);
                    break;
                case (ElevenCode.None):
                    break;
                default:
                    break;
            }
        }
        public Dictionary<int, TmStatus> Statuses = new Dictionary<int, TmStatus>();
        void InStatusSync(TmParameter parameter)
        {
            TmStatus status = TmParameterTool.GetJsonValue<TmStatus>(parameter, ElevenCode.StatusSync.ToString());
            status.Key = parameter.Key;
            TmStatus tem;
            Statuses.TryGetValue(status.RoelerId, out tem);
            if (tem != null)
            {
                tem = status;
            }
            else
            {
                Statuses.Add(status.RoelerId, status);
            }
            OutStatusSync(status);
        }
        void OutStatusSync(TmStatus status)
        {
            foreach(var tem in TmTcpSocket.Instance.TPeers.Values)
            {
                TmParameter par = TmParameterTool.ToJsonParameter(TenCode.Status, ElevenCode.StatusSync, ElevenCode.StatusSync.ToString(), status);
                par.Key = tem.EcsId;
                TmTcpSocket.Instance.Send(par);
            }
        }
        void RemoveStatus(TmParameter parameter)
        {
            TmStatus status = TmParameterTool.GetJsonValue<TmStatus>(parameter, ElevenCode.StatusSync.ToString());
            Statuses.Remove(status.RoelerId);
        }
    }
}