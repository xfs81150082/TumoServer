using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;
namespace Tumo
{
    public class UnityTest : MonoBehaviour
    {
        public Vector3 start = Vector3.zero;
        public float time = 0.0f;
        public float restime = 4.0f;
        public virtual void Awake()
        {
            Debug.Log(TmTimerTool.CurrentTime() + " Awake: " + time );

        }
        public virtual void Start()
        {
            Debug.Log(TmTimerTool.CurrentTime() + " Start: " + time);

        }
        public virtual void Update()
        {
            Debug.Log(TmTimerTool.CurrentTime() + " Update: " + " time: " + time + " start: " + start);
        }


    }
}
