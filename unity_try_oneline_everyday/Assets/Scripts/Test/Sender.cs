using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Test
{
    public class Sender : MonoBehaviour
    {
        private void Start()
        {
            gameObject.SendMessage("OnReceive");
        }
    }
}