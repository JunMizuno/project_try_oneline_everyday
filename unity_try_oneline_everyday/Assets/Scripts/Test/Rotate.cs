using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

namespace Test
{
    public class Rotate : MonoBehaviour
    {
        [SerializeField]
        private GameObject targetObject;

        float targetAngle = default;
        private readonly float rotateSpeed = 2.0f;

        private void Start()
        {

        }

        private void Update()
        {
            // ボタンなどのUIが押された場合は無視する。
            if (EventSystem.current.IsPointerOverGameObject())
            {
                return;
            }

            // 画面をクリックした位置に向きを変える。(Z軸回転。)
            if (Input.GetMouseButtonDown(0))
            {
                targetAngle = GetRotationAngleByTargetPosition(Input.mousePosition);
            }

            targetObject.transform.eulerAngles = new Vector3(0.0f, 0.0f, Mathf.LerpAngle(targetObject.transform.eulerAngles.z, targetAngle, Time.deltaTime * rotateSpeed));
        }

        private float GetRotationAngleByTargetPosition(Vector3 mousePosition)
        {
            var selfScreenPoint = Camera.main.WorldToScreenPoint(targetObject.transform.position);

            Vector3 diff = mousePosition - selfScreenPoint;

            float angle = Mathf.Atan2(diff.y, diff.x) * Mathf.Rad2Deg;
            float finalAngle = angle - 90.0f;

            Debug.Log("<color=cyan>" + "CalcAngle  angle:" + angle + "  finalAngle:" + finalAngle + "</color>");

            return finalAngle;
        }
    }
}
