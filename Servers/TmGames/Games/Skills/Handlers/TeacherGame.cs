using Tumo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Servers.Games.Handlers
{
    class TeacherGame : GameHandlerBase
    {
        public override string Code => TenCode.Teacher.ToString();
        public override void OnTransferParameter(TmRequest mvc)
        {
            ElevenCode ElevenCode = mvc.ElevenCode;
            switch (ElevenCode)
            {     
                case (ElevenCode.Test):
                    break;
                default:
                    break;
            }


        }


    }
}
