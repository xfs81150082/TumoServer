﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Clients;
using Tumo;
using Tumo.Models;

namespace Clients.Logins.Controllers
{
    class EngineerLogin : LoginControllerBase
    {
        public override string Code => TenCode.Engineer.ToString();

        public override void OnTransferParameter(MvcParameter mvc)
        {
            ElevenCode elevenCode = mvc.ElevenCode;
            switch (elevenCode)
            {
                case (ElevenCode.EngineerLogin):
                    Console.WriteLine(TmClientHelper.Instance.GetCurrentTime() + " EngineerLogin: " + elevenCode);
                    mvc.NineCode = NineCode.Sender;
                    TumoLogin.Instance.OnTransferParameter(mvc);
                    break;         
                default:
                    break;
            }
        }

      

    }
}
