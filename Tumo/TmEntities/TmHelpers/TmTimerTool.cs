﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Tumo
{
    public static class TmTimerTool
    {
        ///获得服务器当前时间
        public static string GetCurrentTime()
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