using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Test
{
    public class Receiver : MonoBehaviour
    {
        private void Start()
        {

        }

        private void OnReceive()
        {
            Debug.Log("<color=cyan>" + "Receiver  OnReceive" + "</color>");
        }
    }
}
