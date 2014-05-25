using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TestPlatform;

namespace TestPlugin2
{
    [SimplePlugins.Factory("Test Class4", Description = "This is another test class")]
    public class Class4Factory : SimplePlugins.TypeRegistry<IBase1>.IFactory
    {
        public IBase1 Create(IDictionary<string, object> parms)
        {
            return new Class4();
        }
    }

    class Class4 : IBase1
    {
        public string Name
        {
            get { return "Class4"; }
        }
    }
}
