using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace Tumo
{
    public static class TmLog
    {
        //private static string logpath = AppDomain.CurrentDomain.BaseDirectory + "TumoLog/log.txt";
        private static string logpath = AppDomain.CurrentDomain.BaseDirectory + "log.txt";

        public static void WriteLine(string message)
        {
            //打开文件，如果文件不存在，则创建一个文件
            string path = logpath;
            if (!File.Exists(path))
            {
                using (File.Create(path)) { }
            }

            //打开文件，如果文件大于2M，则修改文件名保存备份
            FileInfo fileinfo = new FileInfo(path);
            if (fileinfo.Length > 1024 * 1024 * 2)
            {
                File.Move(path, AppDomain.CurrentDomain.BaseDirectory + DateTime.Now.ToString("yyyyMMddHHmmss") + "log.txt");
                if (!File.Exists(path))
                {
                    using (File.Create(path)) { }
                }
            }

            //在文件上写入文本文字
            StreamWriter sw2 = File.AppendText(path);
            sw2.WriteLine(DateTime.Now.ToString("yyyyMMdd HH:mm:ss") + " " + message);
            sw2.Close();
        }
                
    }
}
