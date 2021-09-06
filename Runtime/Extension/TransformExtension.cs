using UnityEngine;

namespace SleepyApe
{
    public static class TransformExtension
    {
        public static void Reset(this Transform target)
        {
            ResetPosition(target);
            target.rotation = Quaternion.Euler(0f, 0f, 0f);
            target.localRotation = Quaternion.Euler(0f, 0f, 0f);
        }

        public static void ResetPosition(this Transform target)
        {
            target.position = Vector3.zero;
        }
    }
}