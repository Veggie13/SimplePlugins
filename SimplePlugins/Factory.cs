using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SimplePlugins
{
    public abstract class Factory<T, U> : Registry<T>.IFactory
        where U : T
    {
        public Type ExportedType
        {
            get { return typeof(U); }
        }

        public abstract T Create(IDictionary<string, object> parms);
    }
}
