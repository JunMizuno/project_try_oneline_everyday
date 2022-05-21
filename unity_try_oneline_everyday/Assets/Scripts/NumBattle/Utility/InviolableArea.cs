using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace NumBattle
{
    public class InviolableArea : MonoBehaviour
    {
        public void Awake()
        {
            var rectTrans = this.GetComponent<RectTransform>();
            if (rectTrans == null)
            {
                return;
            }

            var sizeDelta = rectTrans.sizeDelta;
            sizeDelta.x = Screen.currentResolution.width;
            sizeDelta.y = Screen.currentResolution.height;

            this.GetComponent<RectTransform>().sizeDelta = sizeDelta;
        }

        public void Start()
        {

        }

        public void Update()
        {

        }

        public void OnClickMethod()
        {
            Debug.Log("<color=red>" + "不可侵領域をタッチ" + "</color>");
        }
    }
}