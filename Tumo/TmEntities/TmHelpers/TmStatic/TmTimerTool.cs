using System;
namespace Tumo
{
    public static class TmTimerTool
    {
        ///获得服务器当前时间
        public static string CurrentMoveTime()
        {
            string cuurentTime = "";
            cuurentTime = DateTime.Now.ToString("yyyyMMddHHmmss.ffff");
            return cuurentTime;
        }
        ///获得服务器当前时间
        public static string CurrentTime()
        {
            string cuurentTime = "";
            cuurentTime = DateTime.Now.ToString("yyyyMMddHHmmss");
            return cuurentTime;
        }
    }
}
