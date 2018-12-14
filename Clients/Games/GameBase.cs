using Tumo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Clients.Games
{
    public abstract class GameBase : MvcBase
    {
        public GameBase()
        {
            TumoGmae.Instance.Games.Add(Code, this);
            Console.WriteLine("Games: " + this.GetType().Name + " is register.");
        }
    }
}
