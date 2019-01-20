using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tumo;

namespace Servers
{
    public class TmEngineer : TmComponent
    {

        public override void OnTransferParameter(TmParameter mvc)
        {
            TenCode tenCode = mvc.TenCode;
            switch (tenCode)
            {
                case (TenCode.TmUser):
                    Console.WriteLine(TmTimerTool.CurrentTime() + " TmEngineer: " + tenCode);
               

                    break;
                case (TenCode.None):
                    break;
                default:
                    break;
            }
        }






    }
}
