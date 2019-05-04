using System;
using UnityEngine;

namespace Tumo
{
    public class TmClient : TmTcpSession
    {
        public TmClient()
        {
            //TmTcpSocket.Instance.TClient = this;
            this.GetComponent<TmCoolDown>().IsServer = false;
        }                 
        public override void OnConnect()
        {
            ///显示与客户端连接
            Console.WriteLine("{0} 服务端{1}连接成功", TmTimerTool.CurrentTime(), EcsId);
        }///与服务器连接时调用  
        public override void TmDispose()
        {
            base.TmDispose();
            if (TmTcpSocket.Instance.TClient != null && TmTcpSocket.Instance.TClient.EcsId == this.EcsId)
            {
                TmTcpSocket.Instance.TClient = null;
            }
            Console.WriteLine("{0} 服务端{1}断开连接", TmTimerTool.CurrentTime(), EcsId);
        }///与服务器断开时调用                      
    }
}
