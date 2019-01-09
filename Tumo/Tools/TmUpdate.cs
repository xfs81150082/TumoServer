using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Timers;

namespace Tumo
{
    public interface TmUpdate 
    {      
        /// <summary>
        /// 时钟是为后的TmUpdate服务
        /// </summary>
        /// <param name="time"></param>
        void TumoTimer(int time);
        ////{
        ////    TmTimer = new Timer();                                         //实例化Timer类，在括号里设置间隔时间,单位为毫秒；
        ////    TmTimer.Elapsed += new ElapsedEventHandler(TmUpdate);          //到达时间的时候执行事件；
        ////    TmTimer.Interval = ValTime;                                    //事件执行间隔时间1000毫秒；
        ////    TmTimer.Enabled = true;                                        //是否执行事件System.Timers.Timer.Elapsed；
        ////    TmTimer.AutoReset = true;                                      //设置是否循环执行，是执行一次（false）还是一直执行(true)；
        ////}
                    
        /// 每隔time一段时间运行一次方法 
        void TmUpdate(object source, ElapsedEventArgs time);
        ////{
        ////   while (RecvParameters.Count > 0)
        ////   {
        ////   }
        ////}

        
    }
}
