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
    public class TClient : TmAsyncTcpSession
    {
        public TClient()
        {
            TmAsyncTcpClient.Instance.TClient = this;
            CD = new TmClientCDItem();
            CD.Key = EcsId;
        }          
        public override void OnTransferParameter(string mvcString)
        {
            ///将字符串string,用json反序列化转换成MvcParameter参数
            TmRequest mvc = TmTransferTool.ToObject<TmRequest>(mvcString);
            mvc.EcsId = this.EcsId;
            if (mvc.ElevenCode == ElevenCode.HeartBeat)
            {
                CD.CdCount = 0;
            }
            else
            {
                ///将MvcParameter参数列队
                TmAsyncTcpClient.Instance.RecvParameters.Enqueue(mvc);
            }
        }
        public override void OnConnect()
        {
            ///显示与客户端连接
            Console.WriteLine("{0} 服务端{1}连接成功", TmTimerTool.GetCurrentTime(), EcsId);
        }///与服务器连接时调用  

        public override void TmDispose()
        {
            base.TmDispose();
            if (TmAsyncTcpClient.Instance.TClient != null && TmAsyncTcpClient.Instance.TClient == this)
            {
                TmAsyncTcpClient.Instance.TClient = null;
            }
            Console.WriteLine("{0} 服务端{1}断开连接", TmTimerTool.GetCurrentTime(), EcsId);
        }///与服务器断开时调用 
                     
    }
}
