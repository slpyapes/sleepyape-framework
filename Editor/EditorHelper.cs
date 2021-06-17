using System;
using System.IO;
using System.Linq;

namespace SleepyApe
{
    public static class EditorHelper
    {
        public static Type[] FindDerivedTypes(Type fromType)
        {
            return AppDomain.CurrentDomain
                .GetAssemblies()
                .SelectMany(type => type.GetTypes())
                .Where(
                    type => !type.IsInterface
                    && !type.IsAbstract
                    && type != fromType
                    && fromType.IsAssignableFrom(type)
                ).ToArray();
        }

        public static void CreateDirectoryIfNotExists(string directoryName)
        {
            if (!Directory.Exists(directoryName))
                Directory.CreateDirectory(directoryName);
        }
    }
}