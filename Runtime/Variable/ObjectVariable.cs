using UnityEngine;

namespace SleepyApe
{
    [CreateAssetMenu(menuName = "SleepyApe/Variable/Object", order = -1000)]
    public class ObjectVariable : Variable<Object>
    {
        public T ValueAs<T>() where T : Object => (T)Value;
    }
}