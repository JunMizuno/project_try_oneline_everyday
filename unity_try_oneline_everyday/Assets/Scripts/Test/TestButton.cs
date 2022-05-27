using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace Test
{
    public class TestButton : MonoBehaviour
    {
        private void Start()
        {
            var button = GetComponent<Button>();
            if (button != null)
            {
                button.onClick.AddListener(() =>
                {
                    Debug.Log("<color=cyan>" + "Clicked Button" + "</color>");
                });
            }
        }
    }
}
