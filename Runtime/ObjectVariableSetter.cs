using System;
using UnityEngine;
using Object = UnityEngine.Object;

namespace SleepyApe
{
    [DefaultExecutionOrder(-2000)]
    public class ObjectVariableSetter : MonoBehaviour
    {
        [SerializeField] private VariableData[] _variables = null;

        private void Awake()
        {
            foreach (var variable in _variables)
                variable.objectVariable.Value = variable.sceneObject;

            Destroy(this);
        }
    }

    [Serializable]
    public struct VariableData
    {
        public ObjectVariable objectVariable;
        public Object sceneObject;
    }
}