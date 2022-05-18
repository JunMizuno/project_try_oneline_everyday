using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Test
{
    public class BlurObject : MonoBehaviour
    {
        private static readonly int PROPERTY_TRAIL_DIR = Shader.PropertyToID("_TrailDir");

        [SerializeField]
        private Renderer renderer;

        [SerializeField]
        private float trailRate = 10.0f;

        private Material material;

        private Vector3 trailPos;

        private void Awake()
        {
            material = renderer.material;
            trailPos = this.transform.position;
        }

        private void Update()
        {
            if (Input.GetMouseButtonDown(0))
            {
                var pos = Input.mousePosition;
                pos.z = 10.0f;
                var screenToWorldPointPosition = Camera.main.ScreenToWorldPoint(pos);
                this.transform.position = screenToWorldPointPosition;
            }

            trailPos = Vector3.Lerp(trailPos, this.transform.position, Mathf.Clamp01(Time.deltaTime * trailRate));
            Vector3 dir = transform.InverseTransformDirection(trailPos - transform.position);
            material.SetVector(PROPERTY_TRAIL_DIR, dir);
        }

        private void OnDrawGizmosSelected()
        {
            Gizmos.color = Color.cyan;
            Gizmos.DrawSphere(trailPos, 0.2f);
        }
    }
}