using System.Collections.Generic;
using System.Reflection;
using System;
using System.Linq;

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

        public static object Instantiate(this Type type)
        {
            return type.GetConstructor(new Type[0]).Invoke(new object[0]);
        }
        
        public static T Instantiate<T>(this Type type)
        {
            if (!typeof(T).IsAssignableFrom(type))
                throw new InvalidCastException("Cannot instantiate type as T.");
            return (T)type.Instantiate();
        }

        public static bool HasInterface(this Type type, Type baseInterface)
        {
            if (!baseInterface.IsInterface)
                return false;

            Type[] interfaces = type.GetInterfaces();

            if (baseInterface.IsGenericTypeDefinition)
            {
                return interfaces.Where(t => t.IsGenericType)
                    .Select(t => t.GetGenericTypeDefinition())
                    .Contains(baseInterface);
            }
            else
            {
                return interfaces.Contains(baseInterface);
            }
        }

        public static Type FromDefinition(this Type type, Type definition)
        {
            if (!definition.IsGenericTypeDefinition)
            {
                throw new ArgumentException("definition must be a Generic Type Definition");
            }

            Type[] interfaces = type.GetInterfaces();

            return interfaces.First(t => t.IsGenericType && t.GetGenericTypeDefinition().Equals(definition));
        }
    }
}
