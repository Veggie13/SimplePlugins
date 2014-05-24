using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SimplePlugins
{
    public static class Registry<T>
    {
        public interface IFactory
        {
            T Create(IDictionary<string, object> parms);
        }

        private static Dictionary<string, IFactory> _register = new Dictionary<string, IFactory>();

        public static T Create(string name, IDictionary<string, object> parms)
        {
            return _register[name].Create(parms);
        }

        public static void Import(string path)
        {
            var pluginModule = System.Reflection.Assembly.LoadFile(path);
            var factories = pluginModule.TypesWith<FactoryAttribute>().Where(t => typeof(IFactory).IsAssignableFrom(t));
            foreach (var factoryType in factories)
            {
                IFactory factory = (IFactory)factoryType.GetConstructor(new Type[0]).Invoke(new object[0]);
                Register(factoryType.Get<FactoryAttribute>().Name, factory);
            }
        }

        public static IEnumerable<string> ImportedTypes
        {
            get { return _register.Keys; }
        }

        private static void Register(string name, IFactory factory)
        {
            _register[name] = factory;
        }
    }
}
