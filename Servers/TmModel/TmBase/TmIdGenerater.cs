using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Servers.TmModel
{
    public static class TmIdGenerater
    {
        public static long AppId { private get; set; }

        private static ushort value;

        public static long GenerateId()
        {
            long time = TmTimeHelper.ClientNowSeconds();

            return (AppId << 48) + (time << 16) + ++value;
        }

        public static int GetAppIdFromId(long id)
        {
            return (int)(id >> 48);
        }

    }
}
