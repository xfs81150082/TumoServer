using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Tumo
{
    public class TmIdGenerater
    {
        static int idCount = 1000;
        public static string GetId()
        {
            string tmId = "";
            idCount++;
            if (idCount > 5200)
            {
                idCount = 1000;
            }
            tmId = TmTimerTool.CurrentTime() + idCount;
            return tmId;
        }
    }
}
