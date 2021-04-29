using System;
using Object = UnityEngine.Object;

namespace SleepyApe
{
    [Serializable]
    public class ObjectReference : Reference<Object, ObjectVariable>
    {
    }
}