using System.Collections.Generic;
using UnityEngine;

namespace SleepyApe
{
    [CreateAssetMenu(fileName = "Tag", menuName = "SleepyApe/Tag")]
    public class Tag : ScriptableObject
    {
        [SerializeField] private string _name;

        private List<GameObject> _gameObjects;

        public string Name => _name;

        public void Add(GameObject gameObject)
        {
            if (!_gameObjects.Contains(gameObject))
                _gameObjects.Add(gameObject);
        }
    }
}