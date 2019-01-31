using System;
using System.Collections.Generic;
using Tumo;
namespace Servers
{
    class TmServerSocketSystem : TmSystem
    {
        public override void TmAwake()
        {
            base.TmAwake();
            AddComponent(new TmTcpServer());
        }
        public override void TmUpdate()
        {
            foreach (var tem in GetTmEntities())
            {
                if (GetTmEntities().Count > 0)
                {
                    ServerStart(tem);
                    ServerRecvParameters(tem);
                }
            }
        }
        void ServerStart(TmEntity entity)
        {
            if (!(entity.GetComponent<TmTcpServer>() as TmTcpServer).IsRunning)
            {
                (entity.GetComponent<TmTcpServer>() as TmTcpServer).Init("127.0.0.1", 8115, 10);
                (entity.GetComponent<TmTcpServer>() as TmTcpServer).StartListen();
            }
        }
        void ServerRecvParameters(TmEntity entity)
        {
            try
            {
                while ((entity.GetComponent<TmTcpServer>() as TmTcpServer).RecvParameters.Count > 0)
                {
                    TmParameter parameter = (entity.GetComponent<TmTcpServer>() as TmTcpServer).RecvParameters.Dequeue();
                    if (TmGateHandler.Instance != null)
                    {
                        TmGateHandler.Instance.OnTransferParameter(this, parameter);
                        Console.WriteLine(TmTimerTool.CurrentTime() + " RecvParameters: " + (entity.GetComponent<TmTcpServer>() as TmTcpServer).RecvParameters.Count);
                    }
                    else
                    {
                        Console.WriteLine(TmTimerTool.CurrentTime() + " TumoGate is null.");
                        break;
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(TmTimerTool.CurrentTime() + ex.Message);
            }
        }

    }
}