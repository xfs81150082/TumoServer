using System;
using System.Collections.Generic;
using Tumo;

namespace Servers
{
    class TmBookerMysql : TmSoulerdbMysql
    {
        public override void TmAwake()
        {
            DatabaseFormName = "bookeritem";
        }
        public TmBookerMysql()
        {
            GetSoulerDBs();
        }
        private void GetSoulerDBs()
        {
            Dictionary<int, TmSoulerDB> dbdict = GetTmSoulerdbDict();
            if (dbdict.Count > 0)
            {
                TmObjects.Bookers = dbdict;
                Console.WriteLine(TmTimerTool.CurrentTime() + " TmObjects.Bookers: " + TmObjects.Bookers.Count);
            }
            else
            {
                Console.WriteLine(TmTimerTool.CurrentTime() + " 没有角色");
            }
        }

        //public override void OnTransferParameter(object sender, TmParameter parameter)
        //   {
        //       ElevenCode elevenCode = parameter.ElevenCode;
        //       switch (elevenCode)
        //       {
        //           case (ElevenCode.GetRolers):
        //               Console.WriteLine(TmTimerTool.CurrentTime() + " TmBookerMysql: " + elevenCode);
        //               //GetRolersByUersId(sender, parameter);
        //               break;
        //           case (ElevenCode.None):
        //               break;
        //           default:
        //               break;
        //       }
        //   }  
     

    }
}