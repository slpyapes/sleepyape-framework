using UnityEngine;

namespace SleepyApe
{
    public abstract class Reference<TType, TVariable> where TVariable : Variable<TType>
    {
        [SerializeField] private bool _useConstant = false;
        [SerializeField] private TType _constantValue = default;
        [SerializeField] private TVariable _variableValue = default;

        public TType Value => _useConstant ? _constantValue : _variableValue.Value;

        public TVariable Variable => !_useConstant ? _variableValue : null;
    }
}