using System.Collections.Generic;
using System.Reflection;
using System;

namespace SimplePlugins
{
    static class Extensions
    {
        public static bool Has<AT>(this Type type) where AT : Attribute
        {
            return (type.GetCustomAttributes(typeof(AT), true).Length > 0);
        }

        public static IEnumerable<Type> TypesWith<AT>(this Assembly assembly) where AT : Attribute
        {
            foreach (Type type in assembly.GetTypes())
            {
                if (type.Has<AT>())
                {
                    yield return type;
                }
            }
        }

        public static AT Get<AT>(this Type type) where AT : Attribute
        {
            if (!type.Has<AT>())
                return default(AT);
            return (AT)type.GetCustomAttributes(typeof(AT), true)[0];
        }
    }
}
