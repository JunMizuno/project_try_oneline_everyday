using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Test
{
    public class AddForceTest : MonoBehaviour
    {
        private void Start()
        {

        }

        private void Update()
        {
            var rb = this.GetComponent<Rigidbody2D>();
            if (rb != null)
            {
                rb.AddForce(new Vector2(0.75f, 0.0f));
            }
        }
    }
}
