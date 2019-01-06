using Tumo;
using Tumo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Servers.Games.Mysqlers
{
    public abstract class GameMysqlBase : TmBase
    {
        public GameMysqlBase()
        {
            TumoGameMysql.Instance.GameMysqls.Add(Code, this);
            Console.WriteLine("GameMysqls: " + this.GetType().Name + " is register.");
        }
    }
}
