using System.Collections.Generic;
using System.Reflection;
using System;

namespace SimplePlugins
{
    static class Extensions
    {
        public static IEnumerable<Type> TypesWith<AT>(this Assembly assembly) where AT : Attribute
        {
            foreach (Type type in assembly.GetTypes())
            {
                if (type.GetCustomAttributes(typeof(AT), true).Length > 0)
                {
                    yield return type;
                }
            }
        }
    }
}
