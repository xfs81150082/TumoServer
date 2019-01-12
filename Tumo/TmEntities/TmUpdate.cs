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
        /// 时钟是为后面TmUpdate服务
        /// </summary>
        /// <param name="time"></param>
        void TumoTimer(int time);

        /// <summary>
        /// 每隔time一段时间运行一次方法 //到达时间的时候执行事件；
        /// </summary>
        /// <param name="source"></param>
        /// <param name="time"></param>
        void TmUpdate(object source, ElapsedEventArgs time);    

        
    }
}
