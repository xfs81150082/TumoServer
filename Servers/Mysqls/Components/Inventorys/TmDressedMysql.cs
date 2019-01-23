using System;
using System.Collections.Generic;
using Tumo;
namespace Servers
{
    class TmDressedMysql : TmInventoryMysql
    {
        public override void TmAwake()
        {
            base.TmAwake();
            DatabaseFormName = "dresseditem";
        }
        public override void OnTransferParameter(object sender, TmParameter parameter)
        {
            ElevenCode elevenCode = parameter.ElevenCode;
            switch (elevenCode)
            {
                case (ElevenCode.Login):
                    Console.WriteLine(TmTimerTool.CurrentTime() + " TmEngineerMysql: " + elevenCode);
                    GetDbsByRolerId(sender, parameter);
                    break;
                case (ElevenCode.None):
                    break;
                default:
                    break;
            }
        }
        void GetDbsByRolerId(object sender, TmParameter parameter)
        {
            Console.WriteLine(TmTimerTool.CurrentTime() + " TmKnapsackMysql,Rolerid:" + (parameter.Parameters[parameter.ElevenCode.ToString()] as TmUser).Id);
            List<TmInventoryDB> dbs = GetInventorydbsByRolerId((parameter.Parameters[parameter.ElevenCode.ToString()] as TmUser).Id);
            if (dbs.Count > 0)
            {
                (sender as TmEngineerHandler).Dresseds = dbs;
            }
            else
            {
                Console.WriteLine(TmTimerTool.CurrentTime() + " 没有角色");
            }
        }
        
    }
}