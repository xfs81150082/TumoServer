using Tumo.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading;

namespace Tumo
{
    public class TmClient : TmTcpSession
    {
        public TmClient()
        {
            TmNetTcp.Instance.TClient = this;
            (CD as TmSessionCD).IsServer = false;
        }                 
        public override void OnConnect()
        {
            ///显示与客户端连接
            Console.WriteLine("{0} 服务端{1}连接成功", TmTimerTool.CurrentTime(), EcsId);
        }///与服务器连接时调用  
        public override void TmDispose()
        {
            base.TmDispose();
            if (TmNetTcp.Instance.TClient != null && TmNetTcp.Instance.TClient == this)
            {
                TmNetTcp.Instance.TClient = null;
            }
            Console.WriteLine("{0} 服务端{1}断开连接", TmTimerTool.CurrentTime(), EcsId);
        }///与服务器断开时调用                      
    }
}
