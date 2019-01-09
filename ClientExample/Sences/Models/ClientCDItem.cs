using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Timers;
using Tumo;
using Tumo.Models;

namespace ClientExample.Sences.Models
{
    public class ClientCDItem : CoolDownItem
    {
        public override void TmAwake()
        {
            ValTime = 4000;
        }

        public override void TmUpdate(ElapsedEventArgs time)
        {
            UpdateCDCount();
        }

        private void UpdateCDCount()
        {
            if (CdCount <= CoolDown.MaxCdCount)
            {
                Console.WriteLine(TimerTool.GetCurrentTime() + " CdCount: " + CdCount + "/" + CoolDown.MaxCdCount);
            }
            ///检查记录，每检查一次加1
            CdCount += 1;
            ///断线重连...写在下面
            if (CdCount >= CoolDown.MaxCdCount)
            {
                ///断线重连...写在下面
                Console.WriteLine(TimerTool.GetCurrentTime() + " 断线重连. 第 " + (CdCount - CoolDown.MaxCdCount) + "/4 次。");

                TmTcpClient tmTcpClient = new TmTcpClient();
                tmTcpClient.StartConnect();
            }
            ///断线重连.....重连4次后销毁
            if (CdCount >= CoolDown.MaxCdCount + 4) 
            {
                Close();
                if (TmAsyncTcpClient.Instance.TClient != null)
                {
                    ///删除掉心跳包群中对应的client
                    TmAsyncTcpClient.Instance.TClient.OnDisconnect();
                }
            }
            Console.WriteLine(TimerTool.GetCurrentTime() + " CdCount: " + CdCount + "/" + CoolDown.MaxCdCount);
        }


    }
}
