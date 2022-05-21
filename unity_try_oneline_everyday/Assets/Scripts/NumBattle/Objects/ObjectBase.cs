using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

namespace NumBattle
{
    public class ObjectBase : MonoBehaviour
    {
        protected void Start()
        {

        }

        protected void Update()
        {

        }

        private void OnMouseDown()
        {
            if (EventSystem.current.IsPointerOverGameObject())
            {
                return;
            }
        }
    }
}