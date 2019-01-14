using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Tumo
{
    public class TmIdGenerater
    {
        static int idCount = 2600;
        public static string GetId()
        {
            string tmId = "";
            idCount++;
            if (idCount > 8115)
            {
                idCount = 2600;
            }
            tmId = TmTimer.IdCurrentTime() + idCount;
            return tmId;
        }
    }
}
