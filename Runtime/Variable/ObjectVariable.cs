using UnityEngine;

namespace SleepyApe
{
    [CreateAssetMenu(menuName = "SleepyApe/Variable/Object", order = -1000)]
    public class ObjectVariable : Variable<Object>
    {
        /// <summary>
        /// Cast Value as Unity Object
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <returns>Target T Object</returns>
        public T ValueAs<T>() where T : Object => (T)Value;
    }
}