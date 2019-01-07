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
        #region Properties
        ///客户端Socket 
        public Socket Socket { get; set; }
        private bool isClose = false;
        #endregion

        #region Constructor
        public TClient()  { }
        #endregion

        public override void OnTransferParameter(string mvcString, Socket socket) 
        {
            ///将字符串string,用json反序列化转换成MvcParameter参数
            MvcParameter mvc = MvcTool.ToObject<MvcParameter>(mvcString);
            mvc.Endpoint = socket.RemoteEndPoint.ToString();
            ///将MvcParameter参数列队
            TmAsyncTcpClient.Instance.RecvParameters.Enqueue(mvc);
        }

        #region OnDisconnect
        ///与服务器连接时调用 
        public override void OnConnect(Socket socket)
        {
            this.Socket = socket;            
            TmAsyncTcpClient.Instance.TClient = this;
        }

        ///与服务器断开时调用 
        public override void OnDisconnect(Socket socket)
        {
            if (TmAsyncTcpClient.Instance.TClient != null)
            {
                TmAsyncTcpClient.Instance.TClient = null;
            }
            if (isClose == false)
            {
                socket.Shutdown(SocketShutdown.Both);
                socket.Close();
                socket = null;
            }
        }

        #endregion


    }
}
