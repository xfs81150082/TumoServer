using Tumo.Models;
using Tumo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading;

namespace Clients
{
    public class TClient : TmAsyncTcpSession
    {
        private static TClient _instance;
        public static TClient Instance { get => _instance; }
        #region Properties
        //客户端Socket 
        public Socket Socket { get; set; }
        public User User { get; set; }                                    //登录用户
        public Roler Player { get; set; }                              //当前角色
        private bool isClose = false;
        #endregion

        #region Constructor
        public TClient() { _instance = this; }
        #endregion
        public void SendMsg(MvcParameter mvc)
        {
            //用Json将参数（MvcParameter）,序列化转换成字符串（string）
            string mvcJsons = MvcTool.ToString<MvcParameter>(mvc);
            SendString(mvcJsons);
        }
        public override void OnTransferParameter(string mvcString, Socket socket) 
        {
            /////将字符串string,用json反序列化转换成MvcParameter参数
            MvcParameter mvc = MvcTool.ToObject<MvcParameter>(mvcString);
            TumoConnect.Instance.OnTransferParameter(mvc);
        }

        #region OnDisconnect
        //与服务器连接时调用 
        public override void OnConnect(Socket socket)
        {
            this.Socket = socket;            
            TmClientHelper.Instance.TClient = this;
            //MvcParameter mvc = MvcTool.ToParameter(EightCode.Node, NineCode.Controller, TenCode.Peer, ElevenCode.HeartBeat);
            //TumoConnect.Instance.OnTransferParameter(mvc);
        }

        //与服务器断开时调用 
        public override void OnDisconnect(Socket socket)
        {
            if (TmClientHelper.Instance.TClient != null)
            {
                TmClientHelper.Instance.TClient = null;
            }
            if (isClose == false)
            {
                socket.Shutdown(SocketShutdown.Both);
                socket.Close();
                socket = null;
            }
            MvcParameter mvc = MvcTool.ToParameter(EightCode.Node, NineCode.Controller, TenCode.Peer, ElevenCode.RemoveHeartBeat);
            TumoConnect.Instance.OnTransferParameter(mvc);
        }

        #endregion


    }
}
