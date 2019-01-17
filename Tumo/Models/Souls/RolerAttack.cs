using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Tumo.Models
{
    public class RolerAttack
    {
        void TakeDamager(Roler myself, Roler attacker)
        {
            if (myself.SoulItem.Hp <= 0)
            {
                Died();
            }
            myself.SoulItem.Hp -= attacker.SoulItem.Hp;
            if (myself.SoulItem.Hp <= 0)
            {
                Died();
            }
        }

        private void Died()
        {
            throw new NotImplementedException();
        }
    }
}
