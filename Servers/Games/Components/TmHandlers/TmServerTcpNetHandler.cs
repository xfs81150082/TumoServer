using System;
using System.Collections.Generic;
using Tumo;
namespace Servers
{
    class TmServerTcpNetHandler : TmEntity
    {
        public override void TmAwake()
        {
            base.TmAwake();
            AddComponent(new TmTcpServer());
        }
    }
}
