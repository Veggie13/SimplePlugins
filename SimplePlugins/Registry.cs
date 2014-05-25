using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;

namespace SimplePlugins
{
    public class Registry
    {
        #region Class Members
        private Dictionary<Type, ITypeRegistry> _registries = new Dictionary<Type, ITypeRegistry>();
        #endregion

        #region Properties
        public IEnumerable<Type> RegisteredTypes
        {
            get { return _registries.Keys; }
        }

        public IEnumerable<ITypeRegistry> TypeRegistries
        {
            get { return _registries.Values; }
        }

        public ITypeRegistry this[Type type]
        {
            get { return _registries[type]; }
        }
        #endregion

        #region Public Methods
        public TypeRegistry<T> GetTypeRegistry<T>()
        {
            return (TypeRegistry<T>)_registries[typeof(T)];
        }

        public IEnumerable<ImportInfo> GetImportedTypes<T>()
        {
            return GetTypeRegistry<T>().ImportedTypes;
        }

        public T Create<T>(string name, IDictionary<string, object> parms)
        {
            var registry = (TypeRegistry<T>)_registries[typeof(T)];
            return registry.Create(name, parms);
        }

        public void Load(string path)
        {
            var pluginModule = System.Reflection.Assembly.LoadFile(path);
            var factoryTypes = pluginModule.TypesWith<FactoryAttribute>().Where(t => t.HasInterface(typeof(TypeRegistry<>.IFactory)));
            foreach (var factoryType in factoryTypes)
            {
                Type factoryInterface = factoryType.FromDefinition(typeof(TypeRegistry<>.IFactory));
                Type factoryTarget = factoryInterface.GetGenericArguments()[0];
                Type registryType = typeof(TypeRegistry<>).MakeGenericType(factoryTarget);
                if (!_registries.ContainsKey(factoryTarget))
                {
                    var registry = registryType.Instantiate<ITypeRegistry>();
                    _registries[factoryTarget] = registry;
                }
                _registries[factoryTarget].Import(path);
            }
        }

        public void LoadDirectory(string path, bool recursive = false)
        {
            var dirInfo = new DirectoryInfo(path);

            foreach (var fileInfo in dirInfo.GetFiles("*.dll", recursive ? SearchOption.AllDirectories : SearchOption.TopDirectoryOnly))
            {
                Load(fileInfo.FullName);
            }
        }
        #endregion
    }
}
