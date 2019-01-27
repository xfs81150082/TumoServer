﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Tumo
{
    public class TmAttack : TmComponent
    {
        void TakeDamager(TmProperty myself, TmProperty attacker)
        {
            if (myself.Hp <= 0)
            {
                Died();
            }
            myself.Hp -= attacker.Hp;
            if (myself.Hp <= 0)
            {
                Died();
            }
        }

        private void Died()
        {

        }
    }
}
