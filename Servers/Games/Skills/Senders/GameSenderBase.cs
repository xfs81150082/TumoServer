using Tumo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Servers.Games.Senders.Games
{
    public abstract class GameSenderBase : MvcBase
    {
        public GameSenderBase()
        {
            TumoGameSender.Instance.GameSenders.Add(Code, this);
            Console.WriteLine("GameSenders: " + this.GetType().Name + " is register.");
        }

    }
}
