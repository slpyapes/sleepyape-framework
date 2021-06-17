using UnityEngine;

namespace SleepyApe
{
    public abstract class Reference<TType, TVariable> where TVariable : Variable<TType>
    {
        [SerializeField] private bool _useConstant = false;
        [SerializeField] private TType _constantValue = default;
        [SerializeField] private TVariable _variableValue = default;

        /// <summary>
        /// Return reference value
        /// </summary>
        public TType Value => _useConstant ? _constantValue : _variableValue.Value;

        /// <summary>
        /// Return variable if UseVariable is true
        /// </summary>
        public TVariable Variable => !_useConstant ? _variableValue : null;

        /// <summary>
        /// Is this reference use variable?
        /// </summary>
        public bool UseVariable => !_useConstant;
    }
}