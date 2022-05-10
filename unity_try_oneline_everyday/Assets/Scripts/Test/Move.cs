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
        private Vector3 originalLocalPos = Vector3.zero;

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
                // @todo.mizuno ����̑��x�����߂Ȃ��Ƃ����Ȃ��B(����/����)
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

            // X�����W�̈ړ�
            if (diffX > 0.0f)
            {
                
            }

            // Y�����W�̈ړ�
            if (diffY > 0.0f)
            {

            }

            // Z�����W�̈ړ�
            if (diffZ > 0.0f)
            {
                
            }

        }

        private void Shake(float second = 0.0f)
        {
            if (isShaking)
            {
                return;
            }

            isShaking = true;

            StartCoroutine(ShakingObject());

            // @todo.mizuno ��͎w�莞�Ԃɋ߂Â��ɘA��ĐU�������܂�悤�ɁB
        }

        private IEnumerator ShakingObject()
        {
            var localPos = this.transform.localPosition;
            originalLocalPos = localPos;

            // �����̐ݒ�B
            {
                shakingAddForceX = -0.25f;
                localPos.x += shakingAddForceX;
                this.transform.localPosition = localPos;
                shakingAddForceX = -0.25f * 2.0f;
            }

            // �����𖞂����Ă���Ԃ͗h�炷�B
            bool enable = true;
            while (enable)
            {
                shakingAddForceX *= -1.0f;
                if (shakingAddForceX >= 0.0f)
                {
                    if (shakingAddForceX <= 0.01f)
                    {
                        enable = false;
                    }

                    shakingAddForceX -= 0.01f;
                }

                localPos.x += shakingAddForceX;
                this.transform.localPosition = localPos;

                // @todo.mizuno ���̂�����̐ݒ�l���B���B(����60FPS���Z��2�t���[�����̃E�G�C�g�B)
                yield return new WaitForSeconds(0.032f);
            }

            // �����l�ɖ߂��B
            shakingAddForceX = 0.0f;
            this.transform.localPosition = originalLocalPos;

            yield return true;
        }
    }
}