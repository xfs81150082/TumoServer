using System;
using System.Collections;
using UnityEngine;
namespace Tumo
{
    public class TmGameObjectSystem : MonoBehaviour
    {
        void Update()
        {
            if (TmObjects.GameObjects.Count > 0)
            {
                TmUpdate(TmObjects.GameObjects);
            }
        }
        public virtual void TmUpdate(ArrayList objects)
        {
            for (int i = 0; i < objects.Count; i++)
            {
                if (objects[i] != null)
                {
                    TmUpdate((GameObject)objects[i]);
                }
            }
        }
        public virtual void TmUpdate(GameObject go) { }
    }
}