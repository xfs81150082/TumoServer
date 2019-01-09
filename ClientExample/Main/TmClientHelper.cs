using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Sockets;
using System.Text;

namespace ClientExample
{
    public class TmClientHelper
    {
        #region instance,dictionary
        private static TmClientHelper _instance;
        public static TmClientHelper Instance { get { return _instance; } }
        public TmClientHelper() { _instance = this; }
        #endregion
        
        //#region TcpClient
        /////获得服务器当前时间
        //public string GetCurrentTime()
        //{
        //    string cuurentTime = "";
        //    cuurentTime = DateTime.Now.ToString("yyyyMMddHHmmss.ffff");
        //    return cuurentTime;
        //}

        //#endregion

    }
}
