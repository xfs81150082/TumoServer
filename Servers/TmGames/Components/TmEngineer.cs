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
            ElevenCode elevenCode = mvc.ElevenCode;
            switch (elevenCode)
            {
                case (ElevenCode.EngineerLogin):
                    Console.WriteLine(TmTimerTool.CurrentTime() + " TmEngineer: " + elevenCode);
               

                    break;
                case (ElevenCode.None):
                    break;
                default:
                    break;
            }
        }






    }
}
