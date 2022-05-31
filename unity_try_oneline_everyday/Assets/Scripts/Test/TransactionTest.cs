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
            StartCoroutine(ShrinkScaleTransaction());
        }

        private IEnumerator ShrinkScaleTransaction()
        {
            if (isActionShrink)
            {
                yield break;
            }

            isActionShrink = true;

            float minScaleValue = 0.5f;
            float maxScaleValue = 1.0f;

            var scale = this.gameObject.transform.localScale;

            // @todo.mizuno スピード感は要調整。
            while (scale.x > minScaleValue)
            {
                scale.x -= 0.01f;
                scale.y -= 0.01f;
                scale.z -= 0.01f;
                this.gameObject.transform.localScale = scale;

                yield return new WaitForSeconds((1.0f / 60.0f));
            }

            while (scale.x < maxScaleValue)
            {
                scale.x += 0.01f;
                scale.y += 0.01f;
                scale.z += 0.01f;
                this.gameObject.transform.localScale = scale;

                yield return new WaitForSeconds((1.0f / 60.0f));
            }

            this.gameObject.transform.localScale = new Vector3(maxScaleValue, maxScaleValue, maxScaleValue);

            isActionShrink = false;

            yield return true;
        }

        private IEnumerator ExpansionScaleTransaction()
        {
            if (isActionExpansion)
            {
                yield break;
            }

            isActionExpansion = true;

            float minScaleValue = 1.0f;
            float maxScaleValue = 1.5f;

            var scale = this.gameObject.transform.localScale;

            while (scale.x < maxScaleValue)
            {
                scale.x += 0.01f;
                scale.y += 0.01f;
                scale.z += 0.01f;
                this.gameObject.transform.localScale = scale;

                yield return new WaitForSeconds((1.0f / 60.0f));
            }

            while (scale.x > minScaleValue)
            {
                scale.x -= 0.01f;
                scale.y -= 0.01f;
                scale.z -= 0.01f;
                this.gameObject.transform.localScale = scale;

                yield return new WaitForSeconds((1.0f / 60.0f));
            }

            this.gameObject.transform.localScale = new Vector3(maxScaleValue, maxScaleValue, maxScaleValue);

            isActionExpansion = false;

            yield return true;
        }
    }
}
