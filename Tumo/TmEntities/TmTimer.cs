using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Tumo
{
    public class TmTimer
    {
        ///获得服务器当前时间
        public static string GetCurrentTime()
        {
            string cuurentTime = "";
            cuurentTime = DateTime.Now.ToString("yyyyMMddHHmmss.ffff");
            return cuurentTime;
        }
        ///获得服务器当前时间
        public static string IdCurrentTime()
        {
            string cuurentTime = "";
            cuurentTime = DateTime.Now.ToString("yyyyMMddHHmmss");
            return cuurentTime;
        }
    }
}
