using System.Collections.Generic;
using UnityEngine;

namespace SleepyApe
{
    [DefaultExecutionOrder(-2000)]
    public class TagComponent : MonoBehaviour
    {
        [SerializeField] private List<Tag> _tags;

        private void Awake()
        {
            _tags.ForEach(tag => tag.Add(gameObject));
        }
    }
}