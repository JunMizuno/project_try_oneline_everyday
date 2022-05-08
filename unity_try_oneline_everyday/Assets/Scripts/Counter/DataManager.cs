using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Counter
{
    public class DataManager : MonoBehaviour
    {
        private void Start()
        {

        }

        private void Update()
        {

        }

        public void SaveCount(short index)
        {
            PlayerPrefs.SetInt("", 0);
        }

        public void SaveAllCounts()
        {

        }

        public void ClearCount(short index)
        {
            PlayerPrefs.SetInt("", 0);
        }

        public void ClearAllCounts()
        {

        }
    }
}