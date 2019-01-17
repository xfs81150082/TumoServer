﻿using Tumo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ClientExample.Games.Controllers
{
    public abstract class GameControllerBase : TmTransfer
    {
        public GameControllerBase()
        {
            TumoGameController.Instance.Controllers.Add(Code, this);
            Console.WriteLine("Games: " + this.GetType().Name + " is register.");
        }

    }
}
