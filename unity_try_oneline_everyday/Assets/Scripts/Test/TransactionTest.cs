using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Test
{
    public class TransactionTest : MonoBehaviour
    {
        private bool isActionShrink = default;
        private bool isActionExpansion = default;

        private void Start()
        {

        }

        private void Update()
        {

        }

        private void OnMouseDown()
        {

        }

        private IEnumerator ShrinkScaleTransaction()
        {
            float minScaleValue = 0.5f;
            float maxScaleValue = 1.0f;



            yield return true;
        }

        private IEnumerator ExpansionkScaleTransaction()
        {
            float minScaleValue = 1.0f;
            float maxScaleValue = 1.5f;



            yield return true;
        }
    }
}
