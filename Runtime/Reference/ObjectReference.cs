using System;
using Object = UnityEngine.Object;

namespace SleepyApe
{
    [Serializable]
    public class ObjectReference : Reference<Object, ObjectVariable>
    {
        /// <summary>
        /// Cast Value as Unity Object
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <returns>Target T Object</returns>
        public T ValueAs<T>() where T : Object
        {
            return (T)Value;
        }
    }
}