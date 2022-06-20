using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

using Utility;

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

            float finalAngle = UtilityFunc.GetRotationZAngle(mousePosition, selfScreenPoint);

            return finalAngle;
        }
    }
}
