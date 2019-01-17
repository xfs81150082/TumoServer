using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Tumo
{
    [Serializable]
    public class TmInventory : TmEntity
    {
        public override void TmAwake()
        {
            base.TmAwake();
            AddComponent(new TmName());
            AddComponent(new TmLabel());
            AddComponent(new TmAttribute());
            AddComponent(new TmFixedType());
        }      
    }
}
