using Clients;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Timers;
using Tumo;

namespace TumoTest.RoleLogin
{
    class Test
    {
        private bool IsLogin = false; 

        public Test()
        {
            SecondTimer();
        }

        void SecondTimer()
        {
            Timer aTimer = new Timer();                                   //实例化Timer类，在括号里设置间隔时间,单位为毫秒；
            aTimer.Elapsed += new ElapsedEventHandler(SecondTimeEvent);   //到达时间的时候执行事件；
            aTimer.Interval = 14000;                                       //间隔时间为4000毫秒；
            aTimer.Enabled = true;                                        //是否执行事件System.Timers.Timer.Elapsed；
            aTimer.AutoReset = true;                                      //设置是否循环执行，是执行一次（false）还是一直执行(true)；
        }

        // 当时间发生的时候需要进行的逻辑处理等    // 在这里仅仅是一种方式，可以实现这样的方式很多    
        void SecondTimeEvent(object source, ElapsedEventArgs ela)
        {
            if (IsLogin == false) 
            {
                IsLogin = true;
                Console.WriteLine("IsLogin:" + IsLogin.ToString());
                EngineerLogin(ela);
            }
        }

        void EngineerLogin(ElapsedEventArgs ela)
        {
            int Id = 100001;
            MvcParameter mvc = MvcTool.ToParameter(EightCode.Login, NineCode.Controller, TenCode.Engineer, ElevenCode.EngineerLogin);
            mvc.RolerId = Id.ToString();
            TumoConnect.Instance.OnTransferParameter(mvc);
            Console.WriteLine(TmClientHelper.Instance.GetCurrentTime() + " 秒针： " + ela.SignalTime.Second + " Id:" + mvc.RolerId);
        }

        
    }
}
