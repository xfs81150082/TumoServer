using System;
using System.Collections.Generic;
namespace Tumo
{
    public class TmGameObject : TmEntity
    {
        public TmGameObject() { }
        public TmGameObject(TmComponent component)
        {
            this.AddComponent(component);
        }
        public TmGameObject(TmComponent component1, TmComponent component2)
        {
            this.AddComponent(component1);
            this.AddComponent(component2);
        }
    }
}