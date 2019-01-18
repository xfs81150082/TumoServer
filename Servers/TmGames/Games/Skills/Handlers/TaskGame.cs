using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tumo;

namespace Servers.Games.Handlers
{
    class TaskGame : GameHandlerBase
    {
        public override string Code => TenCode.Task.ToString();

        public override void OnTransferParameter(TmRequest mvc)
        {
            throw new NotImplementedException();
        }
    }
}
