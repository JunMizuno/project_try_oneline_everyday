using System.Collections;
using UnityEngine;

namespace Test
{
    /// <summary>
    /// オブジェクトに直接アタッチする想定。
    /// </summary>
    public class ShakeObject : MonoBehaviour
    {
        public void Shake(float duration, float magnitude)
        {
            StartCoroutine(ExecuteShake(duration, magnitude));
        }

        private IEnumerator ExecuteShake(float duration, float magnitude)
        {
            var pos = this.transform.localPosition;

            float elapsed = 0.0f;

            while (elapsed < duration)
            {
                var x = pos.x + Random.Range(-1.0f, 1.0f) * magnitude;
                var y = pos.y + Random.Range(-1.0f, 1.0f) * magnitude;

                this.transform.localPosition = new Vector3(x, y, pos.z);

                elapsed += Time.deltaTime;

                yield return null;
            }

            this.transform.localPosition = pos;
        }
    }
}
