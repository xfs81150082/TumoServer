using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tumo;

namespace Servers
{
    public class TmDelegate : TmComponent
    {
        private static TmDelegate _instance;
        public static TmDelegate Instance { get => _instance; }
        public override void TmAwake()
        {
            base.TmAwake();
            _instance = this;
        }
        public delegate void TmLoginParameterEvent(TmParameter parameter);
        public delegate void TmEngineerParameterEvent(TmParameter parameter);
        public delegate void TmBookerParameterEvent(TmParameter parameter);
        public delegate void TmTeacherParameterEvent(TmParameter parameter);
        public delegate void TmInventoryParameterEvent(TmParameter parameter);
        public delegate void TmSkillParameterEvent(TmParameter parameter);
        public delegate void TmTaskParameterEvent(TmParameter parameter);
        public delegate void TmWarParameterEvent(TmParameter parameter);
        public delegate void TmSenceParameterEvent(TmParameter parameter);
    }
}
