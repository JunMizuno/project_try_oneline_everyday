using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Utility
{
    public class UtilityFunc
    {
        public static float GetRotationZAngle(Vector3 basePosition, Vector3 targetPosition)
        {
            float finalAngle = 0.0f;

            Vector3 diff = targetPosition - basePosition;

            float angle = Mathf.Atan2(diff.y, diff.x) * Mathf.Rad2Deg;
            finalAngle = angle - 90.0f;

            return finalAngle;
        }
    }
}
