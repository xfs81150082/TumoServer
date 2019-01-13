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
        public TClient() { }
        public override void TmAwake() { }
        public override void TmUpdate() { }
        public override void OnTransferParameter(string mvcString)
        {
            ///将字符串string,用json反序列化转换成MvcParameter参数
            MvcParameter mvc = MvcTool.ToObject<MvcParameter>(mvcString);
            mvc.EcsId = this.EcsId;
            if (mvc.ElevenCode == ElevenCode.HeartBeat)
            {
                TmAsyncTcpClient.Instance.CoolDownItemSignIn(mvc);
            }
            else if (mvc.ElevenCode == ElevenCode.RemoveHeartBeat)
            {
                TmAsyncTcpClient.Instance.RemoveCoolDownItem(mvc);
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
            Console.WriteLine("{0} 服务端{1}连接成功", TmTimer.GetCurrentTime(), EcsId);
            TmAsyncTcpClient.Instance.TClient = this;
            new TmClientCDItem(this.EcsId);
        }///与服务器连接时调用  

        public override void TmDispose()
        {
            base.TmDispose();
            Console.WriteLine("{0} 服务端{1}断开连接", TmTimer.GetCurrentTime(), EcsId);
        }///与服务器断开时调用 


    }
}
