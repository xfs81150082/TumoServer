﻿using System;

namespace Tumo
{
    public static class TmIdGenerater
    {
        static int idCount = 1400;
        public static string GetId()
        {
            string tmId = "";
            idCount += 1;
            if (idCount > 4000)
            {
                idCount = 1400;
            }
            tmId = TmTimerTool.IdCurrentTime() + idCount.ToString();
            return tmId;
        }
    }
}
