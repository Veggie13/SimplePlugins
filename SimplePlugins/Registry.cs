using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SimplePlugins
{
    public class Registry<T>
    {
        #region Types
        public interface IFactory
        {
            T Create(IDictionary<string, object> parms);
        }
        #endregion

        #region Class Members
        private Dictionary<string, Tuple<ImportInfo, IFactory>> _register = new Dictionary<string, Tuple<ImportInfo, IFactory>>();
        #endregion

        #region Properties
        public IEnumerable<ImportInfo> ImportedTypes
        {
            get { return _register.Values.Select(t => t.Item1); }
        }
        #endregion

        #region Public Methods
        public T Create(string name, IDictionary<string, object> parms)
        {
            return _register[name].Item2.Create(parms);
        }

        public void Import(string path)
        {
            var pluginModule = System.Reflection.Assembly.LoadFile(path);
            var factories = pluginModule.TypesWith<FactoryAttribute>().Where(t => typeof(IFactory).IsAssignableFrom(t));
            foreach (var factoryType in factories)
            {
                register(factoryType);
            }
        }
        #endregion

        #region Private Helpers
        private void register(Type factoryType)
        {
            var attr = factoryType.Get<FactoryAttribute>();
            var factory = factoryType.Instantiate<IFactory>();
            _register[attr.Name] = new Tuple<ImportInfo,IFactory>(new ImportInfo(attr.Name, attr.Description, factoryType.Assembly), factory);
        }
        #endregion
    }
}
