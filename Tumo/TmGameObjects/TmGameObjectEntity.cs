using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;
namespace Tumo
{
    public class TmGameObjectEntity : MonoBehaviour
    {
        private void Awake()
        {
            if (TmObjects.GameObjects != null)
            {
                TmObjects.GameObjects.Add(this.gameObject);
            }
            else
            {
                Debug.Log("TmObjects.GameObjects is null.");
            }
        }     
        private void OnDestroy()
        {
            if (TmObjects.GameObjects.Contains(this.gameObject))
            {
                TmObjects.GameObjects.Remove(this.gameObject);
            }
        }
        public void Remove()
        {
            if (TmObjects.GameObjects.Contains(this.gameObject))
            {
                TmObjects.GameObjects.Remove(this.gameObject);
            }
        }
    }
}