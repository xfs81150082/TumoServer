﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Tumo
{
    public class TmNetServerSystem : TmSystem
    {
        public override void TmAwake()
        {
            base.TmAwake();
            AddComponent(new TmServer());
            AddComponent(new TmSocket());
            AddComponent(new TmTcp());
            AddComponent(new TmRecvQueue());
            AddComponent(new TmSendQueue());
        }

        public override void TmUpdate()
        {
            foreach(var ent in GetTmEntities())
            {

            }

        }

        //#region Methods Callbacks ///启动服务 ///接收参数消息     
        //public void StartListen()
        //{
        //    if (!IsRunning)
        //    {
        //        netSocket.Bind(new IPEndPoint(this.address, this.Port));
        //        netSocket.Listen(MaxListenCount);
        //        netSocket.BeginAccept(new AsyncCallback(this.AcceptCallback), netSocket);
        //        Console.WriteLine("{0} 服务启动，监听{1}成功", TmTimerTool.CurrentTime(), netSocket.LocalEndPoint);
        //        IsRunning = true;
        //    }
        //}
        //private void AcceptCallback(IAsyncResult ar)
        //{
        //    if (IsRunning)
        //    {
        //        Socket server = (Socket)ar.AsyncState;
        //        Socket peerSocket = server.EndAccept(ar);
        //        ///触发事件///创建一个方法接收peerSocket (在方法里创建一个peer来处理读取数据//开始接受来自该客户端的数据)
        //        TmReceiveSocket(peerSocket);
        //        ///接受下一个请求  
        //        server.BeginAccept(new AsyncCallback(this.AcceptCallback), server);
        //    }
        //}
        //private void TmReceiveSocket(Socket socket)
        //{
        //    ///限制监听数量
        //    if (TPeers.Count >= MaxListenCount)
        //    {
        //        ///触发事件///在线排队等待
        //        WaitingSockets.Enqueue(socket);
        //    }
        //    else
        //    {
        //        ///创建一个TPeer接收socket
        //        new TmPeer().BeginReceiveMessage(socket);

        //        //RecvThread = new Thread(new ParameterizedThreadStart(new TPeer().BeginReceiveMessage));
        //        //RecvThread.Start(socket);
        //        //Console.WriteLine(TmTimerTool.CurrentTime() + " AsyncRecv ThreadId:{0}", Thread.CurrentThread.ManagedThreadId);
        //    }
        //}
        //#endregion

        //#region ///发送参数信息       
        //public override void OnSendMvcParameters()
        //{
        //    try
        //    {
        //        while (SendParameters.Count > 0)
        //        {
        //            TmParameter mvc = SendParameters.Dequeue();
        //            ///用Json将参数（MvcParameter）,序列化转换成字符串（string）
        //            string mvcJsons = TmJson.ToString<TmParameter>(mvc);
        //            TmTcpSession tpeer = TmParameterTool.OutOfDictionary(mvc.EcsId, TPeers);
        //            //TPeers.TryGetValue(mvc.EcsId, out tpeer);
        //            if (tpeer != null)
        //            {
        //                tpeer.SendString(mvcJsons);
        //            }
        //            else
        //            {
        //                Console.WriteLine(TmTimerTool.CurrentTime() + " 没找TPeer，用Key: " + mvc.EcsId);
        //                break;
        //            }
        //        }
        //    }
        //    catch (Exception ex)
        //    {
        //        Console.WriteLine(TmTimerTool.CurrentTime() + " SendMvcParameters: " + ex.Message);
        //    }
        //}
        //#endregion


    }
}