using UnityEngine;

namespace SleepyApe
{
    public static class TransformExtension
    {
        public static void Reset(this Transform target)
        {
            ResetPosition(target);
            ResetRotation(target);
        }

        public static void ResetPosition(this Transform target)
        {
            target.position = Vector3.zero;
        }

        public static void ResetRotation(this Transform target)
        {
            target.rotation = Quaternion.Euler(0f, 0f, 0f);
        }
    }
}