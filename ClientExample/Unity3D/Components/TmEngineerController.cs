using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ClientExample;
using Tumo;
using Tumo.Models;

namespace ClientExample
{
    class TmEngineerController : TmComponent
    {

        public override void OnTransferParameter(TmParameter mvc)
        {
            ElevenCode elevenCode = mvc.ElevenCode;
            switch (elevenCode)
            {
                case (ElevenCode.Login):
                    Console.WriteLine(TmTimerTool.CurrentTime() + " EngineerLogin: " + elevenCode);

                    break;         
                default:
                    break;
            }
        }

      

    }
}
