using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tumo;
namespace Servers
{
    class TmMapHandler : TmEntity
    {
        public override void OnTransferParameter(object obj, TmParameter parameter)
        {
            ElevenCode elevenCode = parameter.ElevenCode;
            switch (elevenCode)
            {
                case (ElevenCode.Get):
                    Console.WriteLine(TmTimerTool.CurrentTime() + " TmEngineerHandler: " + elevenCode);

                    break;
                case (ElevenCode.GetRolers):
                    Console.WriteLine(TmTimerTool.CurrentTime() + " TmEngineerHandler: " + elevenCode);

                    break;
                case (ElevenCode.EngineerLogin):
                    Console.WriteLine(TmTimerTool.CurrentTime() + " TmEngineerHandler: " + elevenCode);


                    break;
                //case (ElevenCode.StatusSync):
                //    Console.WriteLine(TmTimerTool.CurrentTime() + " TmStatusSyncHandler: " + elevenCode);
                //    Parent.GetComponent<TmStatusSyncHandler>().OnTransferParameter(this, parameter);
                //    break;
                case (ElevenCode.None):
                    break;
                default:
                    break;
            }
        }
        internal Dictionary<int, TmSouler> Soulers { get; set; }                  //在线角色字典,ByRolerId
        internal Dictionary<int, TmSoulerDB> Engineers { get; set; } = new Dictionary<int, TmSoulerDB>();                      //在线角色字典,ByRolerId
        internal Dictionary<int, List<TmSoulerDB>> EngineerDbs { get; set; } = new Dictionary<int, List<TmSoulerDB>>();        //角色列表字典,ByUersId
        private void GetSoulers(TmParameter parameter)
        {
            if (Soulers == null)
            {
                TmMysqlHandler.Instance.GetComponent<TmEngineerMysql>().OnTransferParameter(this, parameter);
                Console.WriteLine(TmTimerTool.CurrentTime() + " this.Soulers:" + this.Soulers.Count);
            }
            TmParameter response = TmParameterTool.ToJsonParameter<Dictionary<int, TmSouler>>(TenCode.Engineer, ElevenCode.Get, ElevenCode.Get.ToString(), Soulers);
            response.EcsId = parameter.EcsId;
            TmTcpSocket.Instance.Send(response);
        }
        private void GetRolersByUersId(TmParameter parameter)
        {
            List<TmSoulerDB> Engineers = null;
            int userId = TmParameterTool.GetValue<int>(parameter, ElevenCode.UserLogin.ToString());
            bool yes = false;
            int count = 0;
            while (!yes)
            {
                if (EngineerDbs.Count > 0)
                {
                    yes = EngineerDbs.TryGetValue(userId, out Engineers);
                }
                if (yes)
                {
                    TmParameter response = TmParameterTool.ToJsonParameter<List<TmSoulerDB>>(TenCode.Engineer, ElevenCode.GetRolers, ElevenCode.GetRolers.ToString(), Engineers);
                    response.EcsId = parameter.EcsId;
                    TmTcpSocket.Instance.Send(response);
                    break;
                }
                else
                {
                    TmMysqlHandler.Instance.GetComponent<TmEngineerMysql>().OnTransferParameter(this, parameter);
                    Console.WriteLine(TmTimerTool.CurrentTime() + " this.EngineerDbs:" + EngineerDbs.Count);
                    count += 1;
                }
                if (count > 3)
                {
                    yes = true;
                }
            }
        }




    }
}
