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
                case (ElevenCode.Engineer):
                    Console.WriteLine(TmTimerTool.CurrentTime() + " TmStatusSyncHandler: " + elevenCode);
                    EngineerInStatusSync(parameter);
                    break;
                case (ElevenCode.Booker):
                    Console.WriteLine(TmTimerTool.CurrentTime() + " TmStatusSyncHandler: " + elevenCode);
                    BookerInStatusSync(parameter);
                    break;
                case (ElevenCode.Teacher):
                    Console.WriteLine(TmTimerTool.CurrentTime() + " TmStatusSyncHandler: " + elevenCode);
                    TeacherInStatusSync(parameter);
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
        public Dictionary<int, TmStatus> EngineerStatuses = new Dictionary<int, TmStatus>();
        public Dictionary<int, TmStatus> BookerStatuses = new Dictionary<int, TmStatus>();
        public Dictionary<int, TmStatus> TeacherStatuses = new Dictionary<int, TmStatus>();
        void EngineerInStatusSync(TmParameter parameter)
        {
            TmStatus status = TmParameterTool.GetJsonValue<TmStatus>(parameter, ElevenCode.Engineer.ToString());
            status.Key = parameter.Key;
            TmStatus tem;
            EngineerStatuses.TryGetValue(status.RoelerId, out tem);
            if (tem != null)
            {
                tem = status;
            }
            else
            {
                EngineerStatuses.Add(status.RoelerId, status);
            }
            OutStatusSync(status);
        }
        void BookerInStatusSync(TmParameter parameter)
        {
            TmStatus status = TmParameterTool.GetJsonValue<TmStatus>(parameter, ElevenCode.Engineer.ToString());
            status.Key = parameter.Key;
            TmStatus tem;
            BookerStatuses.TryGetValue(status.RoelerId, out tem);
            if (tem != null)
            {
                tem = status;
            }
            else
            {
                BookerStatuses.Add(status.RoelerId, status);
            }
            OutStatusSync(status);
        }
        void TeacherInStatusSync(TmParameter parameter)
        {
            TmStatus status = TmParameterTool.GetJsonValue<TmStatus>(parameter, ElevenCode.Engineer.ToString());
            status.Key = parameter.Key;
            TmStatus tem;
            TeacherStatuses.TryGetValue(status.RoelerId, out tem);
            if (tem != null)
            {
                tem = status;
            }
            else
            {
                TeacherStatuses.Add(status.RoelerId, status);
            }
            OutStatusSync(status);
        }
        void OutStatusSync(TmStatus status)
        {
            foreach (var tem in TmTcpSocket.Instance.TPeers.Values)
            {
                TmParameter par = TmParameterTool.ToJsonParameter(TenCode.StatusSync, ElevenCode.Engineer, ElevenCode.StatusSync.ToString(), status);
                if (tem.EcsId != status.Key)
                {
                    par.Key = tem.EcsId;
                    TmTcpSocket.Instance.Send(par);
                }
            }
        }
        void RemoveStatus(TmParameter parameter)
        {
            TmStatus status = TmParameterTool.GetJsonValue<TmStatus>(parameter, ElevenCode.StatusSync.ToString());
            EngineerStatuses.Remove(status.RoelerId);
        }
    }
}