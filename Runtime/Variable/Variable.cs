using System;
using UnityEngine;

namespace SleepyApe
{
    public abstract class Variable<T> : ScriptableObject
    {
        public event Action OnValueChange;
        public event Action OnValueReset;

        [SerializeField] private T _defaultValue = default;

        private T _modifiedValue;

        /// <summary>
        /// Get Variable Value
        /// </summary>
        /// <value>Modified Value</value>
        public T Value
        {
            get => _modifiedValue;
            set
            {
                _modifiedValue = value;
                OnValueChange?.Invoke();
            }
        }

        private void OnEnable() => _modifiedValue = _defaultValue;

        public void Reset()
        {
            _modifiedValue = _defaultValue;
            OnValueReset?.Invoke();
        }
    }
}