using UnityEngine;

namespace SleepyApe
{
    public static class GameObjectExtension
    {
        public static void Disable(this GameObject target)
        {
            target.SetActive(false);
        }

        public static void Enable(this GameObject target)
        {
            target.SetActive(true);
        }

        public static void Destroy(this GameObject target)
        {
            GameObject.Destroy(target);
        }

        public static bool ContainTag(this GameObject target, Tag tag)
        {
            var tagComponent = target.GetComponent<TagComponent>();
            if (tagComponent != null)
            {
                return tagComponent.Contains(tag);
            }

            return false;
        }
    }
}