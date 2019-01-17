using Tumo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Servers.Games
{
    public abstract class GameBase : TmTransfer
    {
        public GameBase()
        {
            TumoGame.Instance.Games.Add(Code, this);
            Console.WriteLine("Game:" + this.GetType().Name + "  is register.");
        }

    }
}
