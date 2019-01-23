using System;
using System.Collections.Generic;
using Tumo;

namespace Servers 
{
    class TmBookerMysql : TmSoulerdbMysql
    {
        public override void TmAwake()
        {
            base.TmAwake();
            DatabaseFormName = "bookeritem";
        }
        public override void OnTransferParameter(object sender, TmParameter parameter)
        {
            ElevenCode elevenCode = parameter.ElevenCode;
            switch (elevenCode)
            {
                case (ElevenCode.Login):
                    this.GetSoulerdbs(sender, parameter);
                    break;
                case (ElevenCode.None):
                    break;
                default:
                    break;
            }
        }
        private void GetSoulerdbs(object sender, TmParameter parameter)
        {
            List<TmSoulerDB> dbs = GetTmSoulerdbs();
            Console.WriteLine(TmTimerTool.CurrentTime() + " TmBookerMysql,dbs:" + dbs.Count);
            if (dbs.Count > 0)
            {
                (sender as TmEngineerHandler).Bookers = dbs;
            }
            else
            {
                Console.WriteLine(TmTimerTool.CurrentTime() + " 没有角色");
            }
        }
    }
}