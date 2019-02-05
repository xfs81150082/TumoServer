using System;
using System.Collections.Generic;
using System.Threading;
using Tumo;
namespace ClientExample
{
    class TmUserController : TmComponent
    {
        public override void OnTransferParameter(object obj, TmParameter parameter)
        {
            ElevenCode elevenCode = parameter.ElevenCode;
            switch (elevenCode)
            {
                case (ElevenCode.Register):
                    Console.WriteLine(TmTimerTool.CurrentTime() + " TmUserController: " + elevenCode);                    

                    break;
                default:
                    break;
            }
        }
       
    }
}