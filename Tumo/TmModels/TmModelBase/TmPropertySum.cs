using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
namespace Tumo
{
    public class TmPropertySum : TmComponent
    {
        private ArrayList properties = new ArrayList();
        public TmProperty Property = new TmProperty();
        public int Count
        {
            get { return this.properties.Count; }
        }
        public bool Contains(object obj)
        {
            return this.properties.Contains(obj);
        }
        public void Add(object obj)
        {
            this.properties.Add(obj);
            this.UpdateProperty();
        }
        public void Remove(object obj)
        {
            this.properties.Remove(obj);
            this.UpdateProperty();
        }
        public void Clear()
        {
            this.properties.Clear();
            UpdateProperty();
        }
        private void UpdateProperty()
        {
            Property.Zero();
            if (properties.Count == 0) return;
            foreach (TmEntity tem in properties)
            {
                if (tem != null && tem.GetComponent<TmProperty>() != null)
                {
                    Property.Add(tem.GetComponent<TmProperty>());
                }
            }
            //Property.Init();
        }
    }
}