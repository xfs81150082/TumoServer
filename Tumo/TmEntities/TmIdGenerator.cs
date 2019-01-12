using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Tumo
{
    public class TmIdGenerator
    {
        static int idCount = 0;
        public static string GetId()
        {
            string tmId = "";
            idCount++;
            if (idCount > 9999)
            {
                idCount = 0;
            }
            tmId = TmTimer.IdCurrentTime() + idCount;
            return tmId;
        }
    }
}
