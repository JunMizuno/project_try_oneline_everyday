using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Test
{
    public class Move : MonoBehaviour
    {
        bool isMoving = default;
        float movingPassedTime = default; 

        private float movingDegreeX = default;
        private float movingDegreeY = default;
        private float movingDegreeZ = default;

        private float movingAddForceX = default;
        private float movingAddForceY = default;
        private float movingAddForceZ = default;

        bool isShaking = default;
        float shakingPassedTime = default;

        private float shakingAddForceX = default;
        private float shakingAddForceY = default;
        private float shakingAddForceZ = default;

        private void Start()
        {

        }

        private void Update()
        {
            Floating(new Vector3(0.0f, 0.5f, 0.0f), 2.0f);
            Shake();
        }

        private void Floating(Vector3 targetPosition, float second = 0.0f)
        {
            var trans = this.transform;
            var target = targetPosition;

            /*
            var y = trans.localPosition.y;

            if (degree < 90.0f)
            {
                // @todo.mizuno これの速度を求めないといけない。(距離/時間)
                degree += 0.25f;
                addForce = Mathf.Cos(degree * Mathf.Deg2Rad) * 0.05f;
                y += addForce;
            }
            else
            {
                degree = 0.0f;
                addForce = 0.0f;
                y = 0.0f;
            }

            this.transform.localPosition = new Vector3(trans.localPosition.x, y, trans.localPosition.z);
            */

            var diffX = Mathf.Abs(trans.localPosition.x - target.x);
            var diffY = Mathf.Abs(trans.localPosition.y - target.y);
            var diffZ = Mathf.Abs(trans.localPosition.z - target.z);

            //Debug.Log("<color=cyan>" + "  DiffX:" + diffX + "  DiffY:" + diffY + "  DiffZ:" + diffZ + "</color>");

            // X軸座標の移動
            if (diffX > 0.0f)
            {
                
            }

            // Y軸座標の移動
            if (diffY > 0.0f)
            {

            }

            // Z軸座標の移動
            if (diffZ > 0.0f)
            {
                
            }

        }

        private void Shake(float second = 0.0f)
        {
            var localPos = this.transform.localPosition;

            // 初回のみ
            if (!isShaking)
            {
                shakingAddForceX = -0.25f;
                localPos.x += shakingAddForceX;
                this.transform.localPosition = localPos;

                isShaking = true;
                shakingAddForceX = -0.25f * 2.0f;

                return;
            }

            shakingAddForceX *= -1.0f;
            localPos.x += shakingAddForceX;
            this.transform.localPosition = localPos;

            // @todo.mizuno 後は指定時間に近づくに連れて振動が収まるように。
        }
    }
}