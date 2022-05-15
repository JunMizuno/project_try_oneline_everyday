using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace NumBattle
{
    public class ObjectBase : MonoBehaviour
    {
        protected void Start()
        {
            Debug.Log("<color=cyan>" + "ObjectBase  Start" + "</color>");
        }

        protected void Update()
        {
            Debug.Log("<color=cyan>" + "ObjectBase  Update" + "</color>");
        }
    }
}