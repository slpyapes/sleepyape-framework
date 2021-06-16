using System;
using Object = UnityEngine.Object;

namespace SleepyApe
{
    [Serializable]
    public class ObjectReference : Reference<Object, ObjectVariable>
    {
        public T ValueAs<T>() where T : Object => (T)Value;
    }
}