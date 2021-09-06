using UnityEngine;

namespace SleepyApe
{
    public static class TransformExtension
    {
        public static void Reset(this Transform target)
        {
            target.position = Vector3.zero;
            target.localPosition = Vector3.zero;
            target.rotation = Quaternion.Euler(0f, 0f, 0f);
            target.localRotation = Quaternion.Euler(0f, 0f, 0f);
        }
    }
}