using Tumo;
using Servers.Chats;
using Servers.Games;
using Servers.Logins;
using Servers.Sences.Nodes;
using Servers.Sences.Rolers;
using Servers.Wars;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Servers
{
    public class TmGate : TmEntity
    {
        private static TmGate _instance;
        public static TmGate Instance { get => _instance; }  
        public override void TmAwake()
        {
            base.TmAwake();
            _instance = this;
            AddComponent(new TmLogin());
            AddComponent(new TmEngineer());
            TmLog.WriteLine(TmTimerTool.CurrentTime() + " " + this.GetType().Name + " 组件加载完成。 ");
        }

        //public event TmDelegate.TmLoginParameterEvent OnTmLoginParameterEvent;
        public event TmDelegate.TmEngineerParameterEvent OnTmEngineerParameterEvent;
        public event TmDelegate.TmBookerParameterEvent OnTmBookerParameterEvent;
        public event TmDelegate.TmTeacherParameterEvent OnTmTeacherParameterEvent;
        public event TmDelegate.TmInventoryParameterEvent OnTmInventoryParameterEvent;
        public event TmDelegate.TmSkillParameterEvent OnTmSkillParameterEvent;
        public event TmDelegate.TmTaskParameterEvent OnTmTaskParameterEvent;
        public event TmDelegate.TmWarParameterEvent OnTmWarParameterEvent;
        public event TmDelegate.TmSenceParameterEvent OnTmSenceParameterEvent;      

        //这个方法用来处理TPeer参数Mvc，并让结果给客户端响应（当客户端发起请求时调用）
        public override void OnTransferParameter(TmParameter parameter)
        {          
            NineCode nineCode = parameter.NineCode;
            switch (nineCode)
            {
                case (NineCode.TmLogin):
                    Console.WriteLine(TmTimerTool.CurrentTime() + " TmGate: " + nineCode);
                    this.GetComponent<TmLogin>().OnTransferParameter(parameter);
                    break;
                case (NineCode.TmEngineer):
                    Console.WriteLine(TmTimerTool.CurrentTime() + " TmGate: " + nineCode);
                    OnTmEngineerParameterEvent(parameter);
                    break;
                case (NineCode.TmBooker):
                    Console.WriteLine(TmTimerTool.CurrentTime() + " TmGate: " + nineCode);
                    OnTmBookerParameterEvent(parameter);
                    break;
                case (NineCode.TmTeacher):
                    Console.WriteLine(TmTimerTool.CurrentTime() + " TmGate: " + nineCode);
                    OnTmTeacherParameterEvent(parameter);
                    break;
                case (NineCode.TmInventory):
                    Console.WriteLine(TmTimerTool.CurrentTime() + " TmGate: " + nineCode);
                    OnTmInventoryParameterEvent(parameter);
                    break;
                case (NineCode.TmSkill):
                    Console.WriteLine(TmTimerTool.CurrentTime() + " TmGate: " + nineCode);
                    OnTmSkillParameterEvent(parameter);
                    break;
                case (NineCode.TmTask):
                    Console.WriteLine(TmTimerTool.CurrentTime() + " TmGate: " + nineCode);
                    OnTmTaskParameterEvent(parameter);
                    break;
                case (NineCode.TmWar):
                    Console.WriteLine(TmTimerTool.CurrentTime() + " TmGate: " + nineCode);
                    OnTmWarParameterEvent(parameter);
                    break;
                case (NineCode.TmSence):
                    Console.WriteLine(TmTimerTool.CurrentTime() + " TmGate: " + nineCode);
                    OnTmSenceParameterEvent(parameter);
                    break;
                case (NineCode.None):
                    break;
                default:
                    break;
            }

        }
        
    }
}
