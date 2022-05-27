using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace NumBattle
{
    public class PlayNumberBase : ObjectBase
    {
        new protected void Start()
        {
            base.Start();

            Debug.Log("<color=cyan>" + "PlayNumberBase  Start" + "</color>");
        }

        new protected void Update()
        {
            base.Update();

            Debug.Log("<color=cyan>" + "PlayNumberBase  Update" + "</color>");
        }
    }
}
